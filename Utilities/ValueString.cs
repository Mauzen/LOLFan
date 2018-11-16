/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>                          
	
*/

using NCalc;
using LOLFan.Hardware;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

// A string containing sensor identifiers
// that are supposed to be translated to their
// current values, and mathematical operations
// For calculating purposes

namespace LOLFan.Utilities
{
    public class ValueString
    {

        enum RefType
        {
            NONE,
            VALUE,
            MIN,
            MAX,
            REL,
            CAL
        }

        private List<ISensor> sensors;
        private List<ISensor> used;
        private List<RefType> type;

        private string input;
        private bool parsed;

        private Expression exp;

        public ValueString(string input, List<ISensor> sensors)
        {
            this.sensors = sensors;
            this.input = input;

            ConvertInput();
        }


        private void ConvertInput()
        {
            used = new List<ISensor>();
            type = new List<RefType>();
            int count = 0;
            bool replaced;

            // [] reserved for ncalc variables
            input = input.Replace('[', ' ').Replace(']', ' ');

            string converted = input;
            Match m = Regex.Match(input, "{([a-zA-Z0-9/]+)(,min|,max|,val|,rel|,cal)?}");
            while (m.Success)
            {
                replaced = false;
                for (int i = 0; i < sensors.Count; i++)
                {
                    if (sensors[i].Identifier.ToString() == m.Groups[1].ToString())
                    {
                        used.Add(sensors[i]);                        
                        converted = converted.Replace(m.Groups[0].ToString(), "[" + count + "]");
                        if (m.Groups[2].ToString() == ",min")
                        {
                            type.Add(RefType.MIN);
                        }
                        else if (m.Groups[2].ToString() == ",max")
                        {
                            type.Add(RefType.MAX);
                        }
                        else if (m.Groups[2].ToString() == ",rel")
                        {
                            type.Add(RefType.REL);
                        }
                        else if (m.Groups[2].ToString() == ",cal")
                        {
                            type.Add(RefType.CAL);
                        }
                        else
                        {
                            type.Add(RefType.VALUE);
                        }
                        replaced = true;
                        break;
                    }
                }
                parsed = true;
                if (!replaced)
                {
                    // Sensor not found
                    used.Add(null);
                    type.Add(RefType.NONE);
                    converted = converted.Replace(m.Groups[0].ToString(), "[" + count + "]");
                    parsed = false;
                }
                
                count++;
                m = m.NextMatch();
            }
            if (converted.Length > 0)
            {
                exp = new Expression(converted);
          
            }

        }

        private float ParseOutput()
        {
            if (exp == null) return float.PositiveInfinity;
            object[] values = new object[used.Count];
            for (int i = 0; i < used.Count; i++)
            {
                if (used[i] != null)
                {
                    switch (type[i])
                    {
                        case RefType.NONE:
                            exp.Parameters[i + ""] = 0;
                            break;
                        case RefType.VALUE:
                            exp.Parameters[i + ""] = (used[i].Value.HasValue ? used[i].Value.Value : 0);
                            break;
                        case RefType.MAX:
                            exp.Parameters[i + ""] = (used[i].Max.HasValue ? used[i].Max.Value : 0);
                            break;
                        case RefType.MIN:
                            exp.Parameters[i + ""] = (used[i].Min.HasValue ? used[i].Min.Value : 0);
                            break;
                        case RefType.REL:
                            exp.Parameters[i + ""] = (used[i].Value.Value - used[i].Min.Value) / (used[i].Max.Value - used[i].Min.Value) * 100;
                            break;
                        case RefType.CAL:


                            if (used[i].SensorType == SensorType.Control && used[i].Control.UseCalibrated && used[i].Value.HasValue)
                            {
                                if (used[i].Control.InternalSoftwareValue == 100)
                                {
                                    exp.Parameters[i + ""] = 100;
                                }
                                else
                                {
                                    exp.Parameters[i + ""] = (used[i].Value.HasValue ? used[i].Control.Calibrated.GetInverse(used[i].Control.InternalSoftwareValue, true) / used[i].Control.MaxRPM * 100.0 : 0);
                                }
                            }
                            else exp.Parameters[i + ""] = (used[i].Value.HasValue ? used[i].Value.Value : 0);
                            break;
                    }

                }
                else
                {
                    exp.Parameters[i + ""] = 0;
                }
            }
            try
            {
                return float.Parse(exp.Evaluate()+"");
            }
            catch (Exception) {                
                return float.PositiveInfinity;
            }
        }



        public string Input
        {
            get
            {
                return input;
            }
            set
            {
                if (input != value)
                {
                    this.input = value;
                    ConvertInput();
                }
            }
        }

        public float Output
        {
            get
            {
                if (!parsed)
                {
                    // If conversion failed due to missing sensors, try again
                    ConvertInput();
                }
                return ParseOutput();
            }
        }

    }
}
