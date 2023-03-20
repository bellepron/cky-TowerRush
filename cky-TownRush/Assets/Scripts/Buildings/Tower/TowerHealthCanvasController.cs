using UnityEngine;

namespace TownRush.Buildings.Tower
{
    [RequireComponent(typeof(TowerHealthController))]
    public class TowerHealthCanvasController : BuildingHealthCanvasAbstract
    {
        [field: SerializeField] private TowerHealthController HealthController { get; }

        public override void UpdateText(int health)
        {
            textTmp.text = $"{health}";
        }
    }
}