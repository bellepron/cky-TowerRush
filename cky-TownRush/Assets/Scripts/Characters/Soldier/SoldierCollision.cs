using TownRush.Enums;
using TownRush.Interfaces;
using UnityEngine;

namespace TownRush.Characters.Soldier
{
    public class SoldierCollision : MonoBehaviour
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

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.TryGetComponent<IOwnable>(out var iOwnable))
        //    {
        //        if (OwnerType == iOwnable.OwnerType) return;

        //        PoolManager.Instance.Despawn(gameObject);
        //    }
        //}

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent<IOwnable>(out var iOwnable))
            {
                if (OwnerType == iOwnable.OwnerType) return;

                if (collision.transform.gameObject.TryGetComponent<IDamageable>(out var iDamageable))
                {
                    iDamageable.GetDamage(OwnerType, 1);
                }
                else
                {
                    Debug.Log($"{collision.transform.name} is not damageable!");
                }
            }
        }
    }
}