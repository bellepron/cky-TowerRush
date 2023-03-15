using UnityEngine;

namespace cky.Reuseables.Level
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Level/New Level Settings")]
    public class LevelSettings : ScriptableObject
    {
        [field: SerializeField] public string PizzaCost { get; private set; } = "5";
    }
}