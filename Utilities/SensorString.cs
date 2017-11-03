/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>                          
	
*/

using LOLFan.Hardware;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

// A string containing sensor identifiers
// that are supposed to be translated to their
// current values
// For displaying purposes

namespace LOLFan.Utilities
{
    public class SensorString
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
        private string converted;

        public SensorString(string input, List<ISensor> sensors)
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
            converted = input;
            Match m = Regex.Match(input, "{([a-zA-Z0-9/]+)(,min|,max|,val|,rel|,cal)?(,([0-9dDfFiI:]*))?}");
            while (m.Success)
            {
                replaced = false;
                for (int i = 0; i < sensors.Count; i++)
                {
                    if (sensors[i].Identifier.ToString() == m.Groups[1].ToString())
                    {
                        used.Add(sensors[i]);
                        if (m.Groups[3].Length > 0 && Regex.IsMatch(m.Groups[3].ToString(), ",[0-9]*(:[cCDeEfFgGnNpPRrXx][0-9]*)?"))
                        {
                            converted = converted.Replace(m.Groups[0].ToString(), "{" + count + m.Groups[3].ToString() + "}");
                        }
                        else
                        {
                            converted = converted.Replace(m.Groups[0].ToString(), "{" + count + "}");
                        }
                        if (m.Groups[2].ToString() == ",min")
                        {
                            type.Add(RefType.MIN);
                        } else if (m.Groups[2].ToString() == ",max")
                        {
                            type.Add(RefType.MAX);
                        } else if (m.Groups[2].ToString() == ",rel")
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
                if (!replaced)
                {
                    // Sensor not found
                    used.Add(null);
                    type.Add(RefType.NONE);
                    if (m.Groups[4].Length > 0 && Regex.IsMatch(m.Groups[3].ToString(), ",[0-9]*(:[cCDeEfFgGnNpPRrXx][0-9]*)?"))
                    {
                        converted = converted.Replace(m.Groups[0].ToString(), "{" + count + m.Groups[3].ToString() + "}");
                    }
                    else
                    {
                        converted = converted.Replace(m.Groups[0].ToString(), "{" + count + "}");
                    }
                }
                
                count++;
                m = m.NextMatch();
            }
            Debug.WriteLine(converted);

        }

        private string ParseOutput(string tag)
        {
            string result = input;
            object[] values = new object[used.Count];
            for (int i = 0; i < used.Count; i++)
            {
                if (used[i] != null)
                {
                    switch (type[i])
                    {
                        case RefType.NONE:
                            values[i] = 0;
                            break;
                        case RefType.VALUE:
                            values[i] = (used[i].Value.HasValue ? used[i].Value.Value : 0);
                            break;
                        case RefType.MAX:
                            values[i] = (used[i].Max.HasValue ? used[i].Max.Value : 0);
                            break;
                        case RefType.MIN:
                            values[i] = (used[i].Min.HasValue ? used[i].Min.Value : 0);
                            break;
                        case RefType.REL:
                            values[i] = (used[i].Value.Value - used[i].Min.Value) / (used[i].Max.Value - used[i].Min.Value)*100;
                            break;
                        case RefType.CAL:
                            

                            if (used[i].SensorType == SensorType.Control && used[i].Control.UseCalibrated && used[i].Value.HasValue)
                            {
                                if (used[i].Control.InternalSoftwareValue == 100)
                                {
                                    values[i] = 100;
                                }
                                else
                                {
                                    values[i] = (used[i].Value.HasValue ? used[i].Control.Calibrated.GetInverse(used[i].Control.InternalSoftwareValue) / used[i].Control.MaxRPM * 100.0 : 0);
                                }
                            }
                            else values[i] = (used[i].Value.HasValue ? used[i].Value.Value : 0);
                            break;
                    }                       

                } else
                {
                    values[i] = "-";
                }
            }
            try
            {
                result = string.Format(CultureInfo.GetCultureInfo(tag).NumberFormat, converted, values);
            }
            catch (FormatException)
            {
            }

            return result;
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

        public string Output
        {
            get
            {
                return ParseOutput(CultureInfo.CurrentCulture.Name);
            }
        }

        // For NCalc
        public string OutputEN
        {
            get
            {
                return ParseOutput("en-us");
            }
        }
    }
}
