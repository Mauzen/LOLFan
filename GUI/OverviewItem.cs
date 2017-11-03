/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>   

*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using LOLFan.Hardware;
using System.Drawing;
using System.Reflection;

namespace LOLFan.GUI
{
    public abstract class OverviewItem : Panel
    {
        protected SensorNode sensorNode;
        protected Label nameLabel;
        protected Label valueLabel;

        public OverviewItem(SensorNode sens)
        {
            this.sensorNode = sens;
            this.nameLabel = new Label();
            this.nameLabel.Text = sensorNode.Sensor.Name;
            this.valueLabel = new Label();
            this.valueLabel.Text = sensorNode.ValueToString(sensorNode.Sensor.Value);
         
        }

        public SensorNode SensorNode
        {
            get { return sensorNode; }
        }

        public abstract void UpdateAll();

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }

    class TemperatureOverviewItem : OverviewItem
    {

        //private ProgressBar bar;

        public TemperatureOverviewItem(SensorNode sens) : base(sens)
        {
            this.Controls.Add(nameLabel);
            nameLabel.Location = new Point(0, 0);
            nameLabel.AutoSize = true;

            this.Controls.Add(valueLabel);
            valueLabel.Location = new Point(100, 0);
            valueLabel.AutoSize = true;
            valueLabel.Font = new Font(FontFamily.GenericMonospace, 10);
            valueLabel.BackColor = Color.Black;
            valueLabel.ForeColor = Color.LightGreen;

            // Progress bar Damelei
            /*bar = new ProgressBar();
            

            this.Controls.Add(bar);
            bar.Location = new Point(170, 3);
            bar.Height = 10;
            bar.Width = 150;*/

            this.Height = 17;
            //this.Width = 340;
            this.Width = 250;
        }

        override
        public void UpdateAll()
        {
            this.nameLabel.Text = sensorNode.Sensor.Name;
            this.valueLabel.Text = " " + sensorNode.ValueToString(sensorNode.Sensor.Value);

            int des = 0;
            int crit = 0;

            foreach (IParameter i in sensorNode.Sensor.Parameters)
            {
                if (i.Name.Contains("Desired")) des = (int)i.Value;
                if (i.Name.Contains("Critical")) crit = (int)i.Value;
            }

            if (des == 0 || crit == 0) return;

            if (sensorNode.Sensor.Value < des + 5) valueLabel.ForeColor = Color.LightGreen;
            else if (sensorNode.Sensor.Value < crit) valueLabel.ForeColor = Color.Yellow;
            else valueLabel.ForeColor = Color.Red;

            //bar.Minimum = (int)(sensorNode.Sensor.Min != null ? sensorNode.Sensor.Min : 0);
            //bar.Maximum = (int)(sensorNode.Sensor.Max != null ? sensorNode.Sensor.Max : 100);
            //bar.Value = (int)(sensorNode.Sensor.Value != null ? sensorNode.Sensor.Value : sensorNode.Sensor.Min);
        }
    }

    class FanOverviewItem : OverviewItem
    {
        NumericUpDown controller = new NumericUpDown();

        public FanOverviewItem(SensorNode sens) : base(sens)
        {
            this.Controls.Add(nameLabel);
            nameLabel.Location = new Point(0, 3);
            nameLabel.AutoSize = true;

            this.Controls.Add(valueLabel);
            valueLabel.Location = new Point(100, 3);
            valueLabel.AutoSize = true;
            valueLabel.Font = new Font(FontFamily.GenericMonospace, 10);
            valueLabel.BackColor = Color.Black;
            valueLabel.ForeColor = Color.LightGreen;


            if (sens.Sensor.Affector != null)
            {
                controller.Minimum = 0;
                controller.Maximum = 100;
                if (sens.Sensor.Affector.Value.HasValue)
                {
                    controller.Value = (sens.Sensor.Affector.Control.UseCalibrated)
                        ? ((int)(sens.Sensor.Affector.Control.Calibrated.Get(sens.Sensor.Affector.Value.Value / 100f * sens.Sensor.Affector.Control.MaxRPM)))
                        : ((int)(sens.Sensor.Affector.Value));
                }
                this.Controls.Add(controller);
                controller.Location = new Point(180, 0);
                controller.Width = 50;
                controller.ValueChanged += new System.EventHandler(this.controller_ValueChanged);

            }


            this.Height = 20;
            this.Width = 250;
        }

        override
        public void UpdateAll()
        {
            this.nameLabel.Text = sensorNode.Sensor.Name;
            this.valueLabel.Text = string.Format("{0,4:###} RPM", ((int)sensorNode.Sensor.Value));
            IControl c = sensorNode.Sensor.Affector.Control;
            if (!controller.Focused && c != null)
            {
                if (c.UseCalibrated)
                {
                    if (sensorNode.Sensor.Affector.Control.InternalSoftwareValue == 100)
                    {
                        SetNumericUpDownValue(controller, (decimal)100);
                    } else
                    {
                        SetNumericUpDownValue(controller, (decimal)(sensorNode.Sensor.Affector.Value.HasValue ? c.Calibrated.GetInverse(sensorNode.Sensor.Affector.Control.InternalSoftwareValue, true) / c.MaxRPM * 100.0 : 0));
                    }
                    
                }
                else
                {
                    SetNumericUpDownValue(controller, (decimal)(sensorNode.Sensor.Affector.Value.HasValue ? sensorNode.Sensor.Affector.Value.Value : 0));
                }
                //if (!c.UseCalibrated) controller.Value = (decimal)(sensorNode.Sensor.Affector.Value.HasValue ? sensorNode.Sensor.Affector.Value.Value : 0);
                //controller.Value = (c.UseCalibrated)
                //    ? ((int)(c.Calibrated.Get(sensorNode.Sensor.Affector.Value.Value / 100f * c.MaxRPM)))
                //    : ((int)(sensorNode.Sensor.Affector.Value));
            }
        }

        // @see https://stackoverflow.com/questions/39063642/update-value-of-the-numericupdown-control-without-raising-of-valuechanged-event
        private void SetNumericUpDownValue(NumericUpDown control, decimal value)
        {
            if (control == null) throw new ArgumentNullException(nameof(control));
            var currentValueField = control.GetType().GetField("currentValue", BindingFlags.Instance | BindingFlags.NonPublic);
            if (currentValueField != null)
            {
                currentValueField.SetValue(control, value);
                control.Text = value.ToString();
            }
        }

        private void controller_ValueChanged(object sender, EventArgs e)
        {
            if (sensorNode.Sensor.Affector.Control.ControlMode != ControlMode.Default)
            {
                sensorNode.Sensor.Affector.Control.SetSoftware((float)controller.Value);
            }
                
        }
    }

    class OtherOverviewItem : OverviewItem
    {

        //private ProgressBar bar;

        public OtherOverviewItem(SensorNode sens) : base(sens)
        {
            this.Controls.Add(nameLabel);
            nameLabel.Location = new Point(0, 0);
            nameLabel.AutoSize = true;

            this.Controls.Add(valueLabel);
            valueLabel.Location = new Point(100, 0);
            valueLabel.AutoSize = true;
            valueLabel.Font = new Font(FontFamily.GenericMonospace, 10);
            valueLabel.BackColor = Color.Black;
            valueLabel.ForeColor = Color.LightGreen;

            // Progress bar Damelei
            /*bar = new ProgressBar();
            

            this.Controls.Add(bar);
            bar.Location = new Point(170, 3);
            bar.Height = 10;
            bar.Width = 150;*/

            this.Height = 17;
            //this.Width = 340;
            this.Width = 250;
        }

        override
        public void UpdateAll()
        {
            this.nameLabel.Text = sensorNode.Sensor.Name;
            this.valueLabel.Text = " " + sensorNode.ValueToString(sensorNode.Sensor.Value);

            /*int des = 0;
            int crit = 0;

            foreach (IParameter i in sensorNode.Sensor.Parameters)
            {
                if (i.Name.Contains("Desired")) des = (int)i.Value;
                if (i.Name.Contains("Critical")) crit = (int)i.Value;
            }

            if (des == 0 || crit == 0) return;

            if (sensorNode.Sensor.Value < des + 5) valueLabel.ForeColor = Color.LightGreen;
            else if (sensorNode.Sensor.Value < crit) valueLabel.ForeColor = Color.Yellow;
            else valueLabel.ForeColor = Color.Red;

            //bar.Minimum = (int)(sensorNode.Sensor.Min != null ? sensorNode.Sensor.Min : 0);
            //bar.Maximum = (int)(sensorNode.Sensor.Max != null ? sensorNode.Sensor.Max : 100);
            //bar.Value = (int)(sensorNode.Sensor.Value != null ? sensorNode.Sensor.Value : sensorNode.Sensor.Min);*/
        }
    }

}
