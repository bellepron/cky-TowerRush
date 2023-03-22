using System.Collections.Generic;
using TownRush.Buildings.Tower;
using TownRush.Enums;
using TownRush.Interfaces;
using UnityEngine;
using System;

namespace TownRush.Buildings
{
    public abstract class BuildingAbstract : MonoBehaviour, IOwnable
    {
        [field: SerializeField] public OwnerTypes OwnerType { get; set; }
        [field: SerializeField] public Transform ModelTr { get; private set; }
        [field: SerializeField] public MeshRenderer MeshRenderer { get; private set; }
        [field: SerializeField] public List<IOwnable> OwnedTiles { get; set; } = new List<IOwnable>();

        public Vector3 GetPosition() => transform.position;

        public abstract void Initialize(TowerSettings towerSettings, TowerInfo towerInfo);

        public abstract void ChangeMaterial(OwnerTypes ownerType);

        public abstract void SetOwnerType(OwnerTypes ownerType);
    }
}