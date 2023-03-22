using TownRush.Enums;
using TownRush.Helpers;
using UnityEngine;
using TMPro;
using System.Collections;

namespace TownRush.Buildings.Tower
{
    public class TowerController : BuildingAbstract
    {
        [field: SerializeField] public TowerHealthController HealthController { get; set; }
        public TowerSettings TowerSettings { get; private set; }
        private TowerInfo TowerInfo { get; set; }
        private int CurrentFloor { get; set; }

        [SerializeField] TextMeshProUGUI currentFloorTMP;

        public override void Initialize(TowerSettings towerSettings, TowerInfo towerInfo)
        {
            TowerSettings = towerSettings;
            TowerInfo = towerInfo;
            OwnerType = towerInfo.OwnerType;
            SetFloor(TowerInfo.StartFloor);
            SetHealthControllerHealth();

            HealthController.UpdateHealthEvent += Damaged;
            HealthController.CapturedEvent += SetOwner;

            ChangeMaterial(OwnerType);
            StartCoroutine(InitEndOfFrame());
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

        private void SetHealthControllerHealth()
        {
            HealthController = HealthController == null ? GetComponent<TowerHealthController>() : HealthController;
            HealthController.Initialize(OwnerType, CurrentFloor);
        }
    }
}