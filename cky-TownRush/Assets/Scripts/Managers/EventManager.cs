using cky.Reuseables.Managers;
using System;

namespace TownRush.Managers
{
    public class EventManager : EventManagerAbstract<EventManager>
    {
        public static readonly EventManager Instance = new EventManager();
    }
}