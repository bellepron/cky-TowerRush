using TownRush.Enums;
using TownRush.Helpers;
using UnityEngine;
using TMPro;

namespace TownRush.Buildings.Tower
{
    public class TowerController : BuildingAbstract
    {
        [field: SerializeField] public TowerHealthController HealthController { get; set; }
        private TowerSettings TowerSettings { get; set; }
        private TowerInfo TowerInfo { get; set; }
        private int CurrentFloor { get; set; }

        [SerializeField] TextMeshProUGUI currentFloorTMP;

        public override void Initialize(TowerSettings towerSettings, TowerInfo towerInfo)
        {
            TowerSettings = towerSettings;
            TowerInfo = towerInfo;
            OwnerType = towerInfo.OwnerType;
            SetFloor(TowerInfo.StartFloor);
            SetHealth();

            HealthController.UpdateHealthEvent += Damaged;
            HealthController.CapturedEvent += Captured;

            ChangeMaterial(TowerInfo.OwnerType);
        }

        private void OnDisable()
        {
            HealthController.UpdateHealthEvent -= Damaged;
            HealthController.CapturedEvent -= Captured;
        }

        private void Damaged(int currentHealth)
        {
            SetFloor(currentHealth);
        }

        private void Captured(OwnerTypes damageFromWho, int capturedHealth)
        {
            SetFloor(capturedHealth);
            SetOwnerType(damageFromWho);
            ChangeMaterial(damageFromWho);
        }

        public override void SetOwnerType(OwnerTypes ownerType)
        {
            TowerInfo.SetTowerType(ownerType);
            OwnerType = ownerType;
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

        private void SetHealth()
        {
            HealthController = HealthController == null ? GetComponent<TowerHealthController>() : HealthController;
            HealthController.Initialize(OwnerType, CurrentFloor);
        }
    }
}