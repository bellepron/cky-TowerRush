using TownRush.Board;
using TownRush.Buildings.Tower;
using UnityEngine;

namespace cky.Reuseables.Level
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Level/Level Settings")]
    public class LevelSettings : ScriptableObject
    {
        [Header("Board")]
        public TileSettings tileSettings;
        public HexagonTile hexagonTilePrefab;
        public int boardWidth = 25, boardHeight = 50;
        public float tileGap = 0.025f;

        [Header("Buildings - Tower")]
        public TowerSettings towerSettings;
        public TowerInfo[] towersWillCreate;
    }
}