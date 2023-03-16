using TownRush.Managers;
using UnityEngine;

namespace TownRush.Buildings.Tower
{
    public static class TowerMaterialHelper
    {
        public static Material[] SetMaterials(TowerType type)
        {
            var towerSettings = GameManager.Instance.levelSettings.TowerSettings;

            switch (type)
            {
                case TowerType.EMPTY:
                    return towerSettings.EmptyTowerMaterials;
                case TowerType.PLAYER:
                    return towerSettings.PlayerTowerMaterials;
                case TowerType.ENEMY1:
                    return towerSettings.Enemy1TowerMaterials;
                case TowerType.ENEMY2:
                    return towerSettings.Enemy2TowerMaterials;
                case TowerType.ENEMY3:
                    return towerSettings.Enemy3TowerMaterials;

                default:
                    return towerSettings.EmptyTowerMaterials;
            }
        }
    }
}