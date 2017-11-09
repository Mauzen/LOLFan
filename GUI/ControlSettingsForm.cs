/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>   

*/

using LOLFan.Collections;
using LOLFan.Hardware;
using LOLFan.Utilities;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LOLFan.GUI
{
    public partial class ControlSettingsForm : Form
    {
        private MainForm parent;
        private PersistentSettings settings;
        private IControl control;

        private FanControlCurve calibration;

        private bool calibrationActive;
        private float curDuty;
        private int curWaitStep;
        private int waitSteps;
        private int curAvgStep;
        private float curAvgSum;
        private int totalSteps;
        private float lastRPM;
        private bool getMax;

        private Plot plot;
        private LineSeries data;

        private float curMax;        

        public ControlSettingsForm(string name, IControl control, MainForm parent, PersistentSettings settings)
        {
            InitializeComponent();

            this.control = control;
            this.parent = parent;
            this.settings = settings;

            this.Text = name;

            if (control.Calibrated == null)
            {
                useCalibrationCheckBox.Enabled = false;
            }
            else
            {
                useCalibrationCheckBox.Checked = control.UseCalibrated;
            }

            fanComboBox.Items.AddRange(SharedData.AllSensors.GetFilteredList(SensorType.Fan).ToArray());
            fanComboBox.SelectedItem = control.Affects;

            if (control.FanUpRates != null)
            {
                upRateComboBox.Items.AddRange(control.FanUpRates);
                upRateComboBox.SelectedIndex = control.FanUpRate;
                upRateComboBox.SelectedIndexChanged += UpRateComboBox_SelectedIndexChanged;
            } else
            {
                upRateComboBox.Enabled = false;
            }
            if (control.FanDownRates != null)
            {
                downRateComboBox.Items.AddRange(control.FanDownRates);
                downRateComboBox.SelectedIndex = control.FanDownRate;
                downRateComboBox.SelectedIndexChanged += DownRateComboBox_SelectedIndexChanged;
            }
            else
            {
                downRateComboBox.Enabled = false;
            }

            parent.SensorUpdate += OnSensorUpdate;

            useCalibrationCheckBox.CheckedChanged += UseCalibrationCheckBox_CheckedChanged;

            this.FormClosing += ControlSettingsForm_FormClosing;


            this.plot = new Plot();
            this.plot.Dock = DockStyle.Fill;
            this.plot.Model = CreatePlotModel();
            this.plot.BackColor = Color.White;            

            this.SuspendLayout();
            splitContainer1.Panel1.Controls.Add(plot);
            this.ResumeLayout(true);


            if (control.Calibrated != null)
            {
                data.Points.Clear();
                foreach (PointF p in control.Calibrated)
                {
                    data.Points.Add(new DataPoint(p.Y, p.X));
                }
                plot.InvalidatePlot(true);                
            }

            new HintsForm(HintsForm.Hints.FanControlSettings);
        }

        private PlotModel CreatePlotModel()
        {
            PlotModel model = new PlotModel() { LegendSymbolLength = 6 };
            // Add a line series
            data = new LineSeries()
            {
                Color = OxyColors.SkyBlue,
                MarkerType = MarkerType.None,
                MarkerSize = 3,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.SkyBlue,
                MarkerStrokeThickness = 1.5,
            };
            //data.
            LinearAxis bot = new LinearAxis(AxisPosition.Left, 0, control.MaxRPM + 100, 300, 100, "RPM");
            LinearAxis left = new LinearAxis(AxisPosition.Bottom, 0, 100, 10, 5, "Fan duty [%]");
           
            bot.MajorGridlineStyle = LineStyle.Dot;
            left.MajorGridlineStyle = LineStyle.Dot;
            bot.IsZoomEnabled = false;
            left.IsZoomEnabled = false;
            model.AutoAdjustPlotMargins = true;
            model.Axes.Add(bot);
            model.Axes.Add(left);
            model.PlotMargins = new OxyThickness(0);
            model.IsLegendVisible = false;
            model.Series.Add(data);
            
            return model;
        }

        private void DownRateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            control.FanDownRate = (byte)downRateComboBox.SelectedIndex;
        }

        private void UpRateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            control.FanUpRate = (byte)upRateComboBox.SelectedIndex;
        }

        private void UseCalibrationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            control.UseCalibrated = useCalibrationCheckBox.Checked;
        }

        private void ControlSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (calibrationActive) StopCalibration(false);

            parent.SensorUpdate -= OnSensorUpdate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (calibrationActive) StopCalibration(false);
            else StartCalibration();
        }

        public void OnSensorUpdate(object sender, EventArgs e)
        {
            if (control.Calibrated != null)
            {
                offsetLabel.Text = "Relative offset: " + ((((control.Calibrated.GetInverse(control.InternalSoftwareValue) - control.Affects.Value.Value) / control.Affects.Value.Value)) * 100.0).ToString("+##0;-##0") + "%";
            }

            if (!calibrationActive) return;

            if (getMax)
            {
                // Wait till fan reached max speed
                if (control.Affects.Value.Value < lastRPM)
                {
                    getMax = false;
                } else
                {
                    lastRPM = control.Affects.Value.Value;
                    return;
                }
            }


            if (waitSteps != 0 && curWaitStep != waitSteps)
            {
                curWaitStep++;                
                return;
            }

            if (curAvgStep == (int) updateAvgUpDown.Value)
            {
                if (curAvgSum == 0)
                {
                    StopCalibration(true);
                    return;
                }

                // Last averaging step
                // Add averaged results
                calibration.AddOrdered(new PointF(curAvgSum / (float)updateAvgUpDown.Value, curDuty));
                //Debug.WriteLine("Step: " + curAvgSum / (float)updateAvgUpDown.Value + "   " + curDuty);
                if (curDuty == 100) curMax = curAvgSum / (float)updateAvgUpDown.Value;
                curAvgSum = 0;
                curAvgStep = 0;

                // Set next duty
                curDuty -= (float)stepSizeUpDown.Value;
                control.SetSoftware(curDuty);
                curWaitStep = 0;
                waitSteps = (int)waitUpDown.Value;

                TimeSpan t = TimeSpan.FromSeconds((totalSteps - ((100f - curDuty) / (float)stepSizeUpDown.Value) * ((float)updateAvgUpDown.Value + (int)waitUpDown.Value))
                    * (SharedData.UpdateRate / 1000f));
                label3.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                    t.Hours,
                    t.Minutes,
                    t.Seconds);
                calibrationProgressBar.Value = (int)(((100f - curDuty) / (float)stepSizeUpDown.Value) * ((float)updateAvgUpDown.Value + (int)waitUpDown.Value));

                return;
            } else
            {
                if (!control.Affects.Value.HasValue || control.Affects.Value.Value == 0 || curDuty <= 0)
                {
                    StopCalibration(true);
                    return;
                }
                curAvgSum += control.Affects.Value.Value;
                curAvgStep++;
                return;
            }
        }

        private void StartCalibration()
        {
            if (calibrationActive || control.Affects == null) StopCalibration(false);

            curDuty = 100f;
            curWaitStep = 0;
            curAvgStep = 0;
            curAvgSum = 0;
            totalSteps = (int)((100f / (float)stepSizeUpDown.Value) * ((float)updateAvgUpDown.Value + (float)waitUpDown.Value));
            TimeSpan t = TimeSpan.FromSeconds(totalSteps * (SharedData.UpdateRate / 1000f));
            label3.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                t.Hours,
                t.Minutes,
                t.Seconds);
            calibrationProgressBar.Maximum = totalSteps;
            calibrationProgressBar.Value = 0;

            calibration = new FanControlCurve(new Identifier(control.Identifier, "calibration_tmp"), settings, false);

            useCalibrationCheckBox.Checked = false;
            curDuty = 100;
            control.SetSoftware(100);
            waitSteps = 0;
            getMax = true;

            stepSizeUpDown.Enabled = false;
            updateAvgUpDown.Enabled = false;
            waitUpDown.Enabled = false;


            button1.Text = "Abort";
            calibrationActive = true;

        }

        private void StopCalibration(bool finished)
        {
            stepSizeUpDown.Enabled = true;
            updateAvgUpDown.Enabled = true;
            waitUpDown.Enabled = true;

            button1.Text = "Calibrate...";
            calibrationActive = false;


            if (finished)
            {
                calibration.Identifier = new Identifier(control.Identifier, "calibration_curve");
                control.Calibrated = calibration;
                control.MaxRPM = curMax;
                useCalibrationCheckBox.Enabled = true;
                calibration.SaveValuesToSettings();
                calibrationProgressBar.Value = totalSteps;

                data.Points.Clear();
                foreach (PointF p in control.Calibrated)
                {
                   data.Points.Add(new DataPoint(p.X, p.Y));
                }
                plot.InvalidatePlot(true);
            } else
            {
                calibrationProgressBar.Value = 0;
            }
        }
    }
}
