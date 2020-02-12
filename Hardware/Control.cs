/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2010-2014 Michael Möller <mmoeller@openhardwaremonitor.org>
    Copyright (C) 2017 Michel Soll <msoll@web.de>                          
	
*/

using LOLFan.Collections;
using System;
using System.Diagnostics;
using System.Globalization;

namespace LOLFan.Hardware {

  internal delegate void ControlEventHandler(Control control);

  internal class Control : IControl {

    private readonly Identifier identifier;
    private readonly ISettings settings;
    private ControlMode mode;
    private float softwareValue;
        private float internalSoftwareValue;
    private float minSoftwareValue;
    private float maxSoftwareValue;
    private byte fanUpRate = 255;
    private byte fanDownRate = 255;
        private string[] fanUpRates;
        private string[] fanDownRates;
        private FanControlCurve calibrated;
        private ISensor affects;
        private bool useCalibrated;
        private float maxRPM;

        public Control(ISensor sensor, ISettings settings, float minSoftwareValue,
      float maxSoftwareValue, ISensor affect=null) 
    {
      this.identifier = new Identifier(sensor.Identifier, "control");
      this.settings = settings;
      this.minSoftwareValue = minSoftwareValue;
      this.maxSoftwareValue = maxSoftwareValue;
      this.affects = affect;
      


      int mode;
      if (!int.TryParse(settings.GetValue(
          new Identifier(identifier, "mode").ToString(),
          ((int)ControlMode.Undefined).ToString(CultureInfo.InvariantCulture)),
        NumberStyles.Integer, CultureInfo.InvariantCulture,
        out mode)) 
      {
        this.mode = ControlMode.Undefined;
      } else {
        this.mode = (ControlMode)mode;
      }

            if (settings.Contains(new Identifier(identifier, "calibration_curve", "values").ToString()))
            {
                calibrated = new FanControlCurve(new Identifier(identifier, "calibration_curve"), settings, false);
                maxRPM = calibrated[calibrated.Count - 1].X;
                Debug.WriteLine("max " + maxRPM);
            }


            byte temp = 0;
            if (!byte.TryParse(settings.GetValue(
                new Identifier(identifier, "uprate").ToString(), "2"),
              NumberStyles.Integer, CultureInfo.InvariantCulture,
              out temp))
            {
                this.FanUpRate = 2;
            } else
            {
                this.FanUpRate = temp;
            }
            if (!byte.TryParse(settings.GetValue(
                new Identifier(identifier, "downrate").ToString(), "2"),
              NumberStyles.Integer, CultureInfo.InvariantCulture,
              out temp))
            {
                this.FanDownRate = 2;
            }
            else
            {
                this.FanDownRate = temp;
            }

            if (!bool.TryParse(settings.GetValue(
                new Identifier(identifier, "use_calibrated").ToString(), "false"),
              out useCalibrated))
            {
                this.useCalibrated = false;
            }

            if (!float.TryParse(settings.GetValue(
                new Identifier(identifier, "value").ToString(), "0"),
                    NumberStyles.Float, CultureInfo.InvariantCulture,
                    out this.internalSoftwareValue))
            {
                this.internalSoftwareValue = 0;
            }
            if (internalSoftwareValue < 0) internalSoftwareValue = 0;
            if (internalSoftwareValue > 100) internalSoftwareValue = 100;
            this.SoftwareValue = internalSoftwareValue;

        }

        

        public Identifier Identifier {
      get {
        return identifier;
      }
    }

    public ControlMode ControlMode {
      get {
        return mode;
      }
      private set {
        if (mode != value) {
          mode = value;
          if (ControlModeChanged != null)
            ControlModeChanged(this);
          this.settings.SetValue(new Identifier(identifier, "mode").ToString(),
            ((int)mode).ToString(CultureInfo.InvariantCulture));
        }
      }
    }

    public float SoftwareValue {
      get {
        return softwareValue;
      }
      private set {
                if (useCalibrated)
                {
                    internalSoftwareValue = (value < 100) ? (calibrated.Get(value / 100f * maxRPM, true)) : (100);
                    if (internalSoftwareValue < 0) internalSoftwareValue = 0;
                    if (internalSoftwareValue > 100) internalSoftwareValue = 100;
                } else
                {
                    internalSoftwareValue = value;
                }
                //Debug.WriteLine("sv " + value + " " + internalSoftwareValue);
        if (softwareValue != value) {
          softwareValue = value;
          if (SoftwareControlValueChanged != null)
            SoftwareControlValueChanged(this);
          this.settings.SetValue(new Identifier(identifier,
            "value").ToString(),
            value.ToString(CultureInfo.InvariantCulture));
        }
      }
    }

    public byte FanUpRate
        {
            get
            {
                return fanUpRate;
            }
            set
            {
                if (value < 0 || value >= 4) return;
                if (fanUpRate != value)
                {
                    fanUpRate = value;
                    FanUpRateChanged?.Invoke(this);
                    this.settings.SetValue(new Identifier(identifier,
                          "uprate").ToString(),
                          value.ToString(CultureInfo.InvariantCulture));
                }
            }
        }
    public byte FanDownRate
        {
            get
            {
                return fanDownRate;
            }
            set
            {
                if (value < 0 || value >= 4) return;
                if (fanDownRate != value)
                {
                    fanDownRate = value;
                    FanDownRateChanged?.Invoke(this);
                    this.settings.SetValue(new Identifier(identifier,
                          "downrate").ToString(),
                          value.ToString(CultureInfo.InvariantCulture));
                }
            }
        }

        public string[] FanUpRates
        {
            get
            {
                return fanUpRates;
            }
            set
            {
                this.fanUpRates = value;
            }
        }
        public string[] FanDownRates
        {
            get
            {
                return fanDownRates;
            }
            set
            {
                this.fanDownRates = value;
            }
        }

        public float InternalSoftwareValue
        {
            get
            {
                return internalSoftwareValue;
            }
            set
            {
                internalSoftwareValue = value;
            }
        }

        public void SetDefault() {
      ControlMode = ControlMode.Default;
    }

    public float MinSoftwareValue {
      get {
        return minSoftwareValue;
      }
    }

    public float MaxSoftwareValue {
      get {
        return maxSoftwareValue;
      }
    }

        public ISensor Affects
        {
            get
            {
                return affects;
            }
            set
            {
                affects = value;
            }
        }

        public FanControlCurve Calibrated
        {
            get
            {
                return calibrated;
            }

            set
            {
                calibrated = value;
            }
        }

        public bool UseCalibrated
        {
            get
            {
                return useCalibrated;
            }

            set
            {
                useCalibrated = value;
                this.settings.SetValue(new Identifier(identifier,
                          "use_calibrated").ToString(),
                          useCalibrated.ToString(CultureInfo.InvariantCulture));
            }
        }

        public float MaxRPM
        {
            get
            {
                return maxRPM;
            }

            set
            {
                maxRPM = value;
            }
        }

        public void SetSoftware(float value) {
            if (value < 0) value = 0;
            ControlMode = ControlMode.Software;
            SoftwareValue = value;
    }



    internal event ControlEventHandler ControlModeChanged;
    public event ControlEventHandler SoftwareControlValueChanged;
    internal event ControlEventHandler FanUpRateChanged;
    internal event ControlEventHandler FanDownRateChanged;
    }
}
