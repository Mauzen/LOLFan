using System;
using System.Collections.Generic;
using System.Text;

namespace LOLFan.Hardware.Virtual
{
    public interface IVirtualSensor : ISensor
    {
        void UpdateValue();
    }
}
