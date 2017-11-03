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
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;

/**
 * Tasmota is a firmware for Itead Sonoff devices.
 * This class supports Tasmota on Sonoff POW power monitoring smart sockets.
 **/

namespace LOLFan.Hardware.External
{
    public class Tasmota : Hardware
    {
        private const byte MAX_RETRIES = 3;

        private string address;
        private List<ISensor> sensors;
        private string s = "";
        private BackgroundWorker worker;
        private long ping;

        public Tasmota(string name, string address, Identifier identifier, ISettings settings) : base(name, identifier, settings)
        {
            sensors = new List<ISensor>();
            sensors.Add(new Sensor("Total", 0, SensorType.KWH, this, settings));
            sensors.Add(new Sensor("Yesterday", 1, SensorType.KWH, this, settings));
            sensors.Add(new Sensor("Today", 2, SensorType.KWH, this, settings));
            sensors.Add(new Sensor("Power", 0, SensorType.Power, this, settings));
            sensors.Add(new Sensor("Factor", 0, SensorType.Factor, this, settings));
            sensors.Add(new Sensor("Voltage", 0, SensorType.Voltage, this, settings));
            sensors.Add(new Sensor("Current", 0, SensorType.Current, this, settings));
            foreach(ISensor sen in sensors) ActivateSensor(sen);

            this.address = address;

            worker = new BackgroundWorker();

            worker.DoWork += (sender, args) => {
                // Delay update to get data right before next update
                Thread.Sleep((int) (int.Parse(settings.GetValue("update_rate", "1000")) - 3 * ping));
                s = new WebClient().DownloadString("http://" + address + "/cm?cmnd=status%208");
            };


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
            if (!worker.IsBusy) worker.RunWorkerAsync();
            // Parse
            int count = 0;
            Match m = Regex.Match(s, ":([0-9\\.]+)");
            while (m.Success && sensors.Count > count)
            {
                sensors[count].Value = float.Parse(m.Groups[1].ToString(), new CultureInfo("en-US").NumberFormat);
                ActivateSensor(sensors[count]);
                m = m.NextMatch();
                count++;
            }
        }

        public bool IsAvailable()
        {
            try
            {
                byte pingCount = 0;                
                while (pingCount++ < MAX_RETRIES)
                {
                    Ping p = new Ping();
                    PingReply r = p.Send(address, 1000);
                    if (r.Status == IPStatus.Success)
                    {
                        ping = r.RoundtripTime;

                        byte count = 0;
                        string s = "";
                        while (count++ < MAX_RETRIES && s.Length == 0)
                        {
                            s = new WebClient().DownloadString("http://" + address + "/cm?cmnd=status%208");
                        }
                        return s.Length > 0;
                    }
                }
            } catch (Exception)
            {
                Console.WriteLine("Tasmota at " + address + " unavailable");
            }
            return false;
        }



    }
}
