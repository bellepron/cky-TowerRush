using cky.Reuseables.Singleton;
using System;

namespace TownRush.Managers
{
    public class EventManager : SingletonPersistent<EventManager>
    {
        public static event Action GameEnd, GameSuccess, GameFail;

        protected override void OnPerAwake() => ResetEvents();

        protected virtual void ResetEvents()
        {
            GameEnd = null;
            GameSuccess = null;
            GameFail = null;
        }

        #region Core

        public void GameEndEvent() => GameEnd?.Invoke();
        public void GameSuccessEvent() => GameSuccess?.Invoke();
        public void GameFailEvent() => GameFail?.Invoke();

        #endregion
    }
}