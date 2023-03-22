using TownRush.Enums;
using Unity.VisualScripting;
using UnityEngine;

namespace TownRush.Buildings.Tower
{
    public class TowerCostCanvasController : BuildingCostCanvasAbstract
    {
        [field: SerializeField] public TowerController TowerController { get; private set; }
        [field: SerializeField] private TowerSettings TowerSettings { get; set; }

        int _towerLevelIndex;

        private void Start()
        {
            TowerController.OwnerChanged += Captured;
        }

        public override void Initialize(OwnerTypes ownerType, int health)
        {

            Captured(ownerType, health);
        }

        private void Captured(OwnerTypes ownerType, int health)
        {
            CalculateLevel(health);
            CanvasActivate(ownerType);
            UpdateText();
        }

        private void CanvasActivate(OwnerTypes ownerType)
        {
            var bIsActive = ownerType == OwnerTypes.PLAYER ? true : false;

            canvas.SetActive(bIsActive);
        }

        private void CalculateLevel(int health)
        {
            var levelBaseFloors = TowerController.TowerSettings.LevelBaseFloors;
            var length = levelBaseFloors.Length - 1;
            var level = 0;

            for (int i = 0; i < length; i++)
            {
                if (health >= levelBaseFloors[i] && health < levelBaseFloors[i + 1])
                {
                    level = i + 1;
                    break;
                }

                if (health == levelBaseFloors[length])
                {
                    level = length + 1; // TODO: Control
                    break;
                }
            }
            Debug.Log(level);
            _towerLevelIndex = level;
        }

        protected override void UpdateText()
        {
            if (_towerLevelIndex >= TowerController.TowerSettings.UpgradeLevelCosts.Length)
            {
                textTmp.text = $"MAX";
            }
            else
            {
                textTmp.text = $"{TowerController.TowerSettings.UpgradeLevelCosts[_towerLevelIndex]}";
            }
        }
    }
}