using LOLFan.Hardware;
using System;
using System.Collections.Generic;
using System.Text;

namespace LOLFan.Events
{
    class Event
    {
        private static int MAX_TRIGGERS = 16;
        private static int MAX_ACTIONS = 32;

        private Identifier identifier;
        private string name;

        private List<EventTrigger> trigger;
        private List<EventAction> actions;

        public Event(Identifier identifier)
        {
            this.identifier = identifier;
        }

       

        public static void LoadEvent(int id, PersistentSettings settings)
        {
            Event e = new Event(new Identifier("event", id + ""));
            e.Name = settings.GetValue(new Identifier(e.Identifier, "name").ToString(), float.MaxValue.ToString());

            for (int i = 0; i < MAX_TRIGGERS; i++)
            {
                if (settings.Contains(new Identifier(e.Identifier, "trigger", i + "", "type").ToString()))
                {
                    EventTrigger t = EventTrigger.LoadTrigger(e, i, settings);
                }
            }

        }

        public Identifier Identifier { get => identifier; set => identifier = value; }
        public string Name { get => name; set => name = value; }
    }
   
}
