using TownRush.Enums;

namespace TownRush.Interfaces
{
    public interface IOwnable
    {
        OwnerTypes OwnerType { get; set; }
        void SetOwnerType(OwnerTypes ownerType);
        void ChangeMaterial(OwnerTypes ownerType);
    }
}