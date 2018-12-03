namespace LOLFan.GUI
{
    partial class LCDTextForm
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
            this.sensorStringList = new System.Windows.Forms.CheckedListBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sensorStringLabel = new System.Windows.Forms.Label();
            this.sensorStringTextBox = new System.Windows.Forms.TextBox();
            this.previewLabel = new System.Windows.Forms.Label();
            this.previewTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sensorStringList
            // 
            this.sensorStringList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sensorStringList.FormattingEnabled = true;
            this.sensorStringList.Location = new System.Drawing.Point(13, 13);
            this.sensorStringList.Name = "sensorStringList";
            this.sensorStringList.Size = new System.Drawing.Size(168, 304);
            this.sensorStringList.TabIndex = 0;
            this.sensorStringList.SelectedIndexChanged += new System.EventHandler(this.sensorStringList_SelectedIndexChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(209, 16);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(13, 324);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(106, 324);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(285, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(247, 20);
            this.textBox1.TabIndex = 4;
            // 
            // sensorStringLabel
            // 
            this.sensorStringLabel.AutoSize = true;
            this.sensorStringLabel.Location = new System.Drawing.Point(212, 53);
            this.sensorStringLabel.Name = "sensorStringLabel";
            this.sensorStringLabel.Size = new System.Drawing.Size(67, 13);
            this.sensorStringLabel.TabIndex = 5;
            this.sensorStringLabel.Text = "SensorString";
            // 
            // sensorStringTextBox
            // 
            this.sensorStringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sensorStringTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sensorStringTextBox.Location = new System.Drawing.Point(285, 50);
            this.sensorStringTextBox.Multiline = true;
            this.sensorStringTextBox.Name = "sensorStringTextBox";
            this.sensorStringTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sensorStringTextBox.Size = new System.Drawing.Size(247, 116);
            this.sensorStringTextBox.TabIndex = 6;
            this.sensorStringTextBox.TextChanged += new System.EventHandler(this.sensorStringTextBox_TextChanged);
            // 
            // previewLabel
            // 
            this.previewLabel.AutoSize = true;
            this.previewLabel.Location = new System.Drawing.Point(215, 211);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(45, 13);
            this.previewLabel.TabIndex = 7;
            this.previewLabel.Text = "Preview";
            // 
            // previewTextBox
            // 
            this.previewTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewTextBox.Location = new System.Drawing.Point(285, 208);
            this.previewTextBox.Multiline = true;
            this.previewTextBox.Name = "previewTextBox";
            this.previewTextBox.ReadOnly = true;
            this.previewTextBox.Size = new System.Drawing.Size(247, 109);
            this.previewTextBox.TabIndex = 8;
            // 
            // LCDTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 369);
            this.Controls.Add(this.previewTextBox);
            this.Controls.Add(this.previewLabel);
            this.Controls.Add(this.sensorStringTextBox);
            this.Controls.Add(this.sensorStringLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.sensorStringList);
            this.Name = "LCDTextForm";
            this.Text = "LCDTextForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox sensorStringList;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label sensorStringLabel;
        private System.Windows.Forms.TextBox sensorStringTextBox;
        private System.Windows.Forms.Label previewLabel;
        private System.Windows.Forms.TextBox previewTextBox;
    }
}