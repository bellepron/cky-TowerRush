using cky.Reuseables.Level;
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
            new BuildingSpawner(levelSettings);
        }
    }
}