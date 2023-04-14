using cky.Reuseables.Level;
using EZ_Pooling;
using TownRush.Buildings.Tower;
using UnityEngine;

namespace TownRush.Buildings
{
    public class BuildingSpawner
    {
        private LevelSettings LevelSettings { get; set; }
        private TowerSettings TowerSettings { get; set; }
        private Transform TowerPrefabTr { get; set; }

        public BuildingSpawner(LevelSettings levelSettings)
        {
            LevelSettings = levelSettings;
            TowerSettings = LevelSettings.TowerSettings;
            TowerPrefabTr = TowerSettings.PrefabTr;

            for (int i = 0; i < LevelSettings.TowersWillCreate.Length; i++)
            {
                CreateTower(LevelSettings.TowersWillCreate[i]);
            }
        }

        public void CreateTower(TowerInfo towerInfo)
        {
            var towerTr = EZ_PoolManager.Spawn(TowerPrefabTr, towerInfo.InitPos, Quaternion.identity);

            if (towerTr.TryGetComponent<BuildingAbstract>(out var buildingAbstract))
            {
                buildingAbstract.Initialize(TowerSettings, towerInfo);
            }
        }
    }
}