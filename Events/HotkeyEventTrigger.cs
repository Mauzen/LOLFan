using System;
using System.Collections.Generic;
using System.Text;
using LOLFan.Hardware;
using LOLFan.Utilities;

namespace LOLFan.Events
{
    class HotkeyEventTrigger : EventTrigger
    {
        private Hotkey hotkey;

        public HotkeyEventTrigger (Identifier identifier, TriggerType type, string name, string description) : base(identifier, type, name, description)
        {

        }


    }
}
