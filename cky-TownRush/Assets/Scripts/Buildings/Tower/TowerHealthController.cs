using TownRush.Abstracts;
using UnityEngine;

namespace TownRush.Buildings.Tower
{
    public class TowerHealthController : HealthControllerAbstract
    {
        [field: SerializeField] public TowerController Tower { get; private set; }

        public override void Death()
        {
            //Tower.
        }
    }
}