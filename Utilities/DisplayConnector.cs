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

    class DisplayConnector
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

        private SensorString text;


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


            // Network traffic
            /*interfaces = NetworkInterface.GetAllNetworkInterfaces();
            lastSent = new long[interfaces.Length];
            lastReceived = new long[interfaces.Length];
            for (int i = 0; i < interfaces.Length; i++)
            {
                lastSent[i] = interfaces[i].GetIPv4Statistics().BytesSent;
                lastReceived[i] = interfaces[i].GetIPv4Statistics().BytesReceived;
            }
            sw = Stopwatch.StartNew();            */


            this.text = new SensorString(settings.GetValue(new Identifier(identifier, "text").ToString(), "-"), sensors);

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
                }


            }
           
        }
       
        


        public void Update()
        {
            
            switch (mode)
            {
                case LCDConnectionMode.SERIAL:
                case LCDConnectionMode.ARDUINO:
                    // Network traffic
                   /* float sent = 0;
                    float received = 0;
                    for (int i = 0; i < interfaces.Length; i++)
                    {
                        sent += interfaces[i].GetIPv4Statistics().BytesSent - lastSent[i];
                        lastSent[i] = interfaces[i].GetIPv4Statistics().BytesSent;
                        received += interfaces[i].GetIPv4Statistics().BytesReceived - lastReceived[i];
                        lastReceived[i] = interfaces[i].GetIPv4Statistics().BytesReceived;
                    }
                    sent = (sent / (sw.ElapsedMilliseconds / 1000)) / 1024;
                    received = (received / (sw.ElapsedMilliseconds / 1000)) / 1024;
                    sw.Reset();
                    sw.Start();

                    if (sent > 1000) sent = 0;
                    if (received > 10000) received = 0;*/

                    //string s = string.Format("{0,3:F0}", sent);
                    //string r = string.Format("{0,4:F0}", received);

                    string output = text.Output.Replace("TIME", DateTime.Now.ToString("HH:mm"));
                    //output = output.Replace("NET_UP", s);
                    //output = output.Replace("NET_DOWN", r);
                    arduino.DisplayText = output;
                    //port.Write(ParseFormatText());
                    //char[] text = ParseFormatText().ToCharArray();
                    //port.Write(text,0, (text.Length<40?text.Length:40));

                    //if (text.Length >= 40) port.Write(text, 40, text.Length-40);
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
                return text.Input;
            }
            set
            {
                if (text.Input != value)
                {
                    text.Input = value;
                    settings.SetValue(new Identifier(identifier, "text").ToString(), value);
                }
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
