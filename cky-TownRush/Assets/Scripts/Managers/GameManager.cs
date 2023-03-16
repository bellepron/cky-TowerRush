using cky.Reuseables.Managers;
using TownRush.Board;
using TownRush.Buildings;

namespace TownRush.Managers
{
    public class GameManager : GameManagerAbstract
    {
        protected override void OnPerAwake()
        {
            base.OnPerAwake();
        }

        private void Start()
        {
            new EventManager();
            new BoardCreator(levelSettings);
            new BuildingSpawner(levelSettings);
        }
    }
}