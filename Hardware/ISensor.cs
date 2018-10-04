/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2009-2012 Michael Möller <mmoeller@openhardwaremonitor.org>
    Copyright (C) 2017 Michel Soll <msoll@web.de>                          
	
*/

using System;
using System.Collections.Generic;
using LOLFan.Collections;

namespace LOLFan.Hardware {

    [Flags]
  public enum SensorType {
    Voltage = 1, // V
    Clock = 2, // MHz
    Temperature = 4, // °C
    Load = 8, // %
    Fan = 16, // RPM
    Flow = 32, // L/h
    Control = 64, // %
    Level = 128, // %
    Factor = 256, // 1
    Power = 512, // W
    Data = 1024, // GB = 2^30 Bytes    
    SmallData = 2048, // MB = 2^20 Bytes
    TinyData = 4096, // KB = 2^10 Bytes
    Current = 8192, // A
    KWH = 16384// kWh consumption
  }

  public struct SensorValue {
    private readonly float value;
    private readonly DateTime time;

    public SensorValue(float value, DateTime time) {
      this.value = value;
      this.time = time;
    }

    public float Value { get { return value; }  }
    public DateTime Time { get { return time; } }
  }

  public interface ISensor : IElement {

    IHardware Hardware { get; }

    SensorType SensorType { get; }
    Identifier Identifier { get; }

    string Name { get; set; }
    int Index { get; }

    bool IsDefaultHidden { get; }

    IReadOnlyArray<IParameter> Parameters { get; }

    float? Value { get; set; }
    float? Min { get; }
    float? Max { get; }

    void ResetMin();
    void ResetMax();

    IEnumerable<SensorValue> Values { get; }

    IControl Control { get; }
    ISensor Affector { get; set; }
  }

}
