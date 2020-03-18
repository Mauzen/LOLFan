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
            List<NetworkInterface> filter = new List<NetworkInterface>();            

            foreach (NetworkInterface i in interfaces)
            {
                // Ignore loopback interface and down adapters (maybe undo this to include unconnected wlan)
                if (i.NetworkInterfaceType == NetworkInterfaceType.Loopback) continue;
                if (i.OperationalStatus == OperationalStatus.Down) continue;                
                filter.Add(i);
            }
            // Sort by names to get constant IDs
            filter.Sort(CompareInterfacesByName);
            interfaces = filter.ToArray();
            for (int i = 0; i < interfaces.Length; i++)
            {
                NetworkAdapter t = new NetworkAdapter(interfaces[i].Name, interfaces[i], new Identifier("peripheral", "network", i + ""), settings);
                hardware.Add(t);
            }

        }

        private static int CompareInterfacesByName(NetworkInterface x, NetworkInterface y)
        {
            return String.Compare(x.Name, y.Name);
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
