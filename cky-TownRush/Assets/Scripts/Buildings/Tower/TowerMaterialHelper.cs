using TownRush.Managers;
using UnityEngine;

namespace TownRush.Buildings.Tower
{
    public static class TowerMaterialHelper
    {
        public static Material[] SetMaterials(TowerType type)
        {
            var towerSettings = LevelManager.Instance.levelSettings.towerSettings;

            switch (type)
            {
                case TowerType.EMPTY:
                    return towerSettings.emptyTowerMaterials;
                case TowerType.PLAYER:
                    return towerSettings.playerTowerMaterials;
                case TowerType.ENEMY1:
                    return towerSettings.enemy1TowerMaterials;
                case TowerType.ENEMY2:
                    return towerSettings.enemy2TowerMaterials;
                case TowerType.ENEMY3:
                    return towerSettings.enemy3TowerMaterials;

                default:
                    return towerSettings.emptyTowerMaterials;
            }
        }
    }
}