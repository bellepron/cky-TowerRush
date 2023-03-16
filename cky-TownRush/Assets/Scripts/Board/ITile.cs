using TownRush.Buildings;
using UnityEngine;

namespace TownRush.Board
{
    public interface ITile
    {
        public TileSettings TileSettings { get; set; }
        void Initialize(TileSettings tileSettings);
        void ChangeMaterial(BuildingOwnerTypes buildingOwnerType);
        Vector3 GetPosition();
    }
}