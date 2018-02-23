/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>   

*/

namespace LOLFan.GUI
{
    partial class FanControlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FanControlForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maxUpDown = new System.Windows.Forms.NumericUpDown();
            this.minUpDown = new System.Windows.Forms.NumericUpDown();
            this.tryRestartBox = new System.Windows.Forms.CheckBox();
            this.sourceSensorComboBox = new System.Windows.Forms.ComboBox();
            this.valueModeButton = new System.Windows.Forms.RadioButton();
            this.tempModeButton = new System.Windows.Forms.RadioButton();
            this.hysteresisUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.controllerComboBox = new System.Windows.Forms.ComboBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.curValueLabel = new System.Windows.Forms.Label();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.enabledCheckbox = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hysteresisUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tryRestartBox);
            this.splitContainer1.Panel2.Controls.Add(this.sourceSensorComboBox);
            this.splitContainer1.Panel2.Controls.Add(this.valueModeButton);
            this.splitContainer1.Panel2.Controls.Add(this.tempModeButton);
            this.splitContainer1.Panel2.Controls.Add(this.hysteresisUpDown1);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.controllerComboBox);
            this.splitContainer1.Panel2.Controls.Add(this.nameTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.nameLabel);
            this.splitContainer1.Panel2.Controls.Add(this.curValueLabel);
            this.splitContainer1.Panel2.Controls.Add(this.valueTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.enabledCheckbox);
            this.splitContainer1.Size = new System.Drawing.Size(598, 448);
            this.splitContainer1.SplitterDistance = 275;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.maxUpDown);
            this.splitContainer2.Panel2.Controls.Add(this.minUpDown);
            this.splitContainer2.Size = new System.Drawing.Size(598, 275);
            this.splitContainer2.SplitterDistance = 244;
            this.splitContainer2.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(490, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "max";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "min";
            // 
            // maxUpDown
            // 
            this.maxUpDown.DecimalPlaces = 1;
            this.maxUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.maxUpDown.Location = new System.Drawing.Point(522, 4);
            this.maxUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.maxUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.maxUpDown.Name = "maxUpDown";
            this.maxUpDown.Size = new System.Drawing.Size(64, 20);
            this.maxUpDown.TabIndex = 1;
            this.toolTip1.SetToolTip(this.maxUpDown, "Scales the maximum value of the curve.");
            this.maxUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // minUpDown
            // 
            this.minUpDown.DecimalPlaces = 1;
            this.minUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.minUpDown.Location = new System.Drawing.Point(13, 4);
            this.minUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.minUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.minUpDown.Name = "minUpDown";
            this.minUpDown.Size = new System.Drawing.Size(61, 20);
            this.minUpDown.TabIndex = 0;
            this.toolTip1.SetToolTip(this.minUpDown, "Scales the minimum value of the curve.");
            // 
            // tryRestartBox
            // 
            this.tryRestartBox.AutoSize = true;
            this.tryRestartBox.Location = new System.Drawing.Point(332, 137);
            this.tryRestartBox.Name = "tryRestartBox";
            this.tryRestartBox.Size = new System.Drawing.Size(181, 17);
            this.tryRestartBox.TabIndex = 13;
            this.tryRestartBox.Text = "Restart fans that appear stopped";
            this.toolTip1.SetToolTip(this.tryRestartBox, resources.GetString("tryRestartBox.ToolTip"));
            this.tryRestartBox.UseVisualStyleBackColor = true;
            // 
            // sourceSensorComboBox
            // 
            this.sourceSensorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceSensorComboBox.FormattingEnabled = true;
            this.sourceSensorComboBox.Location = new System.Drawing.Point(104, 41);
            this.sourceSensorComboBox.Name = "sourceSensorComboBox";
            this.sourceSensorComboBox.Size = new System.Drawing.Size(205, 21);
            this.sourceSensorComboBox.TabIndex = 12;
            this.sourceSensorComboBox.SelectedIndexChanged += new System.EventHandler(this.sourceSensorComboBox_SelectedIndexChanged);
            // 
            // valueModeButton
            // 
            this.valueModeButton.AutoSize = true;
            this.valueModeButton.Checked = true;
            this.valueModeButton.Location = new System.Drawing.Point(16, 65);
            this.valueModeButton.Name = "valueModeButton";
            this.valueModeButton.Size = new System.Drawing.Size(80, 17);
            this.valueModeButton.TabIndex = 11;
            this.valueModeButton.TabStop = true;
            this.valueModeButton.Text = "Value string";
            this.toolTip1.SetToolTip(this.valueModeButton, "Use a custom SensorString for control.\r\nMay contain mathematical operations and s" +
        "ensor placeholders.");
            this.valueModeButton.UseVisualStyleBackColor = true;
            // 
            // tempModeButton
            // 
            this.tempModeButton.AutoSize = true;
            this.tempModeButton.Location = new System.Drawing.Point(16, 42);
            this.tempModeButton.Name = "tempModeButton";
            this.tempModeButton.Size = new System.Drawing.Size(58, 17);
            this.tempModeButton.TabIndex = 10;
            this.tempModeButton.Text = "Sensor";
            this.toolTip1.SetToolTip(this.tempModeButton, "Use a single sensor\'s value for control.");
            this.tempModeButton.UseVisualStyleBackColor = true;
            // 
            // hysteresisUpDown1
            // 
            this.hysteresisUpDown1.DecimalPlaces = 2;
            this.hysteresisUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.hysteresisUpDown1.Location = new System.Drawing.Point(104, 136);
            this.hysteresisUpDown1.Name = "hysteresisUpDown1";
            this.hysteresisUpDown1.Size = new System.Drawing.Size(60, 20);
            this.hysteresisUpDown1.TabIndex = 9;
            this.toolTip1.SetToolTip(this.hysteresisUpDown1, "Fan speed wont be changed until value change is bigger than the hysteresis.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hysteresis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Value/Duty";
            // 
            // controllerComboBox
            // 
            this.controllerComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controllerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.controllerComboBox.FormattingEnabled = true;
            this.controllerComboBox.Location = new System.Drawing.Point(332, 4);
            this.controllerComboBox.Name = "controllerComboBox";
            this.controllerComboBox.Size = new System.Drawing.Size(157, 21);
            this.controllerComboBox.TabIndex = 6;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(104, 4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(205, 20);
            this.nameTextBox.TabIndex = 5;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(13, 4);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Name";
            // 
            // curValueLabel
            // 
            this.curValueLabel.AutoSize = true;
            this.curValueLabel.Location = new System.Drawing.Point(101, 113);
            this.curValueLabel.Name = "curValueLabel";
            this.curValueLabel.Size = new System.Drawing.Size(18, 13);
            this.curValueLabel.TabIndex = 3;
            this.curValueLabel.Text = "-/-";
            // 
            // valueTextBox
            // 
            this.valueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valueTextBox.Location = new System.Drawing.Point(104, 65);
            this.valueTextBox.Multiline = true;
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.valueTextBox.Size = new System.Drawing.Size(456, 34);
            this.valueTextBox.TabIndex = 2;
            // 
            // enabledCheckbox
            // 
            this.enabledCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.enabledCheckbox.AutoSize = true;
            this.enabledCheckbox.Location = new System.Drawing.Point(495, 6);
            this.enabledCheckbox.Name = "enabledCheckbox";
            this.enabledCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.enabledCheckbox.Size = new System.Drawing.Size(65, 17);
            this.enabledCheckbox.TabIndex = 1;
            this.enabledCheckbox.Text = "Enabled";
            this.enabledCheckbox.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 400;
            // 
            // FanControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 448);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FanControlForm";
            this.Text = "FanControlForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.maxUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hysteresisUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label curValueLabel;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.CheckBox enabledCheckbox;
        private System.Windows.Forms.ComboBox controllerComboBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown hysteresisUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.NumericUpDown maxUpDown;
        private System.Windows.Forms.NumericUpDown minUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RadioButton valueModeButton;
        private System.Windows.Forms.RadioButton tempModeButton;
        private System.Windows.Forms.ComboBox sourceSensorComboBox;
        private System.Windows.Forms.CheckBox tryRestartBox;
    }
}