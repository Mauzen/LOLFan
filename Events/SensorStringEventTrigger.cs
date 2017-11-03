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
using LOLFan.Utilities;

namespace LOLFan.Events
{
    class SensorStringEventTrigger : EventTrigger
    {
        private SensorString value;

        public SensorStringEventTrigger(Identifier identifier, TriggerType type, string name, string description) : base(identifier, type, name, description)
        {
        }
    }
}
