using CKY.Pooling;
using TownRush.Enums;
using TownRush.Interfaces;
using UnityEngine;

namespace TownRush.Health
{
    public abstract class HealthControllerAbstract : MonoBehaviour, ITarget, IDamageable
    {
        #region Getting OwnerType

        private IOwnable _iOwnable;
        private IOwnable IOwnable
        {
            get
            {
                if (_iOwnable == null)
                {
                    if (TryGetComponent<IOwnable>(out var iOwnable))
                    {
                        _iOwnable = iOwnable;
                    }
                }

                return _iOwnable;
            }
            set { _iOwnable = value; }
        }

        private OwnerTypes OwnerType
        {
            get
            {
                return IOwnable.OwnerType;
            }
        }

        #endregion

        [field: SerializeField] protected int Health { get; set; }

        public Transform GetTransform() => transform;

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