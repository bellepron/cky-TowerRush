using System.Collections;
using TownRush.Helpers;
using TownRush.Enums;
using UnityEngine;
using System;
using TMPro;

namespace TownRush.Buildings.Tower
{
    public class TowerController : BuildingAbstract
    {
        public event Action<OwnerTypes, int> OwnerChanged;

        [field: SerializeField] private TowerHealthController HealthController { get; set; }
        [field: SerializeField] private TowerCostCanvasController CostCanvasController { get; set; }
        public TowerSettings TowerSettings { get; private set; }
        private TowerInfo TowerInfo { get; set; }
        private int CurrentFloor { get; set; }

        [SerializeField] TextMeshProUGUI currentFloorTMP;

        private void Start()
        {
            HealthController = HealthController ?? GetComponent<TowerHealthController>();
            CostCanvasController = CostCanvasController ?? GetComponent<TowerCostCanvasController>();
        }

        public override void Initialize(TowerSettings towerSettings, TowerInfo towerInfo)
        {
            TowerSettings = towerSettings;
            TowerInfo = towerInfo;
            OwnerType = towerInfo.OwnerType;
            CurrentFloor = towerInfo.StartFloor;
            SetFloor(TowerInfo.StartFloor);
            HealthController?.Initialize(OwnerType, CurrentFloor);
            CostCanvasController?.Initialize(OwnerType, CurrentFloor);

            HealthController.UpdateHealthEvent += Damaged;
            HealthController.CapturedEvent += SetOwner;

            ChangeMaterial(OwnerType);
            StartCoroutine(InitEndOfFrame());

            OwnerChanged?.Invoke(OwnerType, CurrentFloor);
        }

        IEnumerator InitEndOfFrame()
        {
            yield return new WaitForEndOfFrame();
            SetTileColors(OwnerType);
        }

        private void Damaged(int currentHealth)
        {
            SetFloor(currentHealth);
        }

        private void SetOwner(OwnerTypes damageFromWho, int capturedHealth)
        {
            SetTileColors(damageFromWho);

            SetFloor(capturedHealth);
            SetOwnerType(damageFromWho);
            ChangeMaterial(damageFromWho);

            OwnerChanged?.Invoke(damageFromWho, capturedHealth);
        }

        private void SetTileColors(OwnerTypes conqueredByWho)
        {
            foreach (var item in OwnedTiles)
            {
                item.SetOwnerType(conqueredByWho);
            }
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
    }
}