/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>   

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LOLFan.Hardware;

namespace LOLFan.GUI
{
    public partial class Overview : UserControl
    {
        private List<OverviewItem> items;
        private PersistentSettings settings;

        public Overview()
        {
            InitializeComponent();

             items = new List<OverviewItem>();          
            
        }

        public void AddItem(OverviewItem item)
        {
            if (items.Contains(item)) return;

            if (item.GetType() == typeof(TemperatureOverviewItem)) {
                tempsBoxLayout.Controls.Add(item);                
            } else if (item.GetType() == typeof(FanOverviewItem)) {
                fanBoxLayout.Controls.Add(item);
            } else if (item.GetType() == typeof(OtherOverviewItem))
            {
                otherBoxLayout.Controls.Add(item);
            }
            items.Add(item);
        }

        public void AddSensorNode(SensorNode item)
        {
            if (this.ContainsSensor(item.Sensor)) return;

            OverviewItem oi = null;

            if (item.Sensor.SensorType == SensorType.Temperature)
            {
                oi = new TemperatureOverviewItem(item, this);
                tempsBoxLayout.Controls.Add(oi);
            }
            else if (item.Sensor.SensorType == SensorType.Fan)
            {
                oi = new FanOverviewItem(item, this);
                fanBoxLayout.Controls.Add(oi);
            }
            else
            {
                oi = new OtherOverviewItem(item, this);
                otherBoxLayout.Controls.Add(oi);
            }
            if (oi != null) items.Add(oi);
        }

        public bool ContainsSensor(ISensor s)
        {
            foreach(OverviewItem i in items)
            {
                if (i.SensorNode.Sensor == s || i.SensorNode.Sensor.Affector == s) return true;
            }
            return false;
        }

        public void RemoveItem(OverviewItem item)
        {
            if (!items.Contains(item)) return;
            tempsBoxLayout.Controls.Remove(item);
            fanBoxLayout.Controls.Remove(item);
        }

        public void UpdateItems()
        {
            foreach (OverviewItem i in items) i.UpdateAll();
        }

        public void Clear()
        {
            foreach(OverviewItem i in items)
            {
                this.RemoveItem(i);
                i.Dispose();
            }
            items.Clear();
        }
        
        public PersistentSettings Settings
        {
            get { return settings; }
            set
            {
                settings = value;
                if (settings != null)
                {
                    tempFanSplitContainer.SplitterDistance = settings.GetValue("Overview.Splitter1.Distance", 260);
                    splitContainer1.SplitterDistance = settings.GetValue("Overview.Splitter2.Distance", 300);
                }
            }
        }

        private void tempFanSplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (settings != null) settings.SetValue("Overview.Splitter1.Distance", tempFanSplitContainer.SplitterDistance);
        }
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (settings != null) settings.SetValue("Overview.Splitter2.Distance", splitContainer1.SplitterDistance);
        }

        public ToolTip ToolTip
        {
            get
            {
                return toolTip1;
            }
        }

    }
}
