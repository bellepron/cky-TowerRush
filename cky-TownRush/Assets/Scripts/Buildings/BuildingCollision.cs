using TownRush.Abstracts;
using TownRush.Interfaces;
using UnityEngine;

namespace TownRush.Buildings
{
    public class BuildingCollision : CollisionAbstract
    {
        private void OnCollisionEnter(Collision collision)
        {
            var collisionTr = collision.transform;

            if (collisionTr.TryGetComponent<IOwnable>(out var iOwnable))
            {
                if (OwnerType == iOwnable.OwnerType) return;

                if (collisionTr.TryGetComponent<IDamageable>(out var iDamageable))
                {
                    iDamageable.GetDamage(OwnerType, 1);
                }
                else
                {
                    Debug.Log($"{collisionTr.name} is not damageable!");
                }
            }
        }
    }
}