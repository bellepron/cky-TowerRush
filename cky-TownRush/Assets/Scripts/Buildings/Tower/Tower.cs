using TownRush.Enums;
using TownRush.Helpers;
using UnityEngine;
using TMPro;
using TownRush.Interfaces;

namespace TownRush.Buildings.Tower
{
    public class Tower : BuildingAbstract
    {
        private TowerInfo TowerInfo { get; set; }
        private int CurrentFloor { get; set; }

        [SerializeField] TextMeshProUGUI currentFloorTMP;

        public override void Initialize(TowerInfo towerInfo)
        {
            TowerInfo = towerInfo;
            OwnerType = towerInfo.OwnerType;
            SetFloor(TowerInfo.StartFloor);

            ChangeMaterial(TowerInfo.OwnerType);
        }

        public override void SetOwnerType(OwnerTypes ownerType)
        {
            TowerInfo.SetTowerType(ownerType);

            ChangeMaterial(ownerType);
        }

        public override void ChangeMaterial(OwnerTypes ownerType)
        {
            MeshRenderer.materials = MaterialHelper.SetTowerMaterials(ownerType);
        }

        private void SetFloor(int currentFloor)
        {
            CurrentFloor = currentFloor;
            ModelTr.localPosition = new Vector3(0, CurrentFloor, 0);
            //currentFloorTMP.text = $"{_currentFloor}";
        }
    }
}