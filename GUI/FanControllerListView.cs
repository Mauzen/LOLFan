/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2018 Michel Soll <msoll@web.de>                          
	
*/

using LOLFan.Hardware;
using LOLFan.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LOLFan.GUI
{
    public class FanControllerListView : ListView
    {
        private List<IControl> controls;
        private List<FanController> controllers;

        public FanControllerListView()
        {
            this.CheckBoxes = true;
            this.UseCompatibleStateImageBehavior = false;
            this.Columns.Add(new ColumnHeader());
            this.HeaderStyle = ColumnHeaderStyle.None;
            this.MultiSelect = false;
            this.View = View.Details;

            this.controllers = new List<FanController>();
            this.controls = new List<IControl>();
        }


        public void AddItem(FanController controller)
        {
            if (controller == null || controller.Controlled == null) return;

            ListViewGroup g = GetGroup(controller.Controlled);

            ListViewItem item = new ListViewItem(controller.Name, g);
            item.Checked = controller.Enabled;
            this.Items.Add(item);
            controllers.Add(controller);

            this.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            controller.enabledChanged += UpdateFanControllerEnabled;
            controller.NameChanged += UpdateFanControllerName;
            controller.ControlChanged += UpdateFanControllerControl;
        }

        public void RemoveItem(FanController controller)
        {
            int idx = controllers.IndexOf(controller);
            if (idx == -1) return;

            this.Items.RemoveAt(idx);
            controllers.RemoveAt(idx);

            controller.enabledChanged -= UpdateFanControllerEnabled;
            controller.NameChanged -= UpdateFanControllerName;
            controller.ControlChanged -= UpdateFanControllerControl;
        }



        public void UpdateFanControllerEnabled(object sender, EventArgs e)
        {
            FanController c = (FanController)sender;
            int idx = controllers.IndexOf(c);
            if (idx == -1) return;

            this.Items[idx].Checked = controllers[idx].Enabled;
            this.Invalidate();
        }

        public void UpdateFanControllerName(object sender, EventArgs e)
        {
            FanController c = (FanController)sender;
            int idx = controllers.IndexOf(c);
            if (idx == -1) return;

            this.Items[idx].Text = controllers[idx].Name;
            this.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.Invalidate();
        }

        public void UpdateFanControllerControl(object sender, EventArgs e)
        {
            FanController c = (FanController)sender;
            int idx = controllers.IndexOf(c);
            if (idx == -1) return;

            this.Items[idx].Group = GetGroup(c.Controlled);
        }

        public FanController GetSelectedFanController()
        {
            int idx = this.SelectedIndices[0];
            if (idx == -1) return null;
            return controllers[idx];
        }

        // Either return the group corresponding to the IControl,
        // Or add a new Group if it didnt exist yet.
        private ListViewGroup GetGroup(IControl c)
        {
            int idx = controls.IndexOf(c);

            if (idx > -1)
            {
                return this.Groups[idx];
            } else
            {
                ISensor s = SharedData.AllSensors.GetByControl(c);
                ListViewGroup g;
                if (s == null)
                {
                    g = new ListViewGroup(this.Groups.Count + "");
                }
                else
                {
                    g = new ListViewGroup(s.Name);
                }
                this.Groups.Add(g);
                controls.Add(c);
                return g;
            }
        }

    }
}
