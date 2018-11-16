namespace LOLFan.GUI
{
    partial class VirtualSensorEditForm
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
            this.confirmButton = new System.Windows.Forms.Button();
            this.valueStringTextBox = new System.Windows.Forms.TextBox();
            this.valueStringLabel = new System.Windows.Forms.Label();
            this.abortButton = new System.Windows.Forms.Button();
            this.sensorTypeComboBox = new System.Windows.Forms.ComboBox();
            this.sensorTypeLabel = new System.Windows.Forms.Label();
            this.restartLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(128, 142);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(126, 23);
            this.confirmButton.TabIndex = 0;
            this.confirmButton.Text = "Ok";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // valueStringTextBox
            // 
            this.valueStringTextBox.Location = new System.Drawing.Point(93, 12);
            this.valueStringTextBox.Multiline = true;
            this.valueStringTextBox.Name = "valueStringTextBox";
            this.valueStringTextBox.Size = new System.Drawing.Size(293, 79);
            this.valueStringTextBox.TabIndex = 1;
            // 
            // valueStringLabel
            // 
            this.valueStringLabel.AutoSize = true;
            this.valueStringLabel.Location = new System.Drawing.Point(12, 15);
            this.valueStringLabel.Name = "valueStringLabel";
            this.valueStringLabel.Size = new System.Drawing.Size(61, 13);
            this.valueStringLabel.TabIndex = 2;
            this.valueStringLabel.Text = "ValueString";
            // 
            // abortButton
            // 
            this.abortButton.Location = new System.Drawing.Point(260, 142);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(126, 23);
            this.abortButton.TabIndex = 3;
            this.abortButton.Text = "Abort";
            this.abortButton.UseVisualStyleBackColor = true;
            this.abortButton.Click += new System.EventHandler(this.abortButton_Click);
            // 
            // sensorTypeComboBox
            // 
            this.sensorTypeComboBox.FormattingEnabled = true;
            this.sensorTypeComboBox.Location = new System.Drawing.Point(92, 98);
            this.sensorTypeComboBox.Name = "sensorTypeComboBox";
            this.sensorTypeComboBox.Size = new System.Drawing.Size(162, 21);
            this.sensorTypeComboBox.TabIndex = 4;
            this.sensorTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.sensorTypeComboBox_SelectedIndexChanged);
            // 
            // sensorTypeLabel
            // 
            this.sensorTypeLabel.AutoSize = true;
            this.sensorTypeLabel.Location = new System.Drawing.Point(12, 101);
            this.sensorTypeLabel.Name = "sensorTypeLabel";
            this.sensorTypeLabel.Size = new System.Drawing.Size(64, 13);
            this.sensorTypeLabel.TabIndex = 5;
            this.sensorTypeLabel.Text = "SensorType";
            // 
            // restartLabel
            // 
            this.restartLabel.AutoSize = true;
            this.restartLabel.Location = new System.Drawing.Point(261, 101);
            this.restartLabel.Name = "restartLabel";
            this.restartLabel.Size = new System.Drawing.Size(132, 26);
            this.restartLabel.TabIndex = 6;
            this.restartLabel.Text = "Please restart the software\r\nfor this to take effect";
            this.restartLabel.Visible = false;
            // 
            // VirtualSensorEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 188);
            this.Controls.Add(this.restartLabel);
            this.Controls.Add(this.sensorTypeLabel);
            this.Controls.Add(this.sensorTypeComboBox);
            this.Controls.Add(this.abortButton);
            this.Controls.Add(this.valueStringLabel);
            this.Controls.Add(this.valueStringTextBox);
            this.Controls.Add(this.confirmButton);
            this.Name = "VirtualSensorEditForm";
            this.Text = "VirtualSensorEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.TextBox valueStringTextBox;
        private System.Windows.Forms.Label valueStringLabel;
        private System.Windows.Forms.Button abortButton;
        private System.Windows.Forms.ComboBox sensorTypeComboBox;
        private System.Windows.Forms.Label sensorTypeLabel;
        private System.Windows.Forms.Label restartLabel;
    }
}