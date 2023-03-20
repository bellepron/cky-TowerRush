using CKY.Pooling;
using System;
using TownRush.Enums;
using TownRush.Interfaces;
using UnityEngine;

namespace TownRush.Abstracts
{
    public abstract class HealthControllerAbstract : MonoBehaviour, ITarget, IDamageable
    {
        public event Action<int> UpdateHealthEvent;
        public event Action<OwnerTypes, int> CapturedEvent;

        [field: SerializeField] public OwnerTypes OwnerType { get; set; }
        [field: SerializeField] public int Health { get; set; }
        public Transform GetTransform() => transform;

        public void Initialize(OwnerTypes ownerType, int health)
        {
            OwnerType = ownerType;
            Health = health;
        }

        public void GetDamage(OwnerTypes damageFromWho, int damage)
        {
            Health = Health - damage;

            if (Health > 0)
            {
                Damaged();
            }
            else if (Health == 0)
            {
                Death();
            }
            else if (Health < 0)
            {
                Health = 0;

                Captured(damageFromWho, 10);
            }
        }

        public virtual void Death()
        {
            PoolManager.Instance.Despawn(gameObject);
        }

        protected virtual void Damaged()
        {
            UpdateHealthEvent?.Invoke(Health);
        }

        protected virtual void Captured(OwnerTypes damageFromWho, int capturedHealth)
        {
            OwnerType = damageFromWho;
            Health = 10;

            CapturedEvent?.Invoke(damageFromWho, capturedHealth);
        }
    }
}