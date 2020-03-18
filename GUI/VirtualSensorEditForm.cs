using LOLFan.Hardware;
using LOLFan.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LOLFan.GUI
{
    public partial class VirtualSensorEditForm : Form
    {
        private VirtualSensor sensor;
        private SensorType sensorType;
        private String valueStringInput;
        private int skip;



        public VirtualSensorEditForm(VirtualSensor sensor, ISettings settings)
        {
            this.sensor = sensor;
            InitializeComponent();
            sensorTypeComboBox.DataSource = System.Enum.GetValues(typeof(SensorType));
            if (sensor == null)
            {
                // For add-mode
                sensorType = SensorType.Temperature;
                valueStringTextBox.Text = "0";
                return;
            }

            // Check if a type change planned for next program start
            int type = (int)sensor.SensorType;
            int.TryParse(settings.GetValue(new Identifier(sensor.Identifier, "sensortype").ToString(), (int)(sensor.SensorType) + ""), out type);
            restartLabel.Visible = (SensorType)sensorTypeComboBox.SelectedItem != sensor.SensorType;
            sensorTypeComboBox.SelectedItem = (SensorType)type;

            valueStringTextBox.Text = sensor.ValueStringInput;

            skipNumericUpDown.Value = sensor.Skip;
        }
        

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (sensor != null)
            {
                // Update VirtualSensor
                sensor.ValueStringInput = valueStringTextBox.Text;
                sensor.SetSensorType((SensorType)sensorTypeComboBox.SelectedItem);
                sensor.Skip = (int) skipNumericUpDown.Value;
            }
            else
            {
                // Provide result data
                sensorType = (SensorType)sensorTypeComboBox.SelectedItem;
                valueStringInput = valueStringTextBox.Text;
                skip = (int)skipNumericUpDown.Value;
            }            

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void abortButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void sensorTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sensor != null)
            {
                restartLabel.Visible = (SensorType)sensorTypeComboBox.SelectedItem != sensor.SensorType;
            }
        }

        public SensorType SensorType
        {
            get
            {
                return sensorType;
            }
        }
        public String ValueStringInput
        {
            get
            {
                return valueStringInput;
            }
        }

        public int Skip
        {
            get
            {
                return skip;
            }
        }

    }
}
