using UnityEngine;

namespace TownRush.Board
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Board/Tile Settings")]
    public class TileSettings : ScriptableObject
    {
        public Material emptyTileMat;
        public Material playerTileMat;
        public Material[] enemyTileMats;
    }
}