using TownRush.Buildings.Tower;
using UnityEngine;

namespace TownRush.Buildings
{
    public abstract class BuildingAbstract : MonoBehaviour, IBuilding
    {
        [field: SerializeField] public Transform ModelTr { get; private set; }
        [field: SerializeField] public MeshRenderer MeshRenderer { get; private set; }

        public virtual void Initialize(TowerInfo towerInfo) => ChangeMaterial(0);

        public abstract void SetBuildingOwnerType(BuildingOwnerTypes buildingOwnerType);

        public abstract BuildingOwnerTypes GetBuildingOwnerType();

        public abstract void ChangeMaterial(BuildingOwnerTypes buildingOwnerType);
    }
}