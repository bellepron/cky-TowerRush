using cky.Reuseables.Managers;
using System;
using TownRush.Interfaces;

namespace TownRush.Managers
{
    public class EventManager : EventManagerAbstract<EventManager>
    {
        public static readonly EventManager Instance = new EventManager();

        public static event Action UpdateTileColors;

        public static event Action<ITarget> AddTarget;
        public static event Action<ITarget> RemoveTarget;

        public void TriggerUpdateTileColors() => UpdateTileColors?.Invoke();

        public void TriggerAddTarget(ITarget target) => AddTarget?.Invoke(target);
        public void TriggerRemoveTarget(ITarget target) => RemoveTarget?.Invoke(target);
    }
}