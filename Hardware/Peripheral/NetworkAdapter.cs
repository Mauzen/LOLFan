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
using System.Net.NetworkInformation;

/*
    Adds network interfaces as hardware objects,
    so their traffic can be monitored.
*/

namespace LOLFan.Hardware.Peripheral
{
    public class NetworkAdapter : Hardware
    {
        // private SensorString text;
        private List<ISensor> sensors;
        // private string s = "";
        private double lastUp;
        private double lastDown;
        private NetworkInterface nw;
        // private ISettings settings;
        private double lastTime;

        public NetworkAdapter(string name, NetworkInterface nw, Identifier identifier, ISettings settings) : base(name, identifier, settings)
        {
            this.nw = nw;

            sensors = new List<ISensor>();
            sensors.Add(new Sensor("Download total", 0, SensorType.SmallData, this, settings));
            sensors.Add(new Sensor("Upload total", 1, SensorType.SmallData, this, settings));
            sensors.Add(new Sensor("Download/s", 2, SensorType.TinyData, this, settings));
            sensors.Add(new Sensor("Upload/s", 3, SensorType.TinyData, this, settings));
            foreach (ISensor sen in sensors) ActivateSensor(sen);

            lastDown = nw.GetIPv4Statistics().BytesReceived / 1024.0 / 1024.0;
            lastUp = nw.GetIPv4Statistics().BytesSent / 1024.0 / 1024.0;
            sensors[0].Value = (float) (lastDown);
            sensors[1].Value = (float) (lastUp);
            lastTime = (new TimeSpan(DateTime.Now.Ticks)).TotalSeconds;

        }
        

        public override HardwareType HardwareType
        {
            get
            {
                return HardwareType.Peripheral;
            }
        }

        public override void Update()
        {
            double curTime = (new TimeSpan(DateTime.Now.Ticks)).TotalSeconds;

            sensors[0].Value = (float) (nw.GetIPv4Statistics().BytesReceived / 1024.0 / 1024.0);
            sensors[1].Value = (float) (nw.GetIPv4Statistics().BytesSent / 1024.0 / 1024.0);
            
            if (sensors[0].Value - lastDown > 0)
            {
                sensors[2].Value = (float)(((sensors[0].Value - lastDown) / (curTime - lastTime)) * 1024.0);
            }
            if (sensors[1].Value - lastUp > 0)
            {
                sensors[3].Value = (float)(((sensors[1].Value - lastUp) / (curTime - lastTime)) * 1024.0);
            }

            lastTime = curTime;
            lastDown = (float)sensors[0].Value;
            lastUp = (float)sensors[1].Value;
        }       

        //public bool IsAvailable()
        //{
        //    return connected;
        //}



    }
}
