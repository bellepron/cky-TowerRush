using UnityEngine.UI;
using UnityEngine;
using TMPro;
using TownRush.Enums;

namespace TownRush.Buildings
{
    public abstract class BuildingCostCanvasAbstract : MonoBehaviour
    {
        [SerializeField] protected GameObject canvas;
        [SerializeField] protected TextMeshProUGUI textTmp;
        [SerializeField] protected Image costIcon;

        private void Awake() => canvas.transform.rotation = Camera.main.transform.rotation;

        public abstract void Initialize(OwnerTypes ownerType, int level);

        protected abstract void UpdateText();
    }
}