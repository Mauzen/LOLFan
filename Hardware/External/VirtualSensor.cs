/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>                          
	
*/

using System;
using System.Collections.Generic;
using System.Text;
using LOLFan.Collections;
using LOLFan.Utilities;

namespace LOLFan.Hardware
{
    class VirtualSensor : Hardware
    {
        private const int MAX_VIRTUAL_SENSORS = 16;

        private ValueString[] valueString = new ValueString[MAX_VIRTUAL_SENSORS];
        
        public VirtualSensor(string name, Identifier identifier, ISettings settings) : base(name, identifier, settings)
        {
            for (int i = 0; i < MAX_VIRTUAL_SENSORS; i++)
            {
                string vs = settings.GetValue(new Identifier(identifier, i + "", "valuestring").ToString(), "");
                if (vs.Length > 0)
                {
                   // valueString[i] = new Utilities.ValueString();
                }

            }
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
            for (int i = 0; i < MAX_VIRTUAL_SENSORS; i++)
            {
                if (valueString[i] != null)
                {

                }
            }
        }
    }
}
