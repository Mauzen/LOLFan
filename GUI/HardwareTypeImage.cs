﻿/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2009-2012 Michael Möller <mmoeller@openhardwaremonitor.org>
    Copyright (C) 2017 Michel Soll <msoll@web.de>   

*/

using System;
using System.Drawing;
using System.Collections.Generic;
using LOLFan.Hardware;

namespace LOLFan.GUI {
  public class HardwareTypeImage {
    private static HardwareTypeImage instance = new HardwareTypeImage();

    private IDictionary<HardwareType, Image> images = 
      new Dictionary<HardwareType, Image>();

    private HardwareTypeImage() { }

    public static HardwareTypeImage Instance {
      get { return instance; }
    }

    public Image GetImage(HardwareType hardwareType) {
      Image image;
      if (images.TryGetValue(hardwareType, out image)) {
        return image;
      } else {
        switch (hardwareType) {
          case HardwareType.CPU:
            image = Utilities.EmbeddedResources.GetImage("cpu.png");
            break;
          case HardwareType.GpuNvidia:
            image = Utilities.EmbeddedResources.GetImage("nvidia.png");
            break;
          case HardwareType.GpuAti:
            image = Utilities.EmbeddedResources.GetImage("ati.png");
            break;
          case HardwareType.HDD:
            image = Utilities.EmbeddedResources.GetImage("hdd.png");
            break;
          case HardwareType.Heatmaster:
            image = Utilities.EmbeddedResources.GetImage("bigng.png");
            break;
          case HardwareType.Mainboard:
            image = Utilities.EmbeddedResources.GetImage("mainboard.png");
            break;
          case HardwareType.SuperIO:
            image = Utilities.EmbeddedResources.GetImage("chip.png");
            break;
          case HardwareType.TBalancer:
            image = Utilities.EmbeddedResources.GetImage("bigng.png");
            break;
          case HardwareType.RAM:
            image = Utilities.EmbeddedResources.GetImage("ram.png");
            break;
          case HardwareType.External:
            image = Utilities.EmbeddedResources.GetImage("chip.png");
            break;
          case HardwareType.Peripheral:
            image = Utilities.EmbeddedResources.GetImage("bigng.png");
            break;
          default:
            image = new Bitmap(1, 1);
            break;
        }
        images.Add(hardwareType, image);
        return image;
      }
    }
  }
}
