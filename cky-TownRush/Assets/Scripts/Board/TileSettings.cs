using UnityEngine;

namespace TownRush.Board
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Board/Tile Settings")]
    public class TileSettings : ScriptableObject
    {
        [field: SerializeField] public Transform TilePrefabTr { get; private set; }
        [field: SerializeField] public Material EmptyTileMat { get; private set; }
        [field: SerializeField] public Material PlayerTileMat { get; private set; }
        [field: SerializeField] public Material[] EnemyTileMats { get; private set; }
    }
}