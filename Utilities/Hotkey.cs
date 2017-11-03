/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>                          
	
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace LOLFan.Utilities
{
    public class Hotkey
    {
        private ushort handle;
        private EventHandler action;
        private string description;
        private short modifiers;
        private int key;

        public Hotkey(string description, short modifiers, int key, ushort handle, EventHandler action)
        {
            this.description = description;
            this.modifiers = modifiers;
            this.key = key;
            this.action = action;
            this.handle = handle;
        }

        public EventHandler Action
        {
            get
            {
                return action;
            }
        }

        public ushort Handle
        {
            get
            {
                return handle;
            }
        }
    }
}
