using TownRush.Enums;
using UnityEngine;

namespace TownRush.Board
{
    public interface ITile
    {
        public TileSettings TileSettings { get; set; }
        void Initialize(TileSettings tileSettings);
        void ChangeMaterial(OwnerTypes ownerType);
        Vector3 GetPosition();
    }
}