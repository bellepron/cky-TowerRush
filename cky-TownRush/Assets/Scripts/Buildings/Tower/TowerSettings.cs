using UnityEngine;

namespace TownRush.Buildings.Tower
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Buildings/Tower Settings")]
    public class TowerSettings : ScriptableObject
    {
        [field: SerializeField] public Transform PrefabTr { get; private set; }

        [field: SerializeField] public int[] UpgradeLevelCosts { get; private set; } = new int[4] { 0, 10, 20, 30 };
        [field: SerializeField] public int[] LevelBaseFloors { get; private set; } = new int[5] { 0, 10, 20, 30, 50 };
        [field: SerializeField] public int[] LevelIncomes { get; private set; } = new int[5] { 0, 10, 30, 70, 100 };

        [field: SerializeField] public Material[] EmptyTowerMaterials { get; private set; }
        [field: SerializeField] public Material[] PlayerTowerMaterials { get; private set; }
        [field: SerializeField] public Material[] Enemy1TowerMaterials { get; private set; }
        [field: SerializeField] public Material[] Enemy2TowerMaterials { get; private set; }
        [field: SerializeField] public Material[] Enemy3TowerMaterials { get; private set; }
    }
}