using System;
using System.Collections.Generic;

namespace B25.EventSystem
{
    public class EventSystem
    {
        #region Action()

        private Dictionary<EventType, List<Action>> eventTable = new Dictionary<EventType, List<Action>>();

        internal void Subscribe(EventType eventType, Action method)
        {
            if (!eventTable.ContainsKey(eventType) || eventTable[eventType] == null)
                eventTable[eventType] = new List<Action>();

            eventTable[eventType].Add(method);
        }

        internal void Fire(EventType eventType)
        {
            if (eventTable != null || eventTable[eventType] != null)
            {
                var eventList = new List<Action>();

                if (eventTable.TryGetValue(eventType, out eventList))
                {
                    for (int i = 0; i < eventTable[eventType].Count; i++)
                    {
                        eventList[i]?.Invoke();
                    }
                }
            }
            else return;
        }

        internal void Unsubscribe(EventType eventType, Action method)
        {
            eventTable[eventType].Remove(method);
        }
        #endregion

        #region Action(T)

        private Dictionary<EventType, List<Action<object>>> objectEventTable = new Dictionary<EventType, List<Action<object>>>();

        internal void Subscribe(EventType eventType, Action<object> method)
        {
            if (!objectEventTable.ContainsKey(eventType) || objectEventTable[eventType] == null)
                objectEventTable[eventType] = new List<Action<object>>();

            objectEventTable[eventType].Add(method);
        }

        internal void Fire(EventType eventType, object obj)
        {
            if (objectEventTable != null || objectEventTable[eventType] != null)
            {
                var eventList = new List<Action<object>>();

                if (objectEventTable.TryGetValue(eventType, out eventList))
                {
                    for (int i = 0; i < objectEventTable[eventType].Count; i++)
                    {
                        eventList[i]?.Invoke(obj);
                    }
                }
            }
            else return;
        }

        internal void Unsubscribe(EventType eventType, Action<object> method)
        {
            objectEventTable[eventType].Remove(method);
        }
        #endregion
    }
}
