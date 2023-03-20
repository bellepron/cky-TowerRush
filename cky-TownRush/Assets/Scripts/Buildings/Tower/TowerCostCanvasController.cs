using UnityEngine;

namespace TownRush.Buildings.Tower
{
    public class TowerCostCanvasController : BuildingCostCanvasAbstract
    {
        [field: SerializeField] public TowerController TowerController { get; private set; }
        public override void Initialize(int level)
        {
            UpdateText(level);
        }

        private void Upgrade(int level)
        {
            UpdateText(level);
        }

        protected override void UpdateText(int level)
        {
            textTmp.text = $"{TowerController.TowerSettings.UpgradeLevelCosts[level]}";
        }
    }
}