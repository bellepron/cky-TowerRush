using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace TownRush.Buildings
{
    public abstract class BuildingCostCanvasAbstract : MonoBehaviour
    {
        [SerializeField] protected GameObject canvas;
        [SerializeField] protected TextMeshProUGUI textTmp;
        [SerializeField] protected Image costIcon;

        private void Start() => canvas.transform.rotation = Camera.main.transform.rotation;

        public abstract void Initialize(int level);

        protected abstract void UpdateText(int level);
    }
}