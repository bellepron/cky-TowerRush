using UnityEngine;

namespace TownRush.Buildings.Tower
{
    [System.Serializable]
    public struct TowerInfo
    {
        public TowerType towerType;
        public Vector3 initPos;
        public int startFloor;

        public TowerInfo(TowerType towerType, Vector3 initPos, int startFloor)
        {
            this.towerType = towerType;
            this.initPos = initPos;
            this.startFloor = startFloor;

            SetTowerType(towerType);
        }

        public void SetTowerType(TowerType type) => towerType = type;
    }
}