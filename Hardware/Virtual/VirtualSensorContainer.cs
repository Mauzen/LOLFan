/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2018 Michel Soll <msoll@web.de>                          
	
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

/*

*/

namespace LOLFan.Hardware.Virtual
{
    public class VirtualSensorContainer : Hardware
    {
        int sensorIdx = 0;

        public VirtualSensorContainer(string name, Identifier identifier, ISettings settings) : base(name, identifier, settings)
        {

            // TODO: Load virtual sensors from config
            //sensors.Add(new Sensor("test", 0, SensorType.Power, this, settings));
            //ActivateSensor(sensors[0]);
            int idx = 0;
            if (!int.TryParse(settings.GetValue(new Identifier(identifier, "sensorindex").ToString(), "0"), out idx))
            {
                // Force config entry to mark the container index as used
                settings.SetValue(new Identifier(Identifier, "sensorindex").ToString(), "0");
            }
            sensorIdx = idx;           
            
        }

        public void AddVirtualSensor(IVirtualSensor sensor)
        {
            ActivateSensor(sensor);
        }

        public void RemoveVirtualSensor(IVirtualSensor sensor)
        {
            DeactivateSensor(sensor);
        }

        public override HardwareType HardwareType
        {
            get
            {
                return HardwareType.Virtual;
            }
        }

        public override void Update()
        {
            foreach(IVirtualSensor s in active) {
                s.UpdateValue();
            }
        }

        public int GetNextSensorIndex()
        {
            int idx = sensorIdx;
            sensorIdx++;
            settings.SetValue(new Identifier(Identifier, "sensorindex").ToString(), sensorIdx+"");
            return idx;
        }

        //public bool IsAvailable()
        //{
        //    return connected;
        //}



    }
}
