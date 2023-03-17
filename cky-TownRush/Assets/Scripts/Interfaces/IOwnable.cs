using TownRush.Enums;

namespace TownRush.Interfaces
{
    public interface IOwnable
    {
        public OwnerTypes OwnerType { get; set; }
        void SetOwnerType(OwnerTypes ownerType);
        void ChangeMaterial(OwnerTypes ownerType);
    }
}