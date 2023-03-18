using CKY.Pooling;
using TownRush.Enums;
using TownRush.Interfaces;
using UnityEngine;

namespace TownRush.Health
{
    public abstract class HealthControllerAbstract : MonoBehaviour, ITarget, IDamageable
    {
        [field: SerializeField] public OwnerTypes OwnerType { get; set; }
        [field: SerializeField] public int Health { get; set; }
        public Transform GetTransform() => transform;

        public void Initialize(OwnerTypes ownerType, int health)
        {
            OwnerType = ownerType;
            Health = health;
        }

        public void GetDamage(OwnerTypes damageFrom, int damage)
        {
            Health = Health - damage;

            if (Health == 0)
            {
                Death();
            }

            if (Health < 0)
            {
                Health = -1 * Health;
                // TODO: Tip deðiþtir.
            }
        }

        public void Death()
        {
            PoolManager.Instance.Despawn(gameObject);
        }
    }
}