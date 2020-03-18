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
using LOLFan.Collections;

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
            NONE,       // Invalid
            VALUE,      // Current value
            MIN,        // Minimum value
            MAX,        // Maximum value
            REL,        // Percentage between min and max
            CAL,        // Calibrated value (fans)
            PREV,       // Previous values
            AVG         // Average of last x seconds
        }

        private List<ISensor> sensors;
        private List<ISensor> used;
        private List<RefType> type;
        private List<int> param;

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
            param = new List<int>();
            int count = 0;
            bool replaced;

            // [] reserved for ncalc variables
            input = input.Replace('[', ' ').Replace(']', ' ');

            string converted = input;
            Match m = Regex.Match(input, "{([a-zA-Z0-9/]+)(,min|,max|,val|,rel|,cal|,prv([0-9]+)|,avg([0-9]+))?}");
            while (m.Success)
            {
                replaced = false;
                for (int i = 0; i < sensors.Count; i++)
                {
                    if (sensors[i].Identifier.ToString() == m.Groups[1].ToString())
                    {
                        used.Add(sensors[i]);                        
                        converted = converted.Replace(m.Groups[0].ToString(), "[" + count + "]");

                        if (m.Groups[2].ToString().StartsWith(",prv"))
                        {
                            param.Add(int.Parse(m.Groups[3].ToString()));
                            type.Add(RefType.PREV);
                        } else
                        if (m.Groups[2].ToString().StartsWith(",avg"))
                        {
                            param.Add(int.Parse(m.Groups[4].ToString()));
                            type.Add(RefType.AVG);
                        }
                        else
                        {
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
                            param.Add(0);
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

        private float ParseOutput(DateTime? time = null)
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
                            if (time.HasValue)
                            {
                                exp.Parameters[i + ""] = GetValueAtTime(used[i].Values as RingCollection<SensorValue>, time.Value);
                            }
                            else
                            {
                                exp.Parameters[i + ""] = (used[i].Value.HasValue ? used[i].Value.Value : 0);
                            }
                            break;
                        case RefType.PREV:
                            if (time.HasValue)
                            {
                                exp.Parameters[i + ""] = GetValueAtTime(used[i].Values as RingCollection<SensorValue>, time.Value.AddSeconds(-1 * param[i]));
                            } else
                            {
                                exp.Parameters[i + ""] = GetPreviousValue(used[i].Values as RingCollection<SensorValue>, param[i]);
                            }
                            break;
                        case RefType.AVG:
                            if (time.HasValue)
                            {
                                exp.Parameters[i + ""] = GetPreviousAverageAtTime(used[i].Values as RingCollection<SensorValue>, param[i], time.Value);
                            }
                            else
                            {
                                exp.Parameters[i + ""] = GetPreviousAverage(used[i].Values as RingCollection<SensorValue>, param[i]);
                            }
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

        private static float GetPreviousValue(RingCollection<SensorValue> vals, int seconds)
        {
            for (int i = vals.Count-1; i>0; i--)
            {
                if ((DateTime.UtcNow - vals[i].Time).TotalSeconds > seconds) break;
                if ((DateTime.UtcNow - vals[i].Time).TotalSeconds < seconds && (DateTime.UtcNow - vals[i - 1].Time).TotalSeconds >= seconds) return vals[i - 1].Value;
            }
            return vals[vals.Count-1].Value;
        }

        private static float GetPreviousAverage(RingCollection<SensorValue> values, int seconds)
        {
            float sum = 0f;
            int items = 0;
            for (int i = values.Count - 1; i > 0; i--)
            {
                if ((DateTime.UtcNow - values[i].Time).TotalSeconds > seconds) break;
                if ((DateTime.UtcNow - values[i].Time).TotalSeconds <= seconds)
                {
                    sum += values[i].Value;
                    items++;
                }
            }
            return sum / items;
        }

        private static float GetPreviousAverageAtTime(RingCollection<SensorValue> values, int seconds, DateTime time)
        {
            float sum = 0f;
            int items = 0;
            for (int i = values.Count - 1; i > 0; i--)
            {
                if (time.AddSeconds(-1 * seconds) > values[i - 1].Time) break;
                if (time >= values[i].Time)
                {
                    sum += values[i].Value;
                    items++;
                }
            }
            return sum / items;
        }

        private static float GetValueAtTime(RingCollection<SensorValue> values, DateTime time)
        {
            for (int i = values.Count - 1; i > 0; i--)
            {
                if (time > values[i].Time) break;
                if (time < values[i].Time && time >= values[i - 1].Time)
                {
                    time = values[i - 1].Time;
                    return values[i - 1].Value;
                }
            }
            return values[values.Count - 1].Value;
        }

        public RingCollection<SensorValue> CreateHistory(RingCollection<SensorValue> values)
        {
            values.Clear();
            // Create a sorted list of all sensor log times
            List<DateTime> times = new List<DateTime>();
            foreach (ISensor s in used)
            {
                foreach (SensorValue v in s.Values)
                {
                    times.Add(v.Time);
                }
            }
            times.Sort((a, b) => b.CompareTo(a));
            foreach (DateTime cur in times) 
            {
                float val = ParseOutput(cur);
                values.Append(new SensorValue(val, cur));
            }
            if (values.Count > 0) values.Last = new SensorValue(ParseOutput(), DateTime.UtcNow);

            return values;
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
                DateTime t = DateTime.UtcNow;
                return ParseOutput();
            }
        }

    }
}
