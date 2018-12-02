using LOLFan.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LOLFan.GUI
{
    public partial class LCDTextForm : Form
    {
        private DisplayConnector lcd;

        public LCDTextForm(DisplayConnector lcd)
        {
            InitializeComponent();

            this.lcd = lcd;

            for (int i = 0; i < lcd.Text.Count; i++)
            {
                sensorStringList.Items.Add(i + "");
                if (i == lcd.CurText) sensorStringList.SetItemChecked(i, true);
            }

            sensorStringList.ItemCheck += SensorStringList_ItemCheck;
        }

        private void SensorStringList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            sensorStringList.ItemCheck -= SensorStringList_ItemCheck;
            if (e.NewValue == CheckState.Unchecked) e.NewValue = CheckState.Checked;
            else if (e.NewValue == CheckState.Checked)
            {
                lcd.CurText = e.Index;
                for (int i = 0; i < sensorStringList.Items.Count; i++) sensorStringList.SetItemChecked(i, false);
            }
            sensorStringList.ItemCheck += SensorStringList_ItemCheck;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            lcd.AddSensorString("-");
            sensorStringList.Items.Add(lcd.Text.Count - 1);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (sensorStringList.SelectedIndex == -1) return;
            lcd.RemoveSensorString(sensorStringList.SelectedIndex);
            sensorStringList.Items.RemoveAt(sensorStringList.Items.Count - 1);
            sensorStringList_SelectedIndexChanged(sender, e);
        }

        private void sensorStringList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sensorStringList.SelectedIndex == -1)
            {
                sensorStringTextBox.Text = "";
                previewTextBox.Text = "";
                return;
            }
            sensorStringTextBox.Text = lcd.Text[sensorStringList.SelectedIndex].Input;
            previewTextBox.Text = lcd.Text[sensorStringList.SelectedIndex].Output;
        }

        private void sensorStringTextBox_TextChanged(object sender, EventArgs e)
        {
            if (sensorStringList.SelectedIndex == -1) return;
            lcd.ChangeSensorStringInput(sensorStringList.SelectedIndex, sensorStringTextBox.Text);
            previewTextBox.Text = lcd.Text[sensorStringList.SelectedIndex].Output;
            
        }
    }
}
