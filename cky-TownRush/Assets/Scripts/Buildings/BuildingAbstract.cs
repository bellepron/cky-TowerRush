using TownRush.Buildings.Tower;
using TownRush.Enums;
using UnityEngine;

namespace TownRush.Buildings
{
    public abstract class BuildingAbstract : MonoBehaviour, IBuilding
    {
        [field: SerializeField] public Transform ModelTr { get; private set; }
        [field: SerializeField] public MeshRenderer MeshRenderer { get; private set; }

        public virtual void Initialize(TowerInfo towerInfo) => ChangeMaterial(0);

        public abstract void SetOwnerType(OwnerTypes ownerType);

        public abstract OwnerTypes GetOwnerType();

        public abstract void ChangeMaterial(OwnerTypes buildingOwnerType);
    }
}