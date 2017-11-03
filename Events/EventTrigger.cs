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

namespace LOLFan.Events
{
    class EventTrigger
    {
        public enum TriggerType
        {
            OnSensorUpdate,
            OnHotkey
        }

        private Identifier identifier;
        private TriggerType type;
        private string name;
        private string description;

        public EventTrigger(Identifier identifier, TriggerType type, string name, string description)
        {
            this.identifier = identifier;
            this.type = type;
            this.name = name;
            this.description = description;
        }

        public bool Check()
        {
            return false;
        }

        public Identifier Identifier
        {
            get
            {
                return identifier;
            }
        }

        public TriggerType Type
        {
            get
            {
                return type;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }
    }
}
