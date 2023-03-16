using UnityEngine;

namespace TownRush.Buildings.Tower
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Buildings/Tower Settings")]
    public class TowerSettings : ScriptableObject
    {
        [field: SerializeField] public Transform PrefabTr { get; private set; }
        [field: SerializeField] public Material[] EmptyTowerMaterials { get; private set; }
        [field: SerializeField] public Material[] PlayerTowerMaterials { get; private set; }
        [field: SerializeField] public Material[] Enemy1TowerMaterials { get; private set; }
        [field: SerializeField] public Material[] Enemy2TowerMaterials { get; private set; }
        [field: SerializeField] public Material[] Enemy3TowerMaterials { get; private set; }
    }
}