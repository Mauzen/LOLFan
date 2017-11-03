/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2009-2011 Michael Möller <mmoeller@openhardwaremonitor.org>
	
*/

namespace LOLFan.Hardware.LPC {
  internal interface ISuperIO {

    Chip Chip { get; }

    // get voltage, temperature, fan and control channel values
    float?[] Voltages { get; }
    float?[] Temperatures { get; }
    float?[] Fans { get; }
    float?[] Controls { get; }

    string[] FAN_RATE_DESCRIPTION { get; }

    // set control value, null = auto    
        void SetControl(int index, byte? value);
        void SetFanUpRate(int index, int rate);
        void SetFanDownRate(int index, int rate);

        // read and write GPIO
        byte? ReadGPIO(int index);
    void WriteGPIO(int index, byte value);

    string GetReport();

    void Update();
  }
}
