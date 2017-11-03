/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>   

*/

using System.Windows.Forms;

namespace LOLFan.GUI
{
    partial class Overview
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tempFanSplitContainer = new System.Windows.Forms.SplitContainer();
            this.tempsBox = new System.Windows.Forms.GroupBox();
            this.tempsBoxLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fanBox = new System.Windows.Forms.GroupBox();
            this.fanBoxLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.otherBox = new System.Windows.Forms.GroupBox();
            this.otherBoxLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.tempFanSplitContainer.Panel1.SuspendLayout();
            this.tempFanSplitContainer.Panel2.SuspendLayout();
            this.tempFanSplitContainer.SuspendLayout();
            this.tempsBox.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.fanBox.SuspendLayout();
            this.otherBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tempFanSplitContainer
            // 
            this.tempFanSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tempFanSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.tempFanSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.tempFanSplitContainer.Name = "tempFanSplitContainer";
            this.tempFanSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // tempFanSplitContainer.Panel1
            // 
            this.tempFanSplitContainer.Panel1.Controls.Add(this.tempsBox);
            // 
            // tempFanSplitContainer.Panel2
            // 
            this.tempFanSplitContainer.Panel2.Controls.Add(this.splitContainer1);
            this.tempFanSplitContainer.Size = new System.Drawing.Size(526, 496);
            this.tempFanSplitContainer.SplitterDistance = 210;
            this.tempFanSplitContainer.TabIndex = 9;
            this.tempFanSplitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.tempFanSplitContainer_SplitterMoved);
            // 
            // tempsBox
            // 
            this.tempsBox.Controls.Add(this.tempsBoxLayout);
            this.tempsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tempsBox.Location = new System.Drawing.Point(0, 0);
            this.tempsBox.Name = "tempsBox";
            this.tempsBox.Size = new System.Drawing.Size(526, 210);
            this.tempsBox.TabIndex = 1;
            this.tempsBox.TabStop = false;
            this.tempsBox.Text = "Temperatures";
            // 
            // tempsBoxLayout
            // 
            this.tempsBoxLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tempsBoxLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.tempsBoxLayout.Location = new System.Drawing.Point(3, 16);
            this.tempsBoxLayout.Name = "tempsBoxLayout";
            this.tempsBoxLayout.Size = new System.Drawing.Size(520, 191);
            this.tempsBoxLayout.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fanBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.otherBox);
            this.splitContainer1.Size = new System.Drawing.Size(526, 282);
            this.splitContainer1.SplitterDistance = 313;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // fanBox
            // 
            this.fanBox.Controls.Add(this.fanBoxLayout);
            this.fanBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fanBox.Location = new System.Drawing.Point(0, 0);
            this.fanBox.Name = "fanBox";
            this.fanBox.Size = new System.Drawing.Size(313, 282);
            this.fanBox.TabIndex = 3;
            this.fanBox.TabStop = false;
            this.fanBox.Text = "Fans";
            // 
            // fanBoxLayout
            // 
            this.fanBoxLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fanBoxLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fanBoxLayout.Location = new System.Drawing.Point(3, 16);
            this.fanBoxLayout.Name = "fanBoxLayout";
            this.fanBoxLayout.Size = new System.Drawing.Size(307, 263);
            this.fanBoxLayout.TabIndex = 1;
            // 
            // otherBox
            // 
            this.otherBox.Controls.Add(this.otherBoxLayout);
            this.otherBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.otherBox.Location = new System.Drawing.Point(0, 0);
            this.otherBox.Name = "otherBox";
            this.otherBox.Size = new System.Drawing.Size(209, 282);
            this.otherBox.TabIndex = 0;
            this.otherBox.TabStop = false;
            this.otherBox.Text = "Other";
            // 
            // otherBoxLayout
            // 
            this.otherBoxLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.otherBoxLayout.Location = new System.Drawing.Point(3, 16);
            this.otherBoxLayout.Name = "otherBoxLayout";
            this.otherBoxLayout.Size = new System.Drawing.Size(203, 263);
            this.otherBoxLayout.TabIndex = 0;
            // 
            // Overview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tempFanSplitContainer);
            this.Name = "Overview";
            this.Size = new System.Drawing.Size(526, 496);
            this.tempFanSplitContainer.Panel1.ResumeLayout(false);
            this.tempFanSplitContainer.Panel2.ResumeLayout(false);
            this.tempFanSplitContainer.ResumeLayout(false);
            this.tempsBox.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.fanBox.ResumeLayout(false);
            this.otherBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer tempFanSplitContainer;
        private System.Windows.Forms.GroupBox tempsBox;
        private System.Windows.Forms.FlowLayoutPanel tempsBoxLayout;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox fanBox;
        private System.Windows.Forms.FlowLayoutPanel fanBoxLayout;
        private GroupBox otherBox;
        private FlowLayoutPanel otherBoxLayout;
    }
}
