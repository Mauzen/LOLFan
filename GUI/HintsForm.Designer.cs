/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>   

*/

using System.Windows.Forms;

namespace LOLFan.GUI
{
    partial class HintsForm
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
            this.hintText = new System.Windows.Forms.TextBox();
            this.hideHintBox = new System.Windows.Forms.CheckBox();
            this.hintNumLabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hintText
            // 
            this.hintText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hintText.Location = new System.Drawing.Point(12, 41);
            this.hintText.Multiline = true;
            this.hintText.Name = "hintText";
            this.hintText.ReadOnly = true;
            this.hintText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.hintText.Size = new System.Drawing.Size(405, 248);
            this.hintText.TabIndex = 6;
            this.hintText.TabStop = false;
            // 
            // hideHintBox
            // 
            this.hideHintBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hideHintBox.AutoSize = true;
            this.hideHintBox.Location = new System.Drawing.Point(93, 304);
            this.hideHintBox.Name = "hideHintBox";
            this.hideHintBox.Size = new System.Drawing.Size(154, 17);
            this.hideHintBox.TabIndex = 8;
            this.hideHintBox.Text = "Do not show this hint again";
            this.hideHintBox.UseVisualStyleBackColor = true;
            this.hideHintBox.CheckedChanged += new System.EventHandler(this.hideHintBox_CheckedChanged);
            // 
            // hintNumLabel
            // 
            this.hintNumLabel.Location = new System.Drawing.Point(93, 12);
            this.hintNumLabel.Name = "hintNumLabel";
            this.hintNumLabel.Size = new System.Drawing.Size(243, 23);
            this.hintNumLabel.TabIndex = 7;
            this.hintNumLabel.Text = "Hint 3 of 3434";
            this.hintNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.Location = new System.Drawing.Point(342, 12);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 2;
            this.nextButton.Text = "Next >>";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // prevButton
            // 
            this.prevButton.Location = new System.Drawing.Point(12, 12);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(75, 23);
            this.prevButton.TabIndex = 1;
            this.prevButton.Text = "<< Previous";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closeButton.Location = new System.Drawing.Point(12, 300);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // HintsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 335);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.hideHintBox);
            this.Controls.Add(this.hintNumLabel);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.hintText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HintsForm";
            this.ShowInTaskbar = false;
            this.Text = "Hints";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HintsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox hintText;
        private System.Windows.Forms.CheckBox hideHintBox;
        private System.Windows.Forms.Label hintNumLabel;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button closeButton;
    }
}