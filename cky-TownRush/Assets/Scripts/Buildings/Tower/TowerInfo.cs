using TownRush.Enums;
using UnityEngine;

namespace TownRush.Buildings.Tower
{
    [System.Serializable]
    public struct TowerInfo
    {
        [field: SerializeField] public OwnerTypes OwnerType { get; set; }
        [field: SerializeField] public Vector3 InitPos { get; set; }
        [field: SerializeField] public int StartFloor { get; set; }

        public TowerInfo(OwnerTypes ownerType, Vector3 initPos, int startFloor)
        {
            this.OwnerType = ownerType;
            this.InitPos = initPos;
            this.StartFloor = startFloor;

            SetTowerType(ownerType);
        }

        public void SetTowerType(OwnerTypes type) => OwnerType = type;
    }
}