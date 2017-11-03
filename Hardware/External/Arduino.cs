/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>                          
	
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO.Ports;

/**
 * Tasmota is a firmware for Itead Sonoff devices.
 * This class supports Tasmota on Sonoff POW for power monitoring devices.
 **/

namespace LOLFan.Hardware.External
{
    public class Arduino : Hardware
    {
       // private SensorString text;
        private List<ISensor> sensors;
       // private string s = "";
        BackgroundWorker worker;
        private SerialPort port;
        private ushort curSkip;
        private ushort skip;
        private bool connected;
        private string lastOutput = "";
        private string displayText = "Initializing...";
        private bool skipNext;

        public Arduino(string name, string comport, Identifier identifier, ISettings settings) : base(name, identifier, settings)
        {
            if (!ushort.TryParse(settings.GetValue(
                new Identifier(identifier, "skip").ToString(), "2"),
              NumberStyles.Integer, CultureInfo.InvariantCulture,
              out skip))
            {
                skip = 3;
            }

            sensors = new List<ISensor>();
            sensors.Add(new Sensor("Air IN Side", 0, SensorType.Temperature, this, settings));
            sensors.Add(new Sensor("Air IN Front", 1, SensorType.Temperature, this, settings));
            sensors.Add(new Sensor("Air OUT", 2, SensorType.Temperature, this, settings));
            foreach(ISensor sen in sensors) ActivateSensor(sen);

            InitSerial(comport);

            worker = new BackgroundWorker();

            worker.DoWork += (sender, args) => {
                if (skipNext)
                {
                    skipNext = false;
                    return;
                }
                try
                {
                    if (displayText.Length > 64)
                    {
                        port.Write(displayText.Substring(0, 64));
                        port.Write(displayText.Substring(64));
                    }
                    else
                    {
                        port.Write(displayText);
                    }
                } catch (Exception)
                {
                    connected = false;
                }

            };


        }

        private void InitSerial(string comport)
        {
            try
            {
                port = new SerialPort(comport);
                port.DataReceived += this.port_DataReceived;

                port.WriteBufferSize = 80;
                port.Open();

                // Init to get fast responses
                port.Write(displayText);
                connected = true;
            } catch (Exception)
            {
                connected = false;
            }

            /*worker = new BackgroundWorker();

            worker.DoWork += (sender, args) => {
                try
                {
                    port.Write(text.Output);
                    Debug.WriteLine(port.Read(output, 0, 64));
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                    mode = LCDConnectionMode.NONE;
                }
            };*/

        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] b = new byte[80];
            port.Read(b, 0, 80);
            lastOutput = System.Text.Encoding.UTF8.GetString(b);
            //Debug.WriteLine("\r\n" + lastOutput);
        }

        public override HardwareType HardwareType
        {
            get
            {
                return HardwareType.External;
            }
        }

        public override void Update()
        {
            if (!connected) return;

            curSkip++;
            if (curSkip > skip)
            {
                curSkip = 0;
            }
            else
            {
                return;
            }
            if (!worker.IsBusy) worker.RunWorkerAsync();
            // Parse
            /*int count = 0;
            Match m = Regex.Match(s, ":([0-9\\.]+)");
            while (m.Success && sensors.Count > count)
            {
                sensors[count].Value = float.Parse(m.Groups[1].ToString(), new CultureInfo("en-US").NumberFormat);
                ActivateSensor(sensors[count]);
                m = m.NextMatch();
                count++;
            }*/
            if (lastOutput.Length > 0)
            {
                string[] s = lastOutput.Split(',');
                for (int i = 0; i < s.Length; i++)
                {                    
                    try
                    {   
                        if (s[i].Length > 0) sensors[i].Value = float.Parse(s[i]) / 100.0f;  // lol convert from . decimal doesnt work well atm
                        // ---- Conversion moved to arduino sketch
                        //float res = 47000f / ((1023f / float.Parse(s[i])) - 1f);
                        //sensors[i].Value = (float?)LookUpResTemp(res/1000f);
                        // ----
                    } catch (Exception)
                    {
                        sensors[i].Value = (float?)0.0;
                    }
                }
            }
            
        }

        public string DisplayText
        {
            get
            {
                return displayText;
            }
            set
            {
                displayText = value;
            }
        }

        public void ToggleDisplay()
        {
            port.Write((char)28+"");
           // skipNext = true;
        }
        public void SetDisplay(bool on)
        {
            if (on)
                port.Write((char)29 + "");
            else
                port.Write((char)30 + "");
            //skipNext = true;
        }

        // NTCM-HP-50K
        // -55 - 100°c
        // Moved to arduino sketch
       /* private float[] resVals =
        {
            4019, 3742, 3487, 3251, 3033, 2832, 2645, 2473, 2313, 2164, 2026, 1898, 1779, 1669, 1566, 1470, 1381,
            1297, 1219, 1147, 1079, 956, 901, 849, 801, 755, 712, 673, 635, 600, 567, 536, 507, 479, 453, 429, 406, 385, 364,
            345, 327, 310, 294, 279, 265, 252, 239, 227, 216, 205, 195, 185, 176, 168, 159, 152, 144, 138, 131, 125, 119, 113,
            108, 103, 98.034f, 94.219f, 89.922f, 85.840f, 81.962f, 78.277f, 74.773f, 71.442f, 68.275f, 65.261f, 62.394f, 59.666f,
            57.069f, 54.597f, 52.242f, 50, 47.863f, 45.827f, 43.886f, 42.037f, 40.273f, 38.590f, 36.986f, 35.455f, 33.99f, 32.599f,
            31.268f, 29.997f, 28.783f, 27.623f, 26.515f, 25.456f, 24.444f, 23.476f, 22.551f, 21.667f, 20.821f, 20.011f, 19.236f,
            18.495f, 17.940f, 17.106f, 16.455f, 15.832f, 15.235f, 14.664f, 14.116f, 13.591f, 13.087f, 12.604f, 12.142f, 11.698f,
            11.272f, 10.864f, 10.472f, 10.095f, 9.734f, 9.388f, 9.055f, 8.735f, 8.428f, 8.133f, 7.850f, 7.577f, 7.316f, 7.064f,
            6.822f, 6.589f, 6.366f, 6.150f, 5.943f, 5.744f, 5.553f, 5.368f, 5.190f, 5.020f, 4.855f, 4.696f, 4.544f, 4.396f, 4.255f,
            4.118f, 3.986f, 3.869f, 3.737f, 3.619f, 3.506f, 3.396f,3.290f, 3.188f, 3.090f

        };


        public float LookUpResTemp(float r)
        {
            for (int i = 0; i < resVals.Length; i++)
            {
                if (resVals[i] < r)
                {
                    if (i > 0)
                    {
                        return (i-55) + ((r - resVals[i]) / (resVals[i] - resVals[i - 1])) * (1);
                    }
                    else
                    {
                        return -55;
                    }
                }
                if (i == resVals.Length - 1) return i-55;
            }
            return 0f;
        }*/

        public bool IsAvailable()
        {
            return connected;            
        }



    }
}
