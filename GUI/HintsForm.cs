/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>                          
	
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LOLFan.GUI
{
    public partial class HintsForm : Form
    {
        private readonly string[] HintsTitles =
        {
            "Getting started",
            //"Harware Monitor",
            "Fan Control Settings",
            "Fan Controller",
            "Value strings",
            "GPU Fan control"

        };

        private readonly string[] HintsText =
        {
            @"Lol!
There is a series of hints available here to give a quick introduction for new users.
Please remember that even though I tried to make it as simple as possible, this software is still mainly made for advanced users.

Once you've tested this a bit, please send a report and explain if everything is working fine (File->Submit report).

This is the Overview-Tab, to give a quick look at certain selected
sensors. You can set which sensors are shown here in the 'Monitor'-Tab
through the context menu (Right click->Show in Overview)

If you want to use this software to control your fans:
    1. Rename all relevant sensors properly (optional, but makes things easier)
    2. Select the proper fan for each fan control (Monitor->Controller->Settings)
    3. Calibrate the fans (optional, but pretty useful)
    4. Create fan controllers (Fan Controller->New)",

           // @"The hardware monitor, showing all available Sensors. Further display settings and a graphical plot is available in the 'View'-menu.",

            @"Here you can configure the fan control, depending on which features are supported by your hardware.
First you should make sure the 'Controlled fan' selection is correct, by altering the fan control's speed (Monitor->Context Menu->Control) and watching which fan's RPM changes.

Below is the fan calibration, which measures the fans speeds, to allow a true linear control. Else, most fans (3-pin AND 4-pin) dont have a linear speed curve (e.g. 50% duty is not 50% speed), making it hard to fine tune automatic fan controllers. It is highly suggested to run this for all the fans you want to control with this software.",

            @"Here you may configure the automatic speed control for a fan.
This is done by a speed curve, that covers a certain range. Horizontal X-Value is the input, Y-Value is the corresponding speed. If the fan control uses calibrated speed, it is linear, else it is the default fan speed duty.
Left-click near the curve to create a new point, or Left-click on a point to drag it. Right-clicking on a point removes it.
Middle-Mouse-Button pans the whole curve up/down.
Middle-Mouse-Button+ALT scales the curve with the left-most point being the base.
Middle-Mouse-Button+CTRL scales the curve with the right-most point being the base.

First, select which fan control should be affected by this.
Then you've got two options:
either control it by the value of a single sensors (e.g. the CPU temperature, or speed of another fan),
or control it by a value string. A value string is a mathematical formula that may contain sensor identifiers. This is very useful for fine-tuning. Check the next hint for detailed information about value strings. 

The Value/Duty label simply displays the current input value, and the corresponding output speed, according to the curve.

Hysteresis sets a minimum delta value. The fan speed will only be updated, if the input value changed by at least this value.",

            @"Wall-of-text-Warning. This topic is a little complex.
Value strings can be considered as mathematical formula with certain variables, and - in my opinion - are one of the most useful things in this software.
Those variables mainly are sensor identifiers that get replaced by their sensor's current value. So they allow to perform simple or complex mathematical operation on sensor values.
All variables have to be encapsuled in braces {}.

Sensor variables
Sensor variables simply contain the identifier of the sensor. This can be aquired via the Monitor-tab in the context menu of a sensor. Click it to copy it, then just paste it where needed.
{some/example/sensor} e.g. would be replaced by the current value of that sensor.
However, there are certain modifiers available, that dont return the current value, but other infos for that sensor.
{some/example/sensor,max} returns the maximum measured value for that sensor
{some/example/sensor,min} returns the minimum measured value for that sensor

Examples
So here are some examples. Note that variables are just examples and copy-pasting won't work.

({example/cpu/temperature} + {example/mainboard/temperature}) / 2
Average temperature, e.g. for case fan control

({example/cpu/temperature} + 3 * {example/gpu/temperature}) / 4
Weighted average temperature, e.g. if a case fan rather cools the GPU than CPU. So the fan speed isnt affected much by the CPU temperature, keeping the noise down if GPU is unused.

{example/mainboard/temperature} - {example/ambient/temperature}
When an ambient temperature sensor is available, this can be used to minimize fan noise. Air cooling efficiency depends on the air temperature difference. So when CPU is 40°C and air is 35°C theres no point in running the fan on high speed, cause it wont cool much anyways. When CPU is 40°C and air is 20°C however, cooling efficiency is much higher, so higher fan speed actually cools the CPU down.
",

            @"Setting the speed of GPU fans works using the corresponding API of their vendor.
For most NVIDIA and ATI graphic cards setting the speed via LOLFan will override the cards automatic fan control. This means that theres a risk of overheating if you dont set up an automatic fan controller for the GPU in LOLFan. Please keep this in mind.
The override can be reset, thus the card's automatic control can be reactivated, by choosing 'Default' mode for the GPU control (Monitor->Your GPU->Controls->GPU Fan, Right-CLick->Control->Default). Make sure to do that unless you set up an own fan controller for the GPU in LOLFan, to prevent hardware damage."


        };


        public enum Hints
        {
            GettingStarted,
            HardwareMonitor,
            FanControlSettings,
            FanController,
            ValueStrings,
            GPUFanControl
        };


        private Hints curHint;

        public HintsForm() : this((Hints)0, false) { }

        public HintsForm(Hints h, bool allowHide=true)
        {
            if (allowHide && Program.Settings.GetValue("Hints/" + h, false) == true) return;

            InitializeComponent();

            showHint(h, allowHide);

            this.Show();
        }

        private void showHint(Hints h, bool allowHide)
        {
            hintNumLabel.Text = HintsTitles[(int)h] + " (" + ((int)h+1) + " of " + HintsTitles.Length + ")";
            hintText.Text = HintsText[(int)h];

            if (!allowHide) hideHintBox.Visible = false;

            curHint = h;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            showHint((Hints)((int)(curHint + 1) % HintsTitles.Length), false);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            if ((int)(curHint - 1) < 0)
            {
                showHint((Hints)HintsTitles.Length-1, false);
            } else
            {
                showHint(curHint - 1, false);
            }
            
        }

        private void hideHintBox_CheckedChanged(object sender, EventArgs e)
        {
            Program.Settings.SetValue("Hints/" + curHint, hideHintBox.Checked);
        }

        private void HintsForm_FormClosing(object sender, EventArgs e)
        {
           // this.Dispose(true);
        }
    }
}
