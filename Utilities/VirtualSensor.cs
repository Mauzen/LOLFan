using LOLFan.Hardware.Virtual;
using System;
using System.Collections.Generic;
using System.Text;
using LOLFan.Collections;
using LOLFan.Hardware;
using System.Globalization;

namespace LOLFan.Utilities
{
    public class VirtualSensor : Sensor, IVirtualSensor
    {
        private ValueString val;
        private int skip;
        private int skipCount;

        public VirtualSensor(string name, int index, SensorType sensorType,
           Hardware.Hardware hardware, ISettings settings) : 
            base(name, index, false, sensorType, hardware, null, settings) {



            val = new ValueString(settings.GetValue(new Identifier(Identifier, "valuestring").ToString(), "0"), SharedData.AllSensors);
            SetSensorType (sensorType);
            skip = 0;
            int.TryParse(settings.GetValue(new Identifier(Identifier, "skip").ToString(), "0"), out skip);
            skipCount = skip;   // Force initial update
        }

        public void UpdateValue()
        {
            if (skip > 0 && skipCount++ < skip)
            {
                return;
            } else
            {
                skipCount = 0;
            }
            this.Value = val.Output;
        }

        public String ValueStringInput
        {
            get
            {
                return val.Input;
            }
            set
            {
                if (value != val.Input)
                {
                    val.Input = value;
                    this.settings.SetValue(new Identifier(Identifier, "valuestring").ToString(), value);
                    val.CreateHistory(Values as RingCollection<SensorValue>);
                }
            }
        }

        public int Skip
        {
            get
            {
                return skip;
            }
            set
            {
                skip = value;
                this.settings.SetValue(new Identifier(Identifier, "skip").ToString(), value + "");
            }
        }

        // Override identifiert to ignore sensortype in it
        new public Identifier Identifier
        {
            get
            {
                return new Identifier(Hardware.Identifier,
                  Index.ToString(CultureInfo.InvariantCulture));
            }
        }

        public void SetSensorType(SensorType t)
        {
            this.settings.SetValue(new Identifier(Identifier, "sensortype").ToString(), (int)t+"");
        }

        public void DeleteFromConfig()
        {
            settings.Remove(new Identifier(Identifier, "valuestring").ToString());
            settings.Remove(new Identifier(Identifier, "sensortype").ToString());
            settings.Remove(new Identifier(Identifier, "skip").ToString());
        }
    }
}
