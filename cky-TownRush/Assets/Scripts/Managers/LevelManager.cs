using cky.Reuseables.Level;
using TownRush.Board;
using TownRush.Buildings;

namespace TownRush.Managers
{
    public class LevelManager : LevelManagerAbstract
    {
        protected override void OnPerAwake()
        {
            base.OnPerAwake();
        }

        private void Start()
        {
            new BoardCreator(levelSettings);
            new BuildingSpawner(levelSettings);
        }
    }
}