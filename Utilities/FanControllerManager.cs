/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>                          
	
*/

using LOLFan.Hardware;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LOLFan.Utilities
{
    class FanControllerManager
    {
        public static byte MAX_CONTROLLERS = 255;    // Absolute max 255 controllers
        public static byte INVALID_CONTROLLER = 255;

        private List<FanController> controllers;
        private List<FanController> active;

        private PersistentSettings settings;
        private List<ISensor> sensors;
        public Identifier Identifier = new Identifier("FanControllerManager");

        

        public FanControllerManager(List<ISensor> sensors, PersistentSettings settings)
        {
            this.sensors = sensors;
            this.settings = settings;

            active = new List<FanController>();
            controllers = new List<FanController>();

            // Load controllers
            for (byte i = 0; i < MAX_CONTROLLERS; i++)
            {
                if (settings.Contains(new Identifier("FanController", i + "", "name").ToString()))
                {
                    // Skip controllers with missing fan control
                    try
                    {
                        AddController(new FanController(i, sensors, settings));
                    }
                    catch (Exception) { }
                }
            }
        }

        public void AddController(FanController c)
        {
            if (controllers.Contains(c)) return;

            controllers.Add(c);
            c.enabledChanged += FanController_enabled_changed;
            FanController_enabled_changed(c, null);
        }


        public byte GetFreeControllerSlot()
        {
            for (byte i = 0; i < MAX_CONTROLLERS; i++)
            {
                for (byte j = 0; j < MAX_CONTROLLERS; j++)
                {
                    if (j >= controllers.Count) return i;
                    if (controllers[j].ID == i) break;
                }
            }
            return INVALID_CONTROLLER;
        }


        public void Update()
        {
            foreach (FanController c in active)
            {
                c.Update();
            }
        }

        public void SaveToSettings()
        {
            foreach (FanController c in controllers)
            {
                c.SaveToSettings();
            }
        }

        public List<FanController> Controllers
        {
            get
            {
                return controllers;
            }
        }


        public void FanController_enabled_changed(object sender, EventArgs e) {

            FanController c = (FanController)sender;
            if (c.Enabled)
            {
                // Disable all other controllers affecting the same IControl
                foreach(FanController fc in controllers)
                {
                    if (fc.Controlled == c.Controlled && fc != c && fc.Enabled)
                    {
                        fc.Enabled = false;
                        active.Remove(c);
                    }
                }
                active.Add(c);
            } else
            {
                active.Remove(c);
            }
        }

    }
}
