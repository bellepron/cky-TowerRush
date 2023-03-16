using TMPro;
using TownRush.Helpers;
using UnityEngine;

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
            SetFloor(TowerInfo.startFloor);

            ChangeMaterial(TowerInfo.buildingOwnerType);
        }

        public override void SetBuildingOwnerType(BuildingOwnerTypes buildingOwnerType)
        {
            TowerInfo.SetTowerType(buildingOwnerType);

            ChangeMaterial(buildingOwnerType);
        }

        public override BuildingOwnerTypes GetBuildingOwnerType() => TowerInfo.buildingOwnerType;

        public override void ChangeMaterial(BuildingOwnerTypes buildingOwnerType)
        {
            MeshRenderer.materials = MaterialHelper.SetTowerMaterials(buildingOwnerType);
        }

        private void SetFloor(int currentFloor)
        {
            CurrentFloor = currentFloor;
            ModelTr.localPosition = new Vector3(0, CurrentFloor, 0);
            //currentFloorTMP.text = $"{_currentFloor}";
        }
    }
}