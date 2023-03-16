using cky.Reuseables.Level;
using TownRush.Buildings.Tower;
using UnityEngine;

namespace TownRush.Buildings
{
    public class BuildingSpawner
    {
        LevelSettings _levelSettings;
        BuildingAbstract _towerPrefab;

        public BuildingSpawner(LevelSettings levelSettings)
        {
            _levelSettings = levelSettings;
            _towerPrefab = _levelSettings.towerSettings.towerPrefab;

            for (int i = 0; i < _levelSettings.towersWillCreate.Length; i++)
            {
                CreateTower(_levelSettings.towersWillCreate[i]);
            }
        }

        public void CreateTower(TowerInfo towerInfo)
        {
            var tower = MonoBehaviour.Instantiate(_towerPrefab, towerInfo.initPos, Quaternion.identity);
            tower.Initialize(towerInfo);
        }
    }
}