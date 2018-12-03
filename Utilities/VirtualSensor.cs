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

        public VirtualSensor(string name, int index, SensorType sensorType,
           Hardware.Hardware hardware, ISettings settings) : 
            base(name, index, false, sensorType, hardware, null, settings) {



            val = new ValueString(settings.GetValue(new Identifier(Identifier, "valuestring").ToString(), "0"), SharedData.AllSensors);
            SetSensorType (sensorType);
        }

        public void UpdateValue()
        {
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
        }
    }
}
