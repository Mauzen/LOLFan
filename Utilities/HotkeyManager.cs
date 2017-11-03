/*
 
  This Source Code Form is subject to the terms of the Mozilla Public
  License, v. 2.0. If a copy of the MPL was not distributed with this
  file, You can obtain one at http://mozilla.org/MPL/2.0/.
 
  Copyright (C) 2017 Michel Soll <msoll@web.de>                          
	
*/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace LOLFan.Utilities
{
    public class HotkeyManager
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id,int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int MOD_CONTROL = 0x0002;
        const int MOD_SHIFT = 0x0004;
        const int WM_HOTKEY = 0x0312;

        private Form parent;
        private PersistentSettings settings;

        private ushort topHandle = 1;
        private Dictionary<ushort, Hotkey> hotkeys;


        public HotkeyManager (Form parent, PersistentSettings settings)
        {
            this.parent = parent;
            this.settings = settings;

            hotkeys = new Dictionary<ushort, Hotkey>();

            parent.FormClosing += Form_FormClosing;
        }


        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (ushort i = 1; i < topHandle; i++)
            {
                if (hotkeys[i] != null)
                {
                    UnregisterHotkey(hotkeys[i]);
                }
            }
            //foreach (KeyValuePair<ushort, Hotkey> h in hotkeys)
            //{
            //    UnregisterHotkey(h.Value);
            //}
        }


        public Hotkey RegisterHotkey(string description, short modifiers, int key, EventHandler action)
        {
            Hotkey h = new Hotkey(description, modifiers, key, topHandle, action);            

            RegisterHotKey(parent.Handle, topHandle, modifiers, key);
            hotkeys[topHandle] = h;

            topHandle++;

            return h;
        }

        public void UnregisterHotkey(Hotkey h)
        {
            UnregisterHotKey(parent.Handle, h.Handle);
            hotkeys.Remove(h.Handle);
        }

        public void ProcessHotkey(ushort handle)
        {
            hotkeys[handle].Action.Invoke(parent, null);
        }
    }
}
