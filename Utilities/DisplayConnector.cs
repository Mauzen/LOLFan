/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>                          
	
*/

using System;
using System.Collections.Generic;
using System.Text;
using LOLFan.Hardware;
using System.IO.Ports;
using System.Globalization;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.ComponentModel;
using LOLFan.Hardware.External;
using System.Net.NetworkInformation;
using System.Windows.Forms;

// Used as interface between software-part of sensors and hardware arduino class

namespace LOLFan.Utilities
{

    public class DisplayConnector
    {
        public enum LCDConnectionMode
        {
            NONE = 0,
            SERIAL = 1,
            ARDUINO = 2
        }

        private readonly Identifier identifier = new Identifier("DisplayConnector");

        private LCDConnectionMode mode;
        private PersistentSettings settings;
        private List<ISensor> sensors;
        private Arduino arduino;

        private List<SensorString> text;
        private int curText;


        public DisplayConnector(IHardware[] hardware, List<ISensor> sensors, PersistentSettings settings)
        {
            this.settings = settings;
            this.sensors = sensors;

            int tmp = 0;
            if (!int.TryParse(settings.GetValue(
                new Identifier(identifier, "mode").ToString(), "2"),
              NumberStyles.Integer, CultureInfo.InvariantCulture,
              out tmp))
            {
                mode = LCDConnectionMode.NONE;
            }
            else
            {
                mode = (LCDConnectionMode)tmp;
            }


            text = new List<SensorString>();

            this.curText = 0;
            int.TryParse(settings.GetValue(new Identifier(identifier, "curText").ToString(), "0"), out this.curText);

            int curID = 0;
            while (settings.Contains(new Identifier(identifier, curID + "", "text").ToString()))
            {
                text.Add(new SensorString(settings.GetValue(new Identifier(identifier, curID + "", "text").ToString(), "-"), sensors));
                curID++;
            }
            if (text.Count == 0) text.Add(new SensorString("-", sensors));

            // this.text = new List<SensorString>(new SensorString(settings.GetValue(new Identifier(identifier, curText + "", "text").ToString(), "-"), sensors);

            if (mode == LCDConnectionMode.SERIAL)
            {
                try
                {
                    //InitSerial(settings.GetValue(new Identifier(identifier, "comport").ToString(), "COM1"));
                } catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                    mode = LCDConnectionMode.NONE;
                }
            } else if (mode == LCDConnectionMode.ARDUINO)
            {
                // Stupidly pick the first Arduino found
                foreach (IHardware h in hardware) {
                    if (h.GetType() == typeof(Arduino))
                    {
                        arduino = (Arduino) h;
                        break;
                    }
                }
                if (arduino == null) mode = LCDConnectionMode.NONE;
                else
                {
                    arduino.SetDisplay(true);
                    settings.hotkeyManager.RegisterHotkey("test", 0x0002 + 0x0004, (int)Keys.P, delegate
                    {
                        ToggleDisplay();
                    });
                    settings.hotkeyManager.RegisterHotkey("next_display_text", 0x0002 + 0x0004, (int)Keys.J, delegate
                    {
                        if (CurText + 1 > text.Count - 1) CurText = 0;
                        else CurText = CurText + 1;
                    });
                    settings.hotkeyManager.RegisterHotkey("prev_display_text", 0x0002 + 0x0004, (int)Keys.K, delegate
                    {
                        if (CurText - 1 < 0) CurText = text.Count - 1;
                        else CurText = CurText - 1;
                    });
                }


            }
           
        }

        public void AddSensorString(string stext)
        {
            text.Add(new SensorString(stext, sensors));
            int id = text.Count - 1;
            settings.SetValue(new Identifier(identifier, id + "", "text").ToString(), stext);
        }

        public bool RemoveSensorString(int id)
        {
            if (text.Count == 1) return false;

            // Update IDs for all following SensorStrings
            for (int i = text.Count - 1; i > id; i--)
            {
                settings.SetValue(new Identifier(identifier, i-1 + "", "text").ToString(), text[i].Input);
            }
            text.RemoveAt(id);
            settings.Remove(new Identifier(identifier, text.Count + "", "text").ToString());

            if (curText >= id)
            {
                curText--;
            }
            return true;
        }

        public void SwapSensorStrings(int a, int b)
        {
            SensorString oldA = text[a];
            text[a] = text[b];
            text[b] = oldA;

            settings.SetValue(new Identifier(identifier, a + "", "text").ToString(), text[a].Input);
            settings.SetValue(new Identifier(identifier, b + "", "text").ToString(), text[b].Input);
        }

        // TODO
        public void InsertSensorStrings(int a, int b)
        {
            SensorString oldA = text[a];
            text[a] = text[b];
            text[b] = oldA;

            settings.SetValue(new Identifier(identifier, a + "", "text").ToString(), text[a].Input);
            settings.SetValue(new Identifier(identifier, b + "", "text").ToString(), text[b].Input);
        }

        public void ChangeSensorStringInput(int idx, string stext)
        {
            text[idx].Input = stext;
            settings.SetValue(new Identifier(identifier, idx + "", "text").ToString(), stext);
            if (idx == curText)
            {
                Update();
            }
        }


        public void Update()
        {
            
            switch (mode)
            {
                case LCDConnectionMode.SERIAL:
                case LCDConnectionMode.ARDUINO:

                    string output = text[curText].Output.Replace("TIME", DateTime.Now.ToString("HH:mm"));
                    arduino.DisplayText = output;
                    break;
            }

        }       


        public void ToggleDisplay()
        {
            if (mode != LCDConnectionMode.ARDUINO) return;
            arduino.ToggleDisplay();
        }
        public void SetDisplay(bool on)
        {
            if (mode != LCDConnectionMode.ARDUINO) return;
            arduino.SetDisplay(on);
        }

        public string FormatString
        {
            get
            {
                return text[curText].Input;
            }
            set
            {
                if (text[curText].Input != value)
                {
                    text[curText].Input = value;
                    settings.SetValue(new Identifier(identifier, curText + "", "text").ToString(), value);
                }
            }
        }

        public int CurText
        {
            get
            {
                return curText;
            }
            set
            {
                if (curText != value)
                {
                    curText = value;
                    settings.SetValue(new Identifier(identifier, "curText").ToString(), curText);
                    Update();
                }
            }
        }

        public List<SensorString> Text
        {
            get
            {
                return text;
            }
        }

        public LCDConnectionMode ConnectionMode
        {
            get
            {
                return mode;
            }
        }

    }
}
