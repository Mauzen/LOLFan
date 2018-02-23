/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>                          
	
*/

using NCalc;
using LOLFan.Collections;
using LOLFan.GUI;
using LOLFan.Hardware;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LOLFan.Utilities
{
    public class FanController
    {
        public enum InputSource
        {
            Sensor,
            ValueString
        }

        private Identifier identifier;
        private bool enabled;
        private bool success;   // Determines if valuestring parsing worked
        private FanControlCurve curve;
        private byte id;

        private List<ISensor> sensors;
        private PersistentSettings settings;
        private IControl controlled;

        private InputSource source;
        private ValueString value;
        private ISensor sourceSensor;
        private float lastValue;

        private float hysteresis;
        private float lastAppliedValue;

        private bool tryRestart;
        private bool overrideHysteresis;

        private string name;

        private FanControlForm controlForm;

        public event EventHandler enabledChanged;
        public event EventHandler valueChanged;
        public event EventHandler NameChanged;
        public event EventHandler ControlChanged;

        public FanController(byte id, List<ISensor> sensors, PersistentSettings settings)
        {
            this.id = id;
            this.sensors = sensors;
            this.settings = settings;

            identifier = new Identifier("FanController", id + "");
            

            if (!settings.Contains(new Identifier(identifier, "name").ToString()))
            {
                // Create new instsance
                Name = "FanController " + id;
                value = new ValueString("", sensors);

                // Select the first IControl available
                foreach (ISensor s in sensors)
                {
                    if (s.Control == null) continue;
                    else
                    {
                        Controlled = s.Control;
                        break;
                    }
                }
                sourceSensor = sensors[0];
            } else
            {
                // Load instance
                name = settings.GetValue(new Identifier(identifier, "name").ToString(), "FanController " + id);
                value = new ValueString(settings.GetValue(new Identifier(identifier, "valueString").ToString(), "0"), sensors);

                string c = settings.GetValue(new Identifier(identifier, "controlled").ToString(), null);
                foreach (ISensor s in sensors)
                {
                    if (s.Control == null) continue;
                    if (s.Control.Identifier.ToString() == c)
                    {
                        controlled = s.Control;
                        break;
                    }
                }
            }

            if (controlled == null) throw new Exception("No supported fan control found");

            curve = new FanControlCurve(new Identifier(identifier, "curve"), settings);
            enabled = bool.Parse(settings.GetValue(new Identifier(identifier, "enabled").ToString(), "false"));
            hysteresis = float.Parse(settings.GetValue(new Identifier(identifier, "hysteresis").ToString(), "1").Replace('.', ','));
            sourceSensor = SharedData.AllSensors.GetByIdentifier(settings.GetValue(new Identifier(identifier, "sourceSensor").ToString(), "0"));
            if (sourceSensor == null) sourceSensor = sensors[0];
            source = (InputSource)int.Parse(settings.GetValue(new Identifier(identifier, "inputSource").ToString(), "0"));
            tryRestart = bool.Parse(settings.GetValue(new Identifier(identifier, "tryRestart").ToString(), "true"));

        }

        public void Update()
        {
            success = true;
            if (!enabled) return;
            
            // Check if fan is not spinning, but should
            if (tryRestart && controlled.Affects.Value == 0 && controlled.InternalSoftwareValue > 0)
            {
                // Give a startup boost
                controlled.SetSoftware(100);
                // Override hysteresis
                overrideHysteresis = true;
                return;
            }            

            switch (source)
            {
                case InputSource.Sensor:
                    if (!sourceSensor.Value.HasValue) return;

                    lastValue = sourceSensor.Value.Value;
                    if (Math.Abs(lastValue - lastAppliedValue) >= hysteresis || overrideHysteresis)
                    {
                        controlled.SetSoftware(curve.Get(lastValue));
                        lastAppliedValue = lastValue;
                    }
                    if (valueChanged != null) valueChanged.Invoke(this, null);
                    break;

                case InputSource.ValueString:
                    if (value.Output == 0) return;

                    float curValue = value.Output;
                    if (lastValue == curValue && !overrideHysteresis) return;

                    lastValue = curValue;

                        if (Math.Abs(lastValue - lastAppliedValue) >= hysteresis || overrideHysteresis)
                        {
                            controlled.SetSoftware(curve.Get(lastValue));
                            lastAppliedValue = lastValue;
                        }
                        if (valueChanged != null) valueChanged.Invoke(this, null);
                  
                    break;
            }

            overrideHysteresis = false;

            return;
        }

        public void ShowForm()
        {
            if (controlForm != null && controlForm.Visible)
            {
                controlForm.Focus();
                return;
            }
            
            controlForm = new FanControlForm(sensors, this, settings);
            controlForm.Show();
        }
        public void CloseForm()
        {
            if (controlForm == null || !controlForm.Visible) return;
            controlForm.Hide();
            controlForm.Dispose();
            controlForm = null;
        }

        public void SaveToSettings()
        {
            curve.SaveValuesToSettings();

            settings.SetValue(new Identifier(identifier, "valueString").ToString(), value.Input);
            settings.SetValue(new Identifier(identifier, "enabled").ToString(), enabled + "");
            settings.SetValue(new Identifier(identifier, "controlled").ToString(), controlled.Identifier.ToString());
            settings.SetValue(new Identifier(identifier, "name").ToString(), name);
            settings.SetValue(new Identifier(identifier, "hysteresis").ToString(), hysteresis);
            settings.SetValue(new Identifier(identifier, "inputSource").ToString(), (int)source);
            settings.SetValue(new Identifier(identifier, "sourceSensor").ToString(), sourceSensor.Identifier.ToString());
            settings.SetValue(new Identifier(identifier, "tryRestart").ToString(), tryRestart);
        }

        public void DeleteFromSettings()
        {
            settings.Remove(new Identifier(identifier, "name").ToString());
            settings.Remove(new Identifier(identifier, "controlled").ToString());
            settings.Remove(new Identifier(identifier, "enabled").ToString());
            settings.Remove(new Identifier(identifier, "valueString").ToString());
            settings.Remove(new Identifier(identifier, "hysteresis").ToString());
            settings.Remove(new Identifier(identifier, "curve", "values").ToString());
            settings.Remove(new Identifier(identifier, "sourceSensor").ToString());
            settings.Remove(new Identifier(identifier, "inputSource").ToString());
        }

        public Identifier Identifier
        {
            get
            {
                return identifier;
            }
        }

        public byte ID
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
                identifier = new Identifier("FanController", id + "");
                curve.Identifier = new Identifier(identifier, "curve");
            }
        }

        public bool Success
        {
            get
            {
                return success;
            }
        }

        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                if (enabled != value)
                {
                    enabled = value;
                    lastAppliedValue = float.PositiveInfinity;
                    if (enabledChanged != null) enabledChanged.Invoke(this, null);
                    settings.SetValue(new Identifier(identifier, "enabled").ToString(), enabled + "");

                }
            }
        }

        public ValueString ValueString
        {
            get
            {
                return value;
            }
        }

        public IControl Controlled
        {
            get
            {
                return controlled;
            }
            set
            {
                if (controlled != value)
                {
                    controlled = value;
                    if (ControlChanged != null) ControlChanged.Invoke(this, null);
                    settings.SetValue(new Identifier(identifier, "controlled").ToString(), controlled.Identifier.ToString());
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    if (NameChanged != null) NameChanged.Invoke(this, null);
                    settings.SetValue(new Identifier(identifier, "name").ToString(), name);
                }
            }
        }

        public FanControlCurve Curve
        {
            get
            {
                return curve;
            }
        }

        public float LastValue
        {
            get
            {
                return lastValue;
            }
        }

        public float Hysteresis
        {
            get
            {
                return hysteresis;
            }
            set
            {
                if (value != hysteresis)
                {
                    hysteresis = value;
                    settings.SetValue(new Identifier(identifier, "hysteresis").ToString(), hysteresis);
                }
            }
        }

        public bool OverrideHysteresis
        {
            get
            {
                return overrideHysteresis;
            }
            set
            {
                overrideHysteresis = value;
            }
        }

        public InputSource Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
                settings.SetValue(new Identifier(identifier, "inputSource").ToString(), (int)source);
            }
        }

        public ISensor SourceSensor
        {
            get
            {
                return sourceSensor;
            }
            set
            {
                sourceSensor = value;
                settings.SetValue(new Identifier(identifier, "sourceSensor").ToString(), sourceSensor.Identifier.ToString());
            }
        }

        public float LastAppliedValue
        {
            get
            {
                return lastAppliedValue;
            }
        }

        public bool TryRestart
        {
            get
            {
                return tryRestart;
            }
            set
            {
                if (value != tryRestart)
                {
                    tryRestart = value;
                    settings.SetValue(new Identifier(identifier, "tryRestart").ToString(), tryRestart);
                }
            }
        }
    }

}
