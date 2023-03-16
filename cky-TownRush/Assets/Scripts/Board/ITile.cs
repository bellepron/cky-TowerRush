using UnityEngine;

namespace TownRush.Board
{
    public interface ITile
    {
        public TileSettings TileSettings { get; set; }
        void Initialize(TileSettings tileSettings);
        Vector3 GetPosition();
    }
}