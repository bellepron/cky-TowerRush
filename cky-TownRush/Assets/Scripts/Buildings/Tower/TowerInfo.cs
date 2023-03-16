using UnityEngine;

namespace TownRush.Buildings.Tower
{
    [System.Serializable]
    public struct TowerInfo
    {
        public BuildingOwnerTypes buildingOwnerType;
        public Vector3 initPos;
        public int startFloor;

        public TowerInfo(BuildingOwnerTypes buildingOwnerType, Vector3 initPos, int startFloor)
        {
            this.buildingOwnerType = buildingOwnerType;
            this.initPos = initPos;
            this.startFloor = startFloor;

            SetTowerType(buildingOwnerType);
        }

        public void SetTowerType(BuildingOwnerTypes type) => buildingOwnerType = type;
    }
}