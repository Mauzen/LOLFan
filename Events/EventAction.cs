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

/*
 * Defines actions provided by components or plugins.
 * 
 */

namespace LOLFan.Events
{
    class EventAction
    {
        private Identifier identifier;
        private string name;
        private string description;
        private EventHandler action;

        public EventAction(Identifier identifier, string name)
        {
            this.identifier = identifier;
            this.name = name;
        }
        public EventAction(Identifier identifier, string name, string description)
        {
            this.identifier = identifier;
            this.name = name;
            this.description = description;
        }

        public void Fire(object sender, EventArgs e)
        {
            if (action != null) action.Invoke(sender, e);
        }

        public Identifier Identifier
        {
            get
            {
                return identifier;
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

        public EventHandler Action
        {
            get
            {
                return action;
            }
        }
    }
}
