using TownRush.Buildings;
using TownRush.Managers;
using UnityEngine;

namespace TownRush.Helpers
{
    public static class MaterialHelper
    {
        public static Material SetTileMaterial(BuildingOwnerTypes type)
        {
            var settings = GameManager.Instance.levelSettings.TileSettings;

            switch (type)
            {
                case BuildingOwnerTypes.EMPTY:
                    return settings.EmptyTileMat;
                case BuildingOwnerTypes.PLAYER:
                    return settings.PlayerTileMat;
                case BuildingOwnerTypes.ENEMY1:
                    return settings.EnemyTileMats[0];
                case BuildingOwnerTypes.ENEMY2:
                    return settings.EnemyTileMats[1];
                case BuildingOwnerTypes.ENEMY3:
                    return settings.EnemyTileMats[2];

                default:
                    return settings.EmptyTileMat;
            }
        }

        public static Material[] SetTowerMaterials(BuildingOwnerTypes type)
        {
            var settings = GameManager.Instance.levelSettings.TowerSettings;

            switch (type)
            {
                case BuildingOwnerTypes.EMPTY:
                    return settings.EmptyTowerMaterials;
                case BuildingOwnerTypes.PLAYER:
                    return settings.PlayerTowerMaterials;
                case BuildingOwnerTypes.ENEMY1:
                    return settings.Enemy1TowerMaterials;
                case BuildingOwnerTypes.ENEMY2:
                    return settings.Enemy2TowerMaterials;
                case BuildingOwnerTypes.ENEMY3:
                    return settings.Enemy3TowerMaterials;

                default:
                    return settings.EmptyTowerMaterials;
            }
        }
    }
}