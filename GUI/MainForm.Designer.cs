/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2009-2013 Michael Möller <mmoeller@openhardwaremonitor.org>
    Copyright (C) 2017 Michel Soll <msoll@web.de>   

*/

namespace LOLFan.GUI {
  partial class MainForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sensor = new Aga.Controls.Tree.TreeColumn();
            this.value = new Aga.Controls.Tree.TreeColumn();
            this.min = new Aga.Controls.Tree.TreeColumn();
            this.max = new Aga.Controls.Tree.TreeColumn();
            this.nodeImage = new Aga.Controls.Tree.NodeControls.NodeIcon();
            this.nodeCheckBox = new Aga.Controls.Tree.NodeControls.NodeCheckBox();
            this.nodeTextBoxText = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.nodeTextBoxValue = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.nodeTextBoxMin = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.nodeTextBoxMax = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.fileMenuItem = new System.Windows.Forms.MenuItem();
            this.saveReportMenuItem = new System.Windows.Forms.MenuItem();
            this.sumbitReportMenuItem = new System.Windows.Forms.MenuItem();
            this.MenuItem2 = new System.Windows.Forms.MenuItem();
            this.resetMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.mainboardMenuItem = new System.Windows.Forms.MenuItem();
            this.cpuMenuItem = new System.Windows.Forms.MenuItem();
            this.ramMenuItem = new System.Windows.Forms.MenuItem();
            this.gpuMenuItem = new System.Windows.Forms.MenuItem();
            this.fanControllerMenuItem = new System.Windows.Forms.MenuItem();
            this.hddMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.exitMenuItem = new System.Windows.Forms.MenuItem();
            this.viewMenuItem = new System.Windows.Forms.MenuItem();
            this.resetMinMaxMenuItem = new System.Windows.Forms.MenuItem();
            this.MenuItem3 = new System.Windows.Forms.MenuItem();
            this.hiddenMenuItem = new System.Windows.Forms.MenuItem();
            this.plotMenuItem = new System.Windows.Forms.MenuItem();
            this.MenuItem1 = new System.Windows.Forms.MenuItem();
            this.columnsMenuItem = new System.Windows.Forms.MenuItem();
            this.valueMenuItem = new System.Windows.Forms.MenuItem();
            this.minMenuItem = new System.Windows.Forms.MenuItem();
            this.maxMenuItem = new System.Windows.Forms.MenuItem();
            this.optionsMenuItem = new System.Windows.Forms.MenuItem();
            this.startMinMenuItem = new System.Windows.Forms.MenuItem();
            this.minTrayMenuItem = new System.Windows.Forms.MenuItem();
            this.minCloseMenuItem = new System.Windows.Forms.MenuItem();
            this.startupMenuItem = new System.Windows.Forms.MenuItem();
            this.separatorMenuItem = new System.Windows.Forms.MenuItem();
            this.temperatureUnitsMenuItem = new System.Windows.Forms.MenuItem();
            this.celsiusMenuItem = new System.Windows.Forms.MenuItem();
            this.fahrenheitMenuItem = new System.Windows.Forms.MenuItem();
            this.plotLocationMenuItem = new System.Windows.Forms.MenuItem();
            this.plotWindowMenuItem = new System.Windows.Forms.MenuItem();
            this.plotBottomMenuItem = new System.Windows.Forms.MenuItem();
            this.plotRightMenuItem = new System.Windows.Forms.MenuItem();
            this.logSeparatorMenuItem = new System.Windows.Forms.MenuItem();
            this.logSensorsMenuItem = new System.Windows.Forms.MenuItem();
            this.loggingIntervalMenuItem = new System.Windows.Forms.MenuItem();
            this.log1sMenuItem = new System.Windows.Forms.MenuItem();
            this.log2sMenuItem = new System.Windows.Forms.MenuItem();
            this.log5sMenuItem = new System.Windows.Forms.MenuItem();
            this.log10sMenuItem = new System.Windows.Forms.MenuItem();
            this.log30sMenuItem = new System.Windows.Forms.MenuItem();
            this.log1minMenuItem = new System.Windows.Forms.MenuItem();
            this.log2minMenuItem = new System.Windows.Forms.MenuItem();
            this.log5minMenuItem = new System.Windows.Forms.MenuItem();
            this.log10minMenuItem = new System.Windows.Forms.MenuItem();
            this.log30minMenuItem = new System.Windows.Forms.MenuItem();
            this.log1hMenuItem = new System.Windows.Forms.MenuItem();
            this.log2hMenuItem = new System.Windows.Forms.MenuItem();
            this.log6hMenuItem = new System.Windows.Forms.MenuItem();
            this.webMenuItemSeparator = new System.Windows.Forms.MenuItem();
            this.webMenuItem = new System.Windows.Forms.MenuItem();
            this.runWebServerMenuItem = new System.Windows.Forms.MenuItem();
            this.serverPortMenuItem = new System.Windows.Forms.MenuItem();
            this.helpMenuItem = new System.Windows.Forms.MenuItem();
            this.aboutMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.treeContextMenu = new System.Windows.Forms.ContextMenu();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.overview = new LOLFan.GUI.Overview();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer = new LOLFan.GUI.SplitContainerAdv();
            this.treeView = new Aga.Controls.Tree.TreeViewAdv();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lcdFormatText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupItemsListBox = new System.Windows.Forms.CheckedListBox();
            this.removeGroupButton = new System.Windows.Forms.Button();
            this.addGroupButton = new System.Windows.Forms.Button();
            this.groupsListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.copyControllerButton = new System.Windows.Forms.Button();
            this.controllerListBox = new LOLFan.GUI.FanControllerListView();
            this.removeControllerButton = new System.Windows.Forms.Button();
            this.editControllerButton = new System.Windows.Forms.Button();
            this.newControllerButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sensor
            // 
            this.sensor.Header = "Sensor";
            this.sensor.SortOrder = System.Windows.Forms.SortOrder.None;
            this.sensor.TooltipText = null;
            this.sensor.Width = 250;
            // 
            // value
            // 
            this.value.Header = "Value";
            this.value.SortOrder = System.Windows.Forms.SortOrder.None;
            this.value.TooltipText = null;
            this.value.Width = 100;
            // 
            // min
            // 
            this.min.Header = "Min";
            this.min.SortOrder = System.Windows.Forms.SortOrder.None;
            this.min.TooltipText = null;
            this.min.Width = 100;
            // 
            // max
            // 
            this.max.Header = "Max";
            this.max.SortOrder = System.Windows.Forms.SortOrder.None;
            this.max.TooltipText = null;
            this.max.Width = 100;
            // 
            // nodeImage
            // 
            this.nodeImage.DataPropertyName = "Image";
            this.nodeImage.LeftMargin = 1;
            this.nodeImage.ParentColumn = this.sensor;
            this.nodeImage.ScaleMode = Aga.Controls.Tree.ImageScaleMode.Fit;
            // 
            // nodeCheckBox
            // 
            this.nodeCheckBox.DataPropertyName = "Plot";
            this.nodeCheckBox.EditEnabled = true;
            this.nodeCheckBox.LeftMargin = 3;
            this.nodeCheckBox.ParentColumn = this.sensor;
            // 
            // nodeTextBoxText
            // 
            this.nodeTextBoxText.DataPropertyName = "Text";
            this.nodeTextBoxText.EditEnabled = true;
            this.nodeTextBoxText.IncrementalSearchEnabled = true;
            this.nodeTextBoxText.LeftMargin = 3;
            this.nodeTextBoxText.ParentColumn = this.sensor;
            this.nodeTextBoxText.Trimming = System.Drawing.StringTrimming.EllipsisCharacter;
            this.nodeTextBoxText.UseCompatibleTextRendering = true;
            // 
            // nodeTextBoxValue
            // 
            this.nodeTextBoxValue.DataPropertyName = "Value";
            this.nodeTextBoxValue.IncrementalSearchEnabled = true;
            this.nodeTextBoxValue.LeftMargin = 3;
            this.nodeTextBoxValue.ParentColumn = this.value;
            this.nodeTextBoxValue.Trimming = System.Drawing.StringTrimming.EllipsisCharacter;
            this.nodeTextBoxValue.UseCompatibleTextRendering = true;
            // 
            // nodeTextBoxMin
            // 
            this.nodeTextBoxMin.DataPropertyName = "Min";
            this.nodeTextBoxMin.IncrementalSearchEnabled = true;
            this.nodeTextBoxMin.LeftMargin = 3;
            this.nodeTextBoxMin.ParentColumn = this.min;
            this.nodeTextBoxMin.Trimming = System.Drawing.StringTrimming.EllipsisCharacter;
            this.nodeTextBoxMin.UseCompatibleTextRendering = true;
            // 
            // nodeTextBoxMax
            // 
            this.nodeTextBoxMax.DataPropertyName = "Max";
            this.nodeTextBoxMax.IncrementalSearchEnabled = true;
            this.nodeTextBoxMax.LeftMargin = 3;
            this.nodeTextBoxMax.ParentColumn = this.max;
            this.nodeTextBoxMax.Trimming = System.Drawing.StringTrimming.EllipsisCharacter;
            this.nodeTextBoxMax.UseCompatibleTextRendering = true;
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.fileMenuItem,
            this.viewMenuItem,
            this.optionsMenuItem,
            this.helpMenuItem});
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.Index = 0;
            this.fileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.saveReportMenuItem,
            this.sumbitReportMenuItem,
            this.MenuItem2,
            this.resetMenuItem,
            this.menuItem5,
            this.menuItem6,
            this.exitMenuItem});
            this.fileMenuItem.Text = "File";
            // 
            // saveReportMenuItem
            // 
            this.saveReportMenuItem.Index = 0;
            this.saveReportMenuItem.Text = "Save Report...";
            this.saveReportMenuItem.Click += new System.EventHandler(this.saveReportMenuItem_Click);
            // 
            // sumbitReportMenuItem
            // 
            this.sumbitReportMenuItem.Index = 1;
            this.sumbitReportMenuItem.Text = "Submit Report...";
            this.sumbitReportMenuItem.Click += new System.EventHandler(this.sumbitReportMenuItem_Click);
            // 
            // MenuItem2
            // 
            this.MenuItem2.Index = 2;
            this.MenuItem2.Text = "-";
            this.MenuItem2.Visible = false;
            // 
            // resetMenuItem
            // 
            this.resetMenuItem.Enabled = false;
            this.resetMenuItem.Index = 3;
            this.resetMenuItem.Text = "Reset";
            this.resetMenuItem.Visible = false;
            this.resetMenuItem.Click += new System.EventHandler(this.resetClick);
            // 
            // menuItem5
            // 
            this.menuItem5.Enabled = false;
            this.menuItem5.Index = 4;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mainboardMenuItem,
            this.cpuMenuItem,
            this.ramMenuItem,
            this.gpuMenuItem,
            this.fanControllerMenuItem,
            this.hddMenuItem});
            this.menuItem5.Text = "Hardware";
            this.menuItem5.Visible = false;
            // 
            // mainboardMenuItem
            // 
            this.mainboardMenuItem.Index = 0;
            this.mainboardMenuItem.Text = "Mainboard";
            // 
            // cpuMenuItem
            // 
            this.cpuMenuItem.Index = 1;
            this.cpuMenuItem.Text = "CPU";
            // 
            // ramMenuItem
            // 
            this.ramMenuItem.Index = 2;
            this.ramMenuItem.Text = "RAM";
            // 
            // gpuMenuItem
            // 
            this.gpuMenuItem.Index = 3;
            this.gpuMenuItem.Text = "GPU";
            // 
            // fanControllerMenuItem
            // 
            this.fanControllerMenuItem.Index = 4;
            this.fanControllerMenuItem.Text = "Fan Controllers";
            // 
            // hddMenuItem
            // 
            this.hddMenuItem.Index = 5;
            this.hddMenuItem.Text = "Hard Disk Drives";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 5;
            this.menuItem6.Text = "-";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Index = 6;
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitClick);
            // 
            // viewMenuItem
            // 
            this.viewMenuItem.Index = 1;
            this.viewMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.resetMinMaxMenuItem,
            this.MenuItem3,
            this.hiddenMenuItem,
            this.plotMenuItem,
            this.MenuItem1,
            this.columnsMenuItem});
            this.viewMenuItem.Text = "View";
            // 
            // resetMinMaxMenuItem
            // 
            this.resetMinMaxMenuItem.Index = 0;
            this.resetMinMaxMenuItem.Text = "Reset Min/Max";
            this.resetMinMaxMenuItem.Click += new System.EventHandler(this.resetMinMaxMenuItem_Click);
            // 
            // MenuItem3
            // 
            this.MenuItem3.Index = 1;
            this.MenuItem3.Text = "-";
            // 
            // hiddenMenuItem
            // 
            this.hiddenMenuItem.Index = 2;
            this.hiddenMenuItem.Text = "Show Hidden Sensors";
            // 
            // plotMenuItem
            // 
            this.plotMenuItem.Index = 3;
            this.plotMenuItem.Text = "Show Plot";
            // 
            // MenuItem1
            // 
            this.MenuItem1.Index = 4;
            this.MenuItem1.Text = "-";
            // 
            // columnsMenuItem
            // 
            this.columnsMenuItem.Index = 5;
            this.columnsMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.valueMenuItem,
            this.minMenuItem,
            this.maxMenuItem});
            this.columnsMenuItem.Text = "Columns";
            // 
            // valueMenuItem
            // 
            this.valueMenuItem.Index = 0;
            this.valueMenuItem.Text = "Value";
            // 
            // minMenuItem
            // 
            this.minMenuItem.Index = 1;
            this.minMenuItem.Text = "Min";
            // 
            // maxMenuItem
            // 
            this.maxMenuItem.Index = 2;
            this.maxMenuItem.Text = "Max";
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.Index = 2;
            this.optionsMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.startMinMenuItem,
            this.minTrayMenuItem,
            this.minCloseMenuItem,
            this.startupMenuItem,
            this.separatorMenuItem,
            this.temperatureUnitsMenuItem,
            this.plotLocationMenuItem,
            this.logSeparatorMenuItem,
            this.logSensorsMenuItem,
            this.loggingIntervalMenuItem,
            this.webMenuItemSeparator,
            this.webMenuItem});
            this.optionsMenuItem.Text = "Options";
            // 
            // startMinMenuItem
            // 
            this.startMinMenuItem.Index = 0;
            this.startMinMenuItem.Text = "Start Minimized";
            // 
            // minTrayMenuItem
            // 
            this.minTrayMenuItem.Index = 1;
            this.minTrayMenuItem.Text = "Minimize To Tray";
            // 
            // minCloseMenuItem
            // 
            this.minCloseMenuItem.Index = 2;
            this.minCloseMenuItem.Text = "Minimize On Close";
            // 
            // startupMenuItem
            // 
            this.startupMenuItem.Index = 3;
            this.startupMenuItem.Text = "Run On Windows Startup";
            // 
            // separatorMenuItem
            // 
            this.separatorMenuItem.Index = 4;
            this.separatorMenuItem.Text = "-";
            // 
            // temperatureUnitsMenuItem
            // 
            this.temperatureUnitsMenuItem.Index = 5;
            this.temperatureUnitsMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.celsiusMenuItem,
            this.fahrenheitMenuItem});
            this.temperatureUnitsMenuItem.Text = "Temperature Unit";
            // 
            // celsiusMenuItem
            // 
            this.celsiusMenuItem.Index = 0;
            this.celsiusMenuItem.RadioCheck = true;
            this.celsiusMenuItem.Text = "Celsius";
            this.celsiusMenuItem.Click += new System.EventHandler(this.celsiusMenuItem_Click);
            // 
            // fahrenheitMenuItem
            // 
            this.fahrenheitMenuItem.Index = 1;
            this.fahrenheitMenuItem.RadioCheck = true;
            this.fahrenheitMenuItem.Text = "Fahrenheit";
            this.fahrenheitMenuItem.Click += new System.EventHandler(this.fahrenheitMenuItem_Click);
            // 
            // plotLocationMenuItem
            // 
            this.plotLocationMenuItem.Index = 6;
            this.plotLocationMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.plotWindowMenuItem,
            this.plotBottomMenuItem,
            this.plotRightMenuItem});
            this.plotLocationMenuItem.Text = "Plot Location";
            // 
            // plotWindowMenuItem
            // 
            this.plotWindowMenuItem.Index = 0;
            this.plotWindowMenuItem.RadioCheck = true;
            this.plotWindowMenuItem.Text = "Window";
            // 
            // plotBottomMenuItem
            // 
            this.plotBottomMenuItem.Index = 1;
            this.plotBottomMenuItem.RadioCheck = true;
            this.plotBottomMenuItem.Text = "Bottom";
            // 
            // plotRightMenuItem
            // 
            this.plotRightMenuItem.Index = 2;
            this.plotRightMenuItem.RadioCheck = true;
            this.plotRightMenuItem.Text = "Right";
            // 
            // logSeparatorMenuItem
            // 
            this.logSeparatorMenuItem.Index = 7;
            this.logSeparatorMenuItem.Text = "-";
            // 
            // logSensorsMenuItem
            // 
            this.logSensorsMenuItem.Index = 8;
            this.logSensorsMenuItem.Text = "Log Sensors";
            // 
            // loggingIntervalMenuItem
            // 
            this.loggingIntervalMenuItem.Index = 9;
            this.loggingIntervalMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.log1sMenuItem,
            this.log2sMenuItem,
            this.log5sMenuItem,
            this.log10sMenuItem,
            this.log30sMenuItem,
            this.log1minMenuItem,
            this.log2minMenuItem,
            this.log5minMenuItem,
            this.log10minMenuItem,
            this.log30minMenuItem,
            this.log1hMenuItem,
            this.log2hMenuItem,
            this.log6hMenuItem});
            this.loggingIntervalMenuItem.Text = "Logging Interval";
            // 
            // log1sMenuItem
            // 
            this.log1sMenuItem.Index = 0;
            this.log1sMenuItem.RadioCheck = true;
            this.log1sMenuItem.Text = "1s";
            // 
            // log2sMenuItem
            // 
            this.log2sMenuItem.Index = 1;
            this.log2sMenuItem.RadioCheck = true;
            this.log2sMenuItem.Text = "2s";
            // 
            // log5sMenuItem
            // 
            this.log5sMenuItem.Index = 2;
            this.log5sMenuItem.RadioCheck = true;
            this.log5sMenuItem.Text = "5s";
            // 
            // log10sMenuItem
            // 
            this.log10sMenuItem.Index = 3;
            this.log10sMenuItem.RadioCheck = true;
            this.log10sMenuItem.Text = "10s";
            // 
            // log30sMenuItem
            // 
            this.log30sMenuItem.Index = 4;
            this.log30sMenuItem.RadioCheck = true;
            this.log30sMenuItem.Text = "30s";
            // 
            // log1minMenuItem
            // 
            this.log1minMenuItem.Index = 5;
            this.log1minMenuItem.RadioCheck = true;
            this.log1minMenuItem.Text = "1min";
            // 
            // log2minMenuItem
            // 
            this.log2minMenuItem.Index = 6;
            this.log2minMenuItem.RadioCheck = true;
            this.log2minMenuItem.Text = "2min";
            // 
            // log5minMenuItem
            // 
            this.log5minMenuItem.Index = 7;
            this.log5minMenuItem.RadioCheck = true;
            this.log5minMenuItem.Text = "5min";
            // 
            // log10minMenuItem
            // 
            this.log10minMenuItem.Index = 8;
            this.log10minMenuItem.RadioCheck = true;
            this.log10minMenuItem.Text = "10min";
            // 
            // log30minMenuItem
            // 
            this.log30minMenuItem.Index = 9;
            this.log30minMenuItem.RadioCheck = true;
            this.log30minMenuItem.Text = "30min";
            // 
            // log1hMenuItem
            // 
            this.log1hMenuItem.Index = 10;
            this.log1hMenuItem.RadioCheck = true;
            this.log1hMenuItem.Text = "1h";
            // 
            // log2hMenuItem
            // 
            this.log2hMenuItem.Index = 11;
            this.log2hMenuItem.RadioCheck = true;
            this.log2hMenuItem.Text = "2h";
            // 
            // log6hMenuItem
            // 
            this.log6hMenuItem.Index = 12;
            this.log6hMenuItem.RadioCheck = true;
            this.log6hMenuItem.Text = "6h";
            // 
            // webMenuItemSeparator
            // 
            this.webMenuItemSeparator.Index = 10;
            this.webMenuItemSeparator.Text = "-";
            this.webMenuItemSeparator.Visible = false;
            // 
            // webMenuItem
            // 
            this.webMenuItem.Enabled = false;
            this.webMenuItem.Index = 11;
            this.webMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.runWebServerMenuItem,
            this.serverPortMenuItem});
            this.webMenuItem.Text = "Remote Web Server";
            this.webMenuItem.Visible = false;
            // 
            // runWebServerMenuItem
            // 
            this.runWebServerMenuItem.Index = 0;
            this.runWebServerMenuItem.Text = "Run";
            // 
            // serverPortMenuItem
            // 
            this.serverPortMenuItem.Index = 1;
            this.serverPortMenuItem.Text = "Port";
            this.serverPortMenuItem.Click += new System.EventHandler(this.serverPortMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Index = 3;
            this.helpMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.aboutMenuItem,
            this.menuItem4,
            this.menuItem7,
            this.menuItem8});
            this.helpMenuItem.Text = "Help";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Index = 0;
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "Hints";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 2;
            this.menuItem7.Text = "-";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 3;
            this.menuItem8.Text = "Check for updates";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            this.saveFileDialog.FileName = "LOLFan.Report.txt";
            this.saveFileDialog.Filter = "Text Documents|*.txt|All Files|*.*";
            this.saveFileDialog.RestoreDirectory = true;
            this.saveFileDialog.Title = "Save Report As";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(477, 470);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.overview);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(469, 444);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Overview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // overview
            // 
            this.overview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overview.Location = new System.Drawing.Point(3, 3);
            this.overview.Name = "overview";
            this.overview.Settings = null;
            this.overview.Size = new System.Drawing.Size(463, 438);
            this.overview.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(469, 444);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Monitor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            this.splitContainer.Border3DStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.splitContainer.Color = System.Drawing.SystemColors.Control;
            this.splitContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer.Location = new System.Drawing.Point(12, 12);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer.Size = new System.Drawing.Size(386, 483);
            this.splitContainer.SplitterDistance = 334;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 6;
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.SystemColors.Window;
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Columns.Add(this.sensor);
            this.treeView.Columns.Add(this.value);
            this.treeView.Columns.Add(this.min);
            this.treeView.Columns.Add(this.max);
            this.treeView.DefaultToolTipProvider = null;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.DragDropMarkColor = System.Drawing.Color.Black;
            this.treeView.FullRowSelect = true;
            this.treeView.GridLineStyle = Aga.Controls.Tree.GridLineStyle.Horizontal;
            this.treeView.LineColor = System.Drawing.SystemColors.ControlDark;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Model = null;
            this.treeView.Name = "treeView";
            this.treeView.NodeControls.Add(this.nodeImage);
            this.treeView.NodeControls.Add(this.nodeCheckBox);
            this.treeView.NodeControls.Add(this.nodeTextBoxText);
            this.treeView.NodeControls.Add(this.nodeTextBoxValue);
            this.treeView.NodeControls.Add(this.nodeTextBoxMin);
            this.treeView.NodeControls.Add(this.nodeTextBoxMax);
            this.treeView.SelectedNode = null;
            this.treeView.Size = new System.Drawing.Size(386, 334);
            this.treeView.TabIndex = 0;
            this.treeView.Text = "treeView";
            this.treeView.UseColumns = true;
            this.treeView.NodeMouseDoubleClick += new System.EventHandler<Aga.Controls.Tree.TreeNodeAdvMouseEventArgs>(this.treeView_NodeMouseDoubleClick);
            this.treeView.Click += new System.EventHandler(this.treeView_Click);
            this.treeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDown);
            this.treeView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseMove);
            this.treeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseUp);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(469, 444);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Options";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lcdFormatText);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDown1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(463, 438);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 1;
            // 
            // lcdFormatText
            // 
            this.lcdFormatText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcdFormatText.Location = new System.Drawing.Point(127, 49);
            this.lcdFormatText.Multiline = true;
            this.lcdFormatText.Name = "lcdFormatText";
            this.lcdFormatText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lcdFormatText.Size = new System.Drawing.Size(272, 96);
            this.lcdFormatText.TabIndex = 3;
            this.lcdFormatText.TextChanged += new System.EventHandler(this.lcdFormatText_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "LCD Format";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(127, 4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Refresh Rate [ms]:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(469, 444);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Fan control";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupItemsListBox);
            this.groupBox2.Controls.Add(this.removeGroupButton);
            this.groupBox2.Controls.Add(this.addGroupButton);
            this.groupBox2.Controls.Add(this.groupsListBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 371);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(463, 70);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controller groups";
            this.groupBox2.Visible = false;
            // 
            // groupItemsListBox
            // 
            this.groupItemsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupItemsListBox.FormattingEnabled = true;
            this.groupItemsListBox.Items.AddRange(new object[] {
            "gg",
            "aa"});
            this.groupItemsListBox.Location = new System.Drawing.Point(202, 19);
            this.groupItemsListBox.Name = "groupItemsListBox";
            this.groupItemsListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.groupItemsListBox.Size = new System.Drawing.Size(251, 124);
            this.groupItemsListBox.TabIndex = 3;
            this.groupItemsListBox.ThreeDCheckBoxes = true;
            // 
            // removeGroupButton
            // 
            this.removeGroupButton.Location = new System.Drawing.Point(87, 149);
            this.removeGroupButton.Name = "removeGroupButton";
            this.removeGroupButton.Size = new System.Drawing.Size(75, 23);
            this.removeGroupButton.TabIndex = 2;
            this.removeGroupButton.Text = "Remove";
            this.removeGroupButton.UseVisualStyleBackColor = true;
            // 
            // addGroupButton
            // 
            this.addGroupButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.addGroupButton.Location = new System.Drawing.Point(6, 149);
            this.addGroupButton.Name = "addGroupButton";
            this.addGroupButton.Size = new System.Drawing.Size(75, 0);
            this.addGroupButton.TabIndex = 1;
            this.addGroupButton.Text = "New";
            this.addGroupButton.UseVisualStyleBackColor = true;
            // 
            // groupsListBox
            // 
            this.groupsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupsListBox.FormattingEnabled = true;
            this.groupsListBox.Items.AddRange(new object[] {
            "ggg",
            "hhh"});
            this.groupsListBox.Location = new System.Drawing.Point(5, 19);
            this.groupsListBox.Name = "groupsListBox";
            this.groupsListBox.Size = new System.Drawing.Size(178, 4);
            this.groupsListBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.copyControllerButton);
            this.groupBox1.Controls.Add(this.controllerListBox);
            this.groupBox1.Controls.Add(this.removeControllerButton);
            this.groupBox1.Controls.Add(this.editControllerButton);
            this.groupBox1.Controls.Add(this.newControllerButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 444);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fan controllers";
            // 
            // copyControllerButton
            // 
            this.copyControllerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copyControllerButton.Location = new System.Drawing.Point(327, 79);
            this.copyControllerButton.Name = "copyControllerButton";
            this.copyControllerButton.Size = new System.Drawing.Size(107, 23);
            this.copyControllerButton.TabIndex = 9;
            this.copyControllerButton.Text = "Copy...";
            this.copyControllerButton.UseVisualStyleBackColor = true;
            this.copyControllerButton.Click += new System.EventHandler(this.copyControllerButton_Click);
            // 
            // controllerListBox
            // 
            this.controllerListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controllerListBox.CheckBoxes = true;
            this.controllerListBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.controllerListBox.HideSelection = false;
            this.controllerListBox.Location = new System.Drawing.Point(7, 19);
            this.controllerListBox.MultiSelect = false;
            this.controllerListBox.Name = "controllerListBox";
            this.controllerListBox.Size = new System.Drawing.Size(313, 343);
            this.controllerListBox.TabIndex = 8;
            this.controllerListBox.UseCompatibleStateImageBehavior = false;
            this.controllerListBox.View = System.Windows.Forms.View.Details;
            // 
            // removeControllerButton
            // 
            this.removeControllerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeControllerButton.Location = new System.Drawing.Point(326, 134);
            this.removeControllerButton.Name = "removeControllerButton";
            this.removeControllerButton.Size = new System.Drawing.Size(108, 23);
            this.removeControllerButton.TabIndex = 7;
            this.removeControllerButton.Text = "Remove";
            this.removeControllerButton.UseVisualStyleBackColor = true;
            this.removeControllerButton.Click += new System.EventHandler(this.removeControllerButton_Click);
            // 
            // editControllerButton
            // 
            this.editControllerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editControllerButton.Location = new System.Drawing.Point(326, 49);
            this.editControllerButton.Name = "editControllerButton";
            this.editControllerButton.Size = new System.Drawing.Size(108, 23);
            this.editControllerButton.TabIndex = 6;
            this.editControllerButton.Text = "Edit...";
            this.editControllerButton.UseVisualStyleBackColor = true;
            this.editControllerButton.Click += new System.EventHandler(this.editControllerButton_Click);
            // 
            // newControllerButton
            // 
            this.newControllerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newControllerButton.Location = new System.Drawing.Point(326, 19);
            this.newControllerButton.Name = "newControllerButton";
            this.newControllerButton.Size = new System.Drawing.Size(108, 23);
            this.newControllerButton.TabIndex = 5;
            this.newControllerButton.Text = "New...";
            this.newControllerButton.UseVisualStyleBackColor = true;
            this.newControllerButton.Click += new System.EventHandler(this.newControllerButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 470);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "LOLFan";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_MoveOrResize);
            this.Move += new System.EventHandler(this.MainForm_MoveOrResize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.MainMenu mainMenu;
    private System.Windows.Forms.MenuItem fileMenuItem;
    private System.Windows.Forms.MenuItem exitMenuItem;
    private Aga.Controls.Tree.TreeColumn sensor;
    private Aga.Controls.Tree.TreeColumn value;
    private Aga.Controls.Tree.TreeColumn min;
    private Aga.Controls.Tree.TreeColumn max;
    private Aga.Controls.Tree.NodeControls.NodeIcon nodeImage;
    private Aga.Controls.Tree.NodeControls.NodeTextBox nodeTextBoxText;
    private Aga.Controls.Tree.NodeControls.NodeTextBox nodeTextBoxValue;
    private Aga.Controls.Tree.NodeControls.NodeTextBox nodeTextBoxMin;
    private Aga.Controls.Tree.NodeControls.NodeTextBox nodeTextBoxMax;
    private System.Windows.Forms.MenuItem viewMenuItem;
    private System.Windows.Forms.MenuItem plotMenuItem;
    private Aga.Controls.Tree.NodeControls.NodeCheckBox nodeCheckBox;
    private System.Windows.Forms.MenuItem helpMenuItem;
    private System.Windows.Forms.MenuItem aboutMenuItem;
    private System.Windows.Forms.MenuItem saveReportMenuItem;
    private System.Windows.Forms.MenuItem optionsMenuItem;
    private System.Windows.Forms.MenuItem hddMenuItem;
    private System.Windows.Forms.MenuItem minTrayMenuItem;
    private System.Windows.Forms.MenuItem separatorMenuItem;
    private System.Windows.Forms.ContextMenu treeContextMenu;
    private System.Windows.Forms.MenuItem startMinMenuItem;
    private System.Windows.Forms.MenuItem startupMenuItem;
    private System.Windows.Forms.SaveFileDialog saveFileDialog;
    private System.Windows.Forms.Timer timer;
    private System.Windows.Forms.MenuItem hiddenMenuItem;
    private System.Windows.Forms.MenuItem MenuItem1;
    private System.Windows.Forms.MenuItem columnsMenuItem;
    private System.Windows.Forms.MenuItem valueMenuItem;
    private System.Windows.Forms.MenuItem minMenuItem;
    private System.Windows.Forms.MenuItem maxMenuItem;
    private System.Windows.Forms.MenuItem temperatureUnitsMenuItem;
    private System.Windows.Forms.MenuItem webMenuItemSeparator;
    private System.Windows.Forms.MenuItem celsiusMenuItem;
    private System.Windows.Forms.MenuItem fahrenheitMenuItem;
    private System.Windows.Forms.MenuItem sumbitReportMenuItem;
    private System.Windows.Forms.MenuItem MenuItem2;
    private System.Windows.Forms.MenuItem resetMinMaxMenuItem;
    private System.Windows.Forms.MenuItem MenuItem3;
    //private System.Windows.Forms.MenuItem gadgetMenuItem;
    private System.Windows.Forms.MenuItem minCloseMenuItem;
    private System.Windows.Forms.MenuItem resetMenuItem;
    private System.Windows.Forms.MenuItem menuItem6;
    private System.Windows.Forms.MenuItem plotLocationMenuItem;
    private System.Windows.Forms.MenuItem plotWindowMenuItem;
    private System.Windows.Forms.MenuItem plotBottomMenuItem;
    private System.Windows.Forms.MenuItem plotRightMenuItem;
		private System.Windows.Forms.MenuItem webMenuItem;
    private System.Windows.Forms.MenuItem runWebServerMenuItem;
    private System.Windows.Forms.MenuItem serverPortMenuItem;
    private System.Windows.Forms.MenuItem menuItem5;
    private System.Windows.Forms.MenuItem mainboardMenuItem;
    private System.Windows.Forms.MenuItem cpuMenuItem;
    private System.Windows.Forms.MenuItem gpuMenuItem;
    private System.Windows.Forms.MenuItem fanControllerMenuItem;
    private System.Windows.Forms.MenuItem ramMenuItem;
    private System.Windows.Forms.MenuItem logSensorsMenuItem;
    private System.Windows.Forms.MenuItem logSeparatorMenuItem;
    private System.Windows.Forms.MenuItem loggingIntervalMenuItem;
    private System.Windows.Forms.MenuItem log1sMenuItem;
    private System.Windows.Forms.MenuItem log2sMenuItem;
    private System.Windows.Forms.MenuItem log5sMenuItem;
    private System.Windows.Forms.MenuItem log10sMenuItem;
    private System.Windows.Forms.MenuItem log30sMenuItem;
    private System.Windows.Forms.MenuItem log1minMenuItem;
    private System.Windows.Forms.MenuItem log2minMenuItem;
    private System.Windows.Forms.MenuItem log5minMenuItem;
    private System.Windows.Forms.MenuItem log10minMenuItem;
    private System.Windows.Forms.MenuItem log30minMenuItem;
    private System.Windows.Forms.MenuItem log1hMenuItem;
    private System.Windows.Forms.MenuItem log2hMenuItem;
    private System.Windows.Forms.MenuItem log6hMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private SplitContainerAdv splitContainer;
        private Aga.Controls.Tree.TreeViewAdv treeView;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private Overview overview;
        private System.Windows.Forms.TextBox lcdFormatText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button removeControllerButton;
        private System.Windows.Forms.Button editControllerButton;
        private System.Windows.Forms.Button newControllerButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox groupItemsListBox;
        private System.Windows.Forms.Button removeGroupButton;
        private System.Windows.Forms.Button addGroupButton;
        private System.Windows.Forms.CheckedListBox groupsListBox;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private GUI.FanControllerListView controllerListBox;
        private System.Windows.Forms.Button copyControllerButton;
    }
}

