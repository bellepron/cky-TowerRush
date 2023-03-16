using TownRush.Buildings.Tower;
using TownRush.Managers;
using TownRush.Enums;
using TownRush.Board;
using UnityEngine;

namespace TownRush.Helpers
{
    public static class MaterialHelper
    {
        #region Settings

        private static TileSettings _tileSettings;
        private static TileSettings TileSettings
        {
            get
            {
                if (_tileSettings == null)
                {
                    _tileSettings = GameManager.Instance.levelSettings.TileSettings;
                }

                return _tileSettings;
            }
        }

        private static TowerSettings _towerSettings;
        private static TowerSettings TowerSettings
        {
            get
            {
                if (_towerSettings == null)
                {
                    _towerSettings = GameManager.Instance.levelSettings.TowerSettings;
                }

                return _towerSettings;
            }
        }

        #endregion

        public static Material SetTileMaterial(OwnerTypes ownerType)
        {
            switch (ownerType)
            {
                case OwnerTypes.EMPTY:
                    return TileSettings.EmptyTileMat;
                case OwnerTypes.PLAYER:
                    return TileSettings.PlayerTileMat;
                case OwnerTypes.ENEMY1:
                    return TileSettings.EnemyTileMats[0];
                case OwnerTypes.ENEMY2:
                    return TileSettings.EnemyTileMats[1];
                case OwnerTypes.ENEMY3:
                    return TileSettings.EnemyTileMats[2];

                default:
                    return TileSettings.EmptyTileMat;
            }
        }

        public static Material[] SetTowerMaterials(OwnerTypes ownerType)
        {
            switch (ownerType)
            {
                case OwnerTypes.EMPTY:
                    return TowerSettings.EmptyTowerMaterials;
                case OwnerTypes.PLAYER:
                    return TowerSettings.PlayerTowerMaterials;
                case OwnerTypes.ENEMY1:
                    return TowerSettings.Enemy1TowerMaterials;
                case OwnerTypes.ENEMY2:
                    return TowerSettings.Enemy2TowerMaterials;
                case OwnerTypes.ENEMY3:
                    return TowerSettings.Enemy3TowerMaterials;

                default:
                    return TowerSettings.EmptyTowerMaterials;
            }
        }
    }
}