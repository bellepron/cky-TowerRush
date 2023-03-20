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

        [field: SerializeField] public OwnerTypes OwnerType { get; set; }
        [field: SerializeField] public int Health { get; set; }
        public Transform GetTransform() => transform;

        public virtual void Initialize(OwnerTypes ownerType, int health)
        {
            OwnerType = ownerType;
            Health = health;
        }

        protected virtual void OnDisable()
        {
            UpdateHealthEvent = null;
        }

        public virtual void GetDamage(OwnerTypes damageFromWho, int damage)
        {
            Health = Health - damage;

            if (Health > 0)
            {

            }
            else
            {
                Health = 0;

                Death();
            }

            TriggerUpdateHealthEvent();
        }

        public virtual void Death()
        {
            PoolManager.Instance.Despawn(gameObject);
        }

        protected virtual void TriggerUpdateHealthEvent()
        {
            UpdateHealthEvent?.Invoke(Health);
        }
    }
}