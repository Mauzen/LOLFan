/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>                          
	
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace LOLFan.Hardware.External
{
    internal class ExternalGroup : IGroup
    {

        private const int MAX_DEVICES = 8;

        private readonly List<IHardware> hardware =
          new List<IHardware>();

        public ExternalGroup(ISettings settings)
        {
            // Check for Tasmota devices in config
            for (int i = 0; i < MAX_DEVICES; i++)
            {
                string address = settings.GetValue(new Identifier("external", "tasmota", i + "", "address").ToString(), "");
                if (address.Length > 0)
                {
                    Tasmota t = new Tasmota("Tasmota " + i, address, new Identifier("external", "tasmota", i + ""), settings);
                    if (t.IsAvailable()) hardware.Add(t);
                }

            }
            // Check for Arduino devices in config
            for (int i = 0; i < MAX_DEVICES; i++)
            {
                string port = settings.GetValue(new Identifier("external", "arduino", i + "", "port").ToString(), "");
                if (port.Length > 0)
                {
                    
                    Arduino t = new Arduino("Arduino " + i,port, new Identifier("external", "arduino", i + ""), settings);
                    if (t.IsAvailable()) hardware.Add(t);
                }

            }

        }

        public IHardware[] Hardware
        {
            get
            {
                return hardware.ToArray();
            }
        }

        public string GetReport()
        {
            return null;
        }

        public void Close()
        {
            foreach (Hardware h in hardware)
                h.Close();
        }
    }
}
