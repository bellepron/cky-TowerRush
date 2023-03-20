using UnityEngine;
using TMPro;

namespace TownRush.Buildings
{
    public abstract class BuildingHealthCanvasAbstract : MonoBehaviour
    {
        [SerializeField] protected GameObject canvas;
        [SerializeField] protected TextMeshProUGUI textTmp;

        public abstract void UpdateText(int health);
    }
}