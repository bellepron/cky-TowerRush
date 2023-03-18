using TownRush.Enums;

namespace TownRush.Interfaces
{
    public interface IDamageable
    {
        public OwnerTypes OwnerType { get; set; }
        public int Health { get; set; }
        void GetDamage(OwnerTypes damageFrom, int damage);
        void Death();
    }
}