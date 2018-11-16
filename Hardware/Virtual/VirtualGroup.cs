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

namespace LOLFan.Hardware.Virtual
{
    public class VirtualGroup : IGroup
    {

        private readonly List<IHardware> hardware =
          new List<IHardware>();

        public VirtualGroup(ISettings settings)
        {


        }

        public void Add (IHardware i) {
            hardware.Add(i);
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
