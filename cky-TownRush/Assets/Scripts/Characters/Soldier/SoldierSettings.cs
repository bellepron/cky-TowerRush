using UnityEngine;

namespace TownRush.Characters.Soldier
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Characters/Soldier Settings")]
    public class SoldierSettings : ScriptableObject
    {
        [field: SerializeField] public Transform PrefabTr { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; } = 3.0f;
        [field: SerializeField] public int Health { get; private set; } = 1;
        [field: SerializeField] public int Damage { get; private set; } = 1;

        [field: SerializeField] public Material EmptySoldierMaterial { get; private set; }
        [field: SerializeField] public Material PlayerSoldierMaterial { get; private set; }
        [field: SerializeField] public Material[] EnemySoldierMaterials { get; private set; }
    }
}