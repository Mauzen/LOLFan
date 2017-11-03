/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>                          
	
*/

using LOLFan.Hardware;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOLFan.Utilities
{
    class SensorList : List<ISensor>
    {
        public SensorList() : base()
        {

        }

        public SensorList GetFilteredList(SensorType filter)
        {
            SensorList sub = new SensorList();

            foreach (ISensor i in this)
            {
                if ((i.SensorType & filter) > 0)
                {
                    sub.Add(i);
                }
            }

            return sub;
        }


        public void AddSensor(ISensor i)
        {
            this.Add(i);
            SensorAdded.Invoke(i);            
        }

        public void RemoveSensor(ISensor i)
        {
            this.Remove(i);
            SensorRemoved.Invoke(i);
        }

        public ISensor GetByIdentifier(String identifier)
        {
            foreach (ISensor s in this)
            {
                if (s.Identifier.ToString() == identifier)
                {
                    return s;
                }
            }
            return null;
        }

        public ISensor GetByIdentifier(Identifier identifier)
        {
            return GetByIdentifier(identifier.ToString());
        }

        public SensorEventHandler SensorAdded;
        public SensorEventHandler SensorRemoved;
    }
}
