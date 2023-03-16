using TownRush.Board;
using TownRush.Buildings.Tower;
using UnityEngine;

namespace cky.Reuseables.Level
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Level/Level Settings")]
    public class LevelSettings : ScriptableObject
    {
        [field: Header("Board")]
        [field: SerializeField] public TileSettings TileSettings { get; private set; }
        [field: SerializeField] public int BoardWidth { get; private set; } = 10;
        [field: SerializeField] public int BoardHeight { get; private set; } = 12;
        [field: SerializeField] public float TileGap { get; private set; } = 0.028f;

        [field: Header("Buildings - Tower")]
        [field: SerializeField] public TowerSettings TowerSettings { get; private set; }
        [field: SerializeField] public TowerInfo[] TowersWillCreate { get; private set; }

    }
}