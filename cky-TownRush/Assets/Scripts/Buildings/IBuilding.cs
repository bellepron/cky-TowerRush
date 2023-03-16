using TownRush.Enums;

namespace TownRush.Buildings
{
    public interface IBuilding
    {
        void SetOwnerType(OwnerTypes ownerType);
        OwnerTypes GetOwnerType();
        void ChangeMaterial(OwnerTypes ownerType);
    }
}