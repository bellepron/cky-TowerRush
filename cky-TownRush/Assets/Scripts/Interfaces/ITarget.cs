using TownRush.Enums;
using UnityEngine;

namespace TownRush.Interfaces
{
    public interface ITarget
    {
        public OwnerTypes OwnerType { get; set; }
        Transform GetTransform();
    }
}