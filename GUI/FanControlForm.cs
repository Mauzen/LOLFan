/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>   

*/

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
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LOLFan.GUI
{
    public partial class FanControlForm : Form
    {

        private readonly PersistentSettings settings;

        private readonly Plot plot;
        private readonly PlotModel model;
        private readonly TimeSpanAxis timeAxis = new TimeSpanAxis();
        private readonly SortedDictionary<SensorType, LinearAxis> axes =
          new SortedDictionary<SensorType, LinearAxis>();

        private int maxY = 100;
        private int minY = 0;

        private LinearAxis bot;
        private LinearAxis left;
        private LinearAxis right;

        private FanController control;

        private LineSeries data;

        private List<IControl> controllers;

        private Label plotLabel;

        public FanControlForm(List<ISensor> sensors, FanController control, PersistentSettings settings)
        {
            this.settings = settings;
            this.control = control;
            InitializeComponent();

            this.Text = control.Name;

            model = CreatePlotModel();

            this.plot = new Plot();
            this.plot.Dock = DockStyle.Fill;
            this.plot.Model = model;
            this.plot.BackColor = Color.White;
            //this.plot.ContextMenu = CreateMenu();

            this.SuspendLayout();
            splitContainer2.Panel1.Controls.Add(plot);
            this.ResumeLayout(true);

            this.controllers = new List<IControl>();

            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.ShowInTaskbar = false;

            this.plotLabel = new Label();
            plotLabel.Text = "3434";
            plotLabel.BackColor = Color.Transparent;
            plotLabel.AutoSize = true;
            plotLabel.Visible = false;            
            plot.Controls.Add(plotLabel);

            valueTextBox.Text = control.ValueString.Input;

            control.valueChanged += ControllerValueChanged;

            hysteresisUpDown1.Value = new decimal(control.Hysteresis);

            this.FormClosing += delegate
            {
                //control.SaveToSettings();
                control.valueChanged -= ControllerValueChanged;
            };

            foreach (ISensor s in sensors)
            {
                if (s.Control != null)
                {
                    controllers.Add(s.Control);
                    controllerComboBox.Items.Add(s.Name);
                    if (s.Control == control.Controlled) controllerComboBox.SelectedIndex = controllerComboBox.Items.Count - 1;
                }
            }

            enabledCheckbox.Checked = control.Enabled;

            nameTextBox.Text = control.Name;

            minUpDown.Value = (decimal)control.Curve.Min;
            maxUpDown.Value = (decimal)control.Curve.Max;

            sourceSensorComboBox.Items.AddRange(sensors.ToArray());
            sourceSensorComboBox.SelectedItem = control.SourceSensor;

            if (control.Source == FanController.InputSource.Sensor)
            {
                valueTextBox.Enabled = false;
                tempModeButton.Checked = true;
            } else if (control.Source == FanController.InputSource.ValueString)
            {
                sourceSensorComboBox.Enabled = false;
                valueModeButton.Checked = true;
            }

            tryRestartBox.Checked = control.TryRestart;


            this.controllerComboBox.SelectedIndexChanged += new System.EventHandler(this.controllerComboBox_SelectedIndexChanged);
            this.enabledCheckbox.CheckedChanged += new System.EventHandler(this.enabledCheckbox_CheckedChanged);
            this.valueTextBox.TextChanged += new System.EventHandler(this.valueTextBox_TextChanged);
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            this.hysteresisUpDown1.ValueChanged += new System.EventHandler(this.hysteresisUpDown1_ValueChanged);
            this.minUpDown.ValueChanged += new System.EventHandler(this.minMaxChanged);
            this.maxUpDown.ValueChanged += new System.EventHandler(this.minMaxChanged);
            this.valueModeButton.CheckedChanged += new System.EventHandler(this.valueModeButton_CheckedChanged);
            this.tempModeButton.CheckedChanged += new System.EventHandler(this.tempModeButton_CheckedChanged);
            this.tryRestartBox.CheckedChanged += new System.EventHandler(this.tryRestartBox_CheckedChanged);

            control.enabledChanged += controller_enabledChanged;

            // Initial update
            UpdateCurveTracker();

            new HintsForm(HintsForm.Hints.FanController);
        }

       
        public void InvalidatePlot()
        {
            data.Points.Clear();
            for (int i = 0; i < control.Curve.Count; i++)
            {
                data.Points.Add(new DataPoint(control.Curve[i].X, control.Curve[i].Y));
            }
            bot.Minimum = control.Curve.Min;
            bot.Maximum = control.Curve.Max;
            this.plot.InvalidatePlot(true);
        }


        public PlotModel CreatePlotModel()
        {
            var model = new PlotModel() { LegendSymbolLength = 6 };
            // Add a line series
            data = new LineSeries()
            {
                Color = OxyColors.SkyBlue,
                MarkerType = MarkerType.Square,
                MarkerSize = 5,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.SkyBlue,
                MarkerStrokeThickness = 1.5,
            };
            //data.
            bot = new LinearAxis(AxisPosition.Bottom, control.Curve.Min, control.Curve.Max, 5, 1, "Value");
            left = new LinearAxis(AxisPosition.Left, minY - 1, maxY + 1, 10, 5, "Fan duty");
            bot.MajorGridlineStyle = LineStyle.Dot;
            left.MajorGridlineStyle = LineStyle.Dot;
            bot.IsZoomEnabled = false;
            left.IsZoomEnabled = false;
            model.Axes.Add(bot);
            model.Axes.Add(left);
            model.PlotMargins = new OxyThickness(0);
            model.IsLegendVisible = false;

            if (control.Controlled.UseCalibrated)
            {
                right = new LinearAxis(AxisPosition.Right, 0, control.Controlled.MaxRPM, 300, 100, "RPM");
                model.Axes.Add(right);
            }
            //series.Points.
            for (int i = 0; i < control.Curve.Count; i++)
            {
                data.Points.Add(new DataPoint(control.Curve[i].X, control.Curve[i].Y));
            }
            model.Series.Add(data);

            int indexOfPointToMove = -1;

            // Subscribe to the mouse down event on the line series
            data.MouseDown += (s, e) =>
            {
                // only handle the left mouse button (right button can still be used to pan)
                if (e.ChangedButton == OxyMouseButton.Left)
                {
                    int indexOfNearestPoint = (int)Math.Round(e.HitTestResult.Index);
                    var nearestPoint = data.Transform(data.Points[indexOfNearestPoint]);

                    // Check if we are near a point
                    if ((nearestPoint - e.Position).Length < 10)
                    {
                        // Start editing this point
                        indexOfPointToMove = indexOfNearestPoint;

                        // Show tracker label
                        UpdatePlotTracker(e, data.Points[indexOfPointToMove].X, data.Points[indexOfPointToMove].Y);
                        plotLabel.Visible = true;
                    }
                    else
                    {
                        // otherwise create a point on the current line segment
                        int i = (int)e.HitTestResult.Index + 1;
                        data.Points.Insert(i, data.InverseTransform(e.Position));
                        indexOfPointToMove = i;
                        //control.Curve.AddOrdered(new PointF((float)data.Points[i].X, (float)data.Points[i].Y));
                        control.Curve.Insert(i, new PointF((float)data.Points[i].X, (float)data.Points[i].Y));

                        // Show tracker label
                        UpdatePlotTracker(e, data.Points[i].X, data.Points[i].Y);
                        plotLabel.Visible = true;
                    }

                    // Change the linestyle while editing
                    data.LineStyle = LineStyle.DashDot;
                    UpdateCurveTracker();
                    // Remember to refresh/invalidate of the plot
                    model.RefreshPlot(false);

                    control.OverrideHysteresis = true;
                    // Set the event arguments to handled - no other handlers will be called.
                    e.Handled = true;
                } else
                if (e.ChangedButton == OxyMouseButton.Right)
                {
                    if (data.Points.Count == 1)
                    {
                        // Cant remove the last point
                        e.Handled = true;
                        return;
                    }

                    int indexOfNearestPoint = (int)Math.Round(e.HitTestResult.Index);
                    var nearestPoint = data.Transform(data.Points[indexOfNearestPoint]);

                    // Check if we are near a point
                    if ((nearestPoint - e.Position).Length < 10)
                    {
                        data.Points.Remove(data.Points[indexOfNearestPoint]);
                        control.Curve.RemoveAt(indexOfNearestPoint);

                        // Change the linestyle while editing
                        data.LineStyle = LineStyle.DashDot;
                        UpdateCurveTracker();
                        // Remember to refresh/invalidate of the plot
                        model.RefreshPlot(false);

                        control.OverrideHysteresis = true;
                        // Set the event arguments to handled - no other handlers will be called.
                        e.Handled = true;
                    }

                    
                }
                
            };

            data.MouseMove += (s, e) =>
            {
                if (indexOfPointToMove >= 0)
                {
                    // Move the point being edited.
                    var p = data.InverseTransform(e.Position);
                    if (p.X > bot.Maximum) p.X = bot.Maximum;
                    if (p.Y > maxY) p.Y = maxY;
                    if (p.X < bot.Minimum) p.X = bot.Minimum;
                    if (p.Y < minY) p.Y = minY;
                    if ((indexOfPointToMove > 0 && p.X <= data.Points[indexOfPointToMove - 1].X))
                    {
                        p.X = data.Points[indexOfPointToMove - 1].X + 1;
                    }
                    if (indexOfPointToMove < data.Points.Count - 1 && p.X >= data.Points[indexOfPointToMove + 1].X)
                    {
                        p.X = data.Points[indexOfPointToMove + 1].X - 1;
                    }
                    control.Curve[indexOfPointToMove] = new PointF((float)p.X, (float)p.Y);
                    data.Points[indexOfPointToMove] = p;

                    UpdateCurveTracker();
                    UpdatePlotTracker(e, p.X, p.Y);

                    model.RefreshPlot(false);
                    control.OverrideHysteresis = true;
                    e.Handled = true;
                }
            };

            data.MouseUp += (s, e) =>
            {
                // Stop editing
                indexOfPointToMove = -1;
                data.LineStyle = LineStyle.Solid;
                plotLabel.Visible = false;
                model.RefreshPlot(false);
                e.Handled = true;
            };

            model.MouseDown += (s, e) =>
            {
                if (e.ChangedButton == OxyMouseButton.Left)
                {
                    var t = data.InverseTransform(e.Position);
                    // Add a point to the line series.

                    // Check for max values
                    if (t.X <= bot.Maximum && t.X >= bot.Minimum && t.Y <= maxY && t.Y >= minY)
                    {
                        // Check for x-collisions
                        if (data.Points.Count > 0 && (t.X > data.Points[data.Points.Count - 1].X || t.X < data.Points[0].X))
                        {
                            if (data.Points[0].X > t.X)
                            {
                                data.Points.Insert(0, t);
                                indexOfPointToMove = 0;
                                control.Curve.Insert(0, new PointF((float)t.X, (float)t.Y));
                            }
                            else
                            {
                                data.Points.Add(t);
                                indexOfPointToMove = data.Points.Count - 1;
                                control.Curve.Add(new PointF((float)t.X, (float)t.Y));
                            }
                        }
                    }
                    UpdateCurveTracker();
                    model.RefreshPlot(false);
                    e.Handled = true;
                }

            };
            return model;
        }

        private void UpdatePlotTracker(OxyMouseEventArgs e, double x, double y)
        {
            plotLabel.Location = new Point((int)e.Position.X, (int)e.Position.Y - 15);
            if (control.Controlled.UseCalibrated)
            {
                plotLabel.Text = string.Format("{0:F1}={1:F1}% ({2:F0}RPM)", x, y, y / 100.0 * control.Controlled.MaxRPM);
            } else
            {
                plotLabel.Text = string.Format("{0:F1}={1:F1}%", x, y);
            }            
        }

        private void UpdateCurveTracker()
        {
            curValueLabel.Text = string.Format("{0,4:F2}/{1,4:F2}", control.LastValue, control.Curve.Get(control.LastValue));
            //bot.ExtraGridlines = new double[] { control.LastValue, control.LastAppliedValue - control.Hysteresis, control.LastAppliedValue + control.Hysteresis };
            bot.ExtraGridlines = new double[] { control.LastValue };
            //bot.ExtraGridlineColor = OxyColor.
            //left.ExtraGridlines = new double[] { control.Curve.Get(control.LastValue), control.Controlled.Calibrated[1].Y };
            left.ExtraGridlines = new double[] { control.Curve.Get(control.LastValue) };

            if (float.IsPositiveInfinity(control.LastValue))
            {
                valueTextBox.BackColor = Color.Red;
            }
            else
            {
                valueTextBox.BackColor = Color.White;
            }

            plot.InvalidatePlot(false);
        }

        private void valueTextBox_TextChanged(object sender, EventArgs e)
        {
            control.ValueString.Input = valueTextBox.Text;
            control.Update();
            
        }

        private void ControllerValueChanged(object sender, EventArgs e)
        {
            UpdateCurveTracker();
        }

        private void controllerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            control.Controlled = controllers[controllerComboBox.SelectedIndex];
            // Update RPM axis
            if (right == null && control.Controlled.UseCalibrated)
            {
                right = new LinearAxis(AxisPosition.Right, 0, control.Controlled.MaxRPM, 300, 100, "RPM");
                model.Axes.Add(right);
            } else if (right != null && control.Controlled.UseCalibrated)
            {
                right.Maximum = control.Controlled.MaxRPM;
            } else if (right != null && !control.Controlled.UseCalibrated)
            {
                model.Axes.Remove(right);
                right = null;
            }
            InvalidatePlot();
        }

        private void enabledCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            control.Enabled = enabledCheckbox.Checked;
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            control.Name = nameTextBox.Text;
            this.Text = control.Name;            
        }


        public void controller_enabledChanged(object sender, EventArgs e)
        {
            enabledCheckbox.Checked = control.Enabled;
        }

        private void hysteresisUpDown1_ValueChanged(object sender, EventArgs e)
        {
            control.Hysteresis = (float)hysteresisUpDown1.Value;
        }


        private void minMaxChanged(object sender, EventArgs e)
        {
            if (maxUpDown.Value <= minUpDown.Value) maxUpDown.Value = minUpDown.Value + 1;
            control.Curve.TransformValues((float)minUpDown.Value, (float)maxUpDown.Value);
            InvalidatePlot();

        }

        private void valueModeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (valueModeButton.Checked)
            {
                control.Source = FanController.InputSource.ValueString;
                valueTextBox.Enabled = true;
                sourceSensorComboBox.Enabled = false;
            } else if (tempModeButton.Checked)
            {
                control.Source = FanController.InputSource.Sensor;
                valueTextBox.Enabled = false;
                sourceSensorComboBox.Enabled = true;
            }
        }

        private void tempModeButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sourceSensorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            control.SourceSensor = (ISensor) sourceSensorComboBox.SelectedItem;
        }

        private void tryRestartBox_CheckedChanged(object sender, EventArgs e)
        {
            control.TryRestart = tryRestartBox.Checked;

        }
    }
}
