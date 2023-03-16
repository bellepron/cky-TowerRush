using TownRush.Buildings.Tower;
using TownRush.Enums;
using TownRush.Interfaces;
using UnityEngine;

namespace TownRush.Buildings
{
    public abstract class BuildingAbstract : MonoBehaviour, IOwnable
    {
        [field: SerializeField] public OwnerTypes OwnerType { get; set; }
        [field: SerializeField] public Transform ModelTr { get; private set; }
        [field: SerializeField] public MeshRenderer MeshRenderer { get; private set; }

        public abstract void Initialize(TowerInfo towerInfo);

        public abstract void ChangeMaterial(OwnerTypes ownerType);

        public abstract void SetOwnerType(OwnerTypes ownerType);
    }
}