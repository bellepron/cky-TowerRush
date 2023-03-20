using TownRush.Enums;
using UnityEngine;

namespace TownRush.Interfaces
{
    public interface IOwnable
    {
        public OwnerTypes OwnerType { get; set; }
        Vector3 GetPosition();
        void SetOwnerType(OwnerTypes ownerType);
        void ChangeMaterial(OwnerTypes ownerType);
    }
}