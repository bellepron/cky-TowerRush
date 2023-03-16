using cky.Reuseables.Level;
using CKY.Pooling;
using TownRush.Buildings.Tower;
using UnityEngine;

namespace TownRush.Buildings
{
    public class BuildingSpawner
    {
        LevelSettings _levelSettings;
        Transform _towerPrefab;

        public BuildingSpawner(LevelSettings levelSettings)
        {
            _levelSettings = levelSettings;
            _towerPrefab = _levelSettings.TowerSettings.PrefabTr;

            for (int i = 0; i < _levelSettings.TowersWillCreate.Length; i++)
            {
                CreateTower(_levelSettings.TowersWillCreate[i]);
            }
        }

        public void CreateTower(TowerInfo towerInfo)
        {
            var towerTr = PoolManager.Instance.Spawn(_towerPrefab, towerInfo.InitPos, Quaternion.identity);
            //var towerTr = MonoBehaviour.Instantiate(_towerPrefab, towerInfo.initPos, Quaternion.identity);

            if (towerTr.TryGetComponent<BuildingAbstract>(out var buildingAbstract))
            {
                buildingAbstract.Initialize(towerInfo);
            }
        }
    }
}