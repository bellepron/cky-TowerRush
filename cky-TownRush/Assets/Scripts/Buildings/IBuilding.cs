
namespace TownRush.Buildings
{
    public interface IBuilding
    {
        void SetBuildingOwnerType(BuildingOwnerTypes type);
        BuildingOwnerTypes GetBuildingOwnerType();
        void ChangeMaterial(BuildingOwnerTypes buildingOwnerType);
    }
}