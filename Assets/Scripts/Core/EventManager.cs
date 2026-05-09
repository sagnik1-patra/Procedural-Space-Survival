using System;
using System.Collections.Generic;

namespace SpaceSurvival.Core
{
    public static class EventManager
    {
        private static Dictionary<string, Action<object>> eventDictionary = new Dictionary<string, Action<object>>();

        public static void Subscribe(string eventName, Action<object> listener)
        {
            if (eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
            {
                thisEvent += listener;
                eventDictionary[eventName] = thisEvent;
            }
            else
            {
                thisEvent += listener;
                eventDictionary.Add(eventName, thisEvent);
            }
        }

        public static void Unsubscribe(string eventName, Action<object> listener)
        {
            if (eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
            {
                thisEvent -= listener;
                eventDictionary[eventName] = thisEvent;
            }
        }

        public static void Trigger(string eventName, object data = null)
        {
            if (eventDictionary.TryGetValue(eventName, out Action<object> thisEvent))
            {
                thisEvent?.Invoke(data);
            }
        }
    }

    public static class GameEvents
    {
        public const string ON_PLANET_ENTERED = "OnPlanetEntered";
        public const string ON_PLANET_EXITED = "OnPlanetExited";
        public const string ON_RESOURCE_MINED = "OnResourceMined";
        public const string ON_PLAYER_DEATH = "OnPlayerDeath";
        public const string ON_INVENTORY_CHANGED = "OnInventoryChanged";
    }
}
