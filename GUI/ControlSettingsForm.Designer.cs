/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>   

*/

namespace LOLFan.GUI
{
    partial class ControlSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.offsetLabel = new System.Windows.Forms.Label();
            this.waitUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.updateAvgUpDown = new System.Windows.Forms.NumericUpDown();
            this.stepSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.calibrationProgressBar = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.downRateComboBox = new System.Windows.Forms.ComboBox();
            this.upRateComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fanComboBox = new System.Windows.Forms.ComboBox();
            this.useCalibrationCheckBox = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateAvgUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepSizeUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(355, 453);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.offsetLabel);
            this.groupBox2.Controls.Add(this.waitUpDown);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.updateAvgUpDown);
            this.groupBox2.Controls.Add(this.stepSizeUpDown);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.calibrationProgressBar);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 140);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Calibration";
            // 
            // offsetLabel
            // 
            this.offsetLabel.AutoSize = true;
            this.offsetLabel.Location = new System.Drawing.Point(186, 20);
            this.offsetLabel.Name = "offsetLabel";
            this.offsetLabel.Size = new System.Drawing.Size(75, 13);
            this.offsetLabel.TabIndex = 10;
            this.offsetLabel.Text = "Relative offset";
            this.toolTip1.SetToolTip(this.offsetLabel, "Relative offset from actual speed, to speed predicted by calibration.\r\nFor values" +
        " bigger than 10% a recalibration is recommended.");
            // 
            // waitUpDown
            // 
            this.waitUpDown.Location = new System.Drawing.Point(96, 71);
            this.waitUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.waitUpDown.Name = "waitUpDown";
            this.waitUpDown.Size = new System.Drawing.Size(52, 20);
            this.waitUpDown.TabIndex = 9;
            this.toolTip1.SetToolTip(this.waitUpDown, "Wait <value> updates for the fan to reach the new speed\r\nbefore gathering data.\r\n" +
        "Use higher values if your motherboard smoothens fan speed.");
            this.waitUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Wait/step";
            this.toolTip1.SetToolTip(this.label4, "Wait <value> updates for the fan to reach the new speed");
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(198, 89);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 7;
            this.toolTip1.SetToolTip(this.label3, "Estimated time left");
            // 
            // updateAvgUpDown
            // 
            this.updateAvgUpDown.Location = new System.Drawing.Point(96, 44);
            this.updateAvgUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.updateAvgUpDown.Name = "updateAvgUpDown";
            this.updateAvgUpDown.Size = new System.Drawing.Size(52, 20);
            this.updateAvgUpDown.TabIndex = 6;
            this.toolTip1.SetToolTip(this.updateAvgUpDown, "Use the average value of <value> updates.\r\nLower values reduce calibration time.\r" +
        "\nHigher values increase precision.");
            this.updateAvgUpDown.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // stepSizeUpDown
            // 
            this.stepSizeUpDown.DecimalPlaces = 1;
            this.stepSizeUpDown.Increment = new decimal(new int[] {
            263486202,
            913,
            0,
            851968});
            this.stepSizeUpDown.Location = new System.Drawing.Point(96, 18);
            this.stepSizeUpDown.Minimum = new decimal(new int[] {
            1314838809,
            91,
            0,
            786432});
            this.stepSizeUpDown.Name = "stepSizeUpDown";
            this.stepSizeUpDown.Size = new System.Drawing.Size(52, 20);
            this.stepSizeUpDown.TabIndex = 5;
            this.toolTip1.SetToolTip(this.stepSizeUpDown, "Reduce hardware duty by this amount each step.\r\nHigher values reduce calibration " +
        "time.\r\nLower values increase precision.");
            this.stepSizeUpDown.Value = new decimal(new int[] {
            294117647,
            0,
            0,
            524288});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Updates/step";
            this.toolTip1.SetToolTip(this.label2, "Use the average value of <value> updates.\r\nLower values reduce calibration time.\r" +
        "\nHigher values increase precision.\r\n");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Step size";
            this.toolTip1.SetToolTip(this.label1, "Reduce hardware duty by this amount each step.\r\nHigher values reduce calibration " +
        "time.\r\nLower values increase precision.");
            // 
            // calibrationProgressBar
            // 
            this.calibrationProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calibrationProgressBar.Location = new System.Drawing.Point(134, 105);
            this.calibrationProgressBar.Name = "calibrationProgressBar";
            this.calibrationProgressBar.Size = new System.Drawing.Size(209, 23);
            this.calibrationProgressBar.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Calibrate...";
            this.toolTip1.SetToolTip(this.button1, "Start calibration.\r\nFor faster results it is recommended to set the fan update ra" +
        "tes\r\nto maximum for the calibration if available.");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.downRateComboBox);
            this.groupBox1.Controls.Add(this.upRateComboBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.fanComboBox);
            this.groupBox1.Controls.Add(this.useCalibrationCheckBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 289);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Down rate";
            this.toolTip1.SetToolTip(this.label7, "Sets how fast the fan duty is changed downwards.\r\nLower values cause smoother fan" +
        " speed changes.\r\nHigher values cause a faster reaction.\r\nNot available on all ma" +
        "inboards.\r\n");
            // 
            // downRateComboBox
            // 
            this.downRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.downRateComboBox.FormattingEnabled = true;
            this.downRateComboBox.Location = new System.Drawing.Point(96, 73);
            this.downRateComboBox.Name = "downRateComboBox";
            this.downRateComboBox.Size = new System.Drawing.Size(124, 21);
            this.downRateComboBox.TabIndex = 4;
            this.toolTip1.SetToolTip(this.downRateComboBox, "Sets how fast the fan duty is changed downwards.\r\nLower values cause smoother fan" +
        " speed changes.\r\nHigher values cause a faster reaction.\r\n");
            // 
            // upRateComboBox
            // 
            this.upRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.upRateComboBox.FormattingEnabled = true;
            this.upRateComboBox.Location = new System.Drawing.Point(96, 46);
            this.upRateComboBox.Name = "upRateComboBox";
            this.upRateComboBox.Size = new System.Drawing.Size(124, 21);
            this.upRateComboBox.TabIndex = 3;
            this.toolTip1.SetToolTip(this.upRateComboBox, "Sets how fast the fan duty is changed upwards.\r\nLower values cause smoother fan s" +
        "peed changes.\r\nHigher values cause a faster reaction.");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Up rate";
            this.toolTip1.SetToolTip(this.label6, "Sets how fast the fan duty is changed upwards.\r\nLower values cause smoother fan s" +
        "peed changes.\r\nHigher values cause a faster reaction.\r\nNot available on all main" +
        "boards.\r\n");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Controlled fan";
            // 
            // fanComboBox
            // 
            this.fanComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fanComboBox.FormattingEnabled = true;
            this.fanComboBox.Location = new System.Drawing.Point(96, 19);
            this.fanComboBox.Name = "fanComboBox";
            this.fanComboBox.Size = new System.Drawing.Size(124, 21);
            this.fanComboBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.fanComboBox, "Select the fan that is affected by this control.");
            // 
            // useCalibrationCheckBox
            // 
            this.useCalibrationCheckBox.AutoSize = true;
            this.useCalibrationCheckBox.Location = new System.Drawing.Point(226, 21);
            this.useCalibrationCheckBox.Name = "useCalibrationCheckBox";
            this.useCalibrationCheckBox.Size = new System.Drawing.Size(117, 17);
            this.useCalibrationCheckBox.TabIndex = 0;
            this.useCalibrationCheckBox.Text = "Use calibrated duty";
            this.toolTip1.SetToolTip(this.useCalibrationCheckBox, "Use the calibrated (real) fan duty instead of the hardware duty.\r\nOnly available " +
        "after calibration.");
            this.useCalibrationCheckBox.UseVisualStyleBackColor = true;
            // 
            // ControlSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 453);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ControlSettingsForm";
            this.Text = "ControlSettingsForm";
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updateAvgUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepSizeUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox fanComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown waitUpDown;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown updateAvgUpDown;
        private System.Windows.Forms.NumericUpDown stepSizeUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar calibrationProgressBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox useCalibrationCheckBox;
        private System.Windows.Forms.ComboBox upRateComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox downRateComboBox;
        private System.Windows.Forms.Label offsetLabel;
    }
}