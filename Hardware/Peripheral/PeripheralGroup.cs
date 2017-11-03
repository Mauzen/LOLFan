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
using System.Net.NetworkInformation;
using System.Text;

namespace LOLFan.Hardware.Peripheral
{
    internal class PeripheralGroup : IGroup
    {

        private const int MAX_DEVICES = 8;

        private readonly List<IHardware> hardware =
          new List<IHardware>();

        public PeripheralGroup(ISettings settings)
        {
            NetworkInterface[] interfaces;
            interfaces = NetworkInterface.GetAllNetworkInterfaces();
            for (int i = 0; i < interfaces.Length; i++)
            {
                NetworkAdapter t = new NetworkAdapter(interfaces[i].Name, interfaces[i], new Identifier("peripheral", "network", i + ""), settings);
                hardware.Add(t);
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
