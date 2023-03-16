using UnityEngine;

namespace TownRush.Board
{
    public interface ITile
    {
        void Initialize(Material material);
        void ChangeMaterial(Material material);
    }
}