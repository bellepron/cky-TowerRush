using TownRush.Enums;

namespace TownRush.Interfaces
{
    public interface IDamageable
    {
        void GetDamage(OwnerTypes damageFrom, int damage);
        void Death();
    }
}