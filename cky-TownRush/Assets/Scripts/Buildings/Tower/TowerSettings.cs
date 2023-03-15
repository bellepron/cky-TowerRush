using UnityEngine;

namespace cky.Buildings.Tower
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Buildings/Tower Settings")]
    public class TowerSettings : ScriptableObject
    {
        public BuildingAbstract towerPrefab;

        public Material[] emptyTowerMaterials;
        public Material[] playerTowerMaterials;
        public Material[] enemy1TowerMaterials;
        public Material[] enemy2TowerMaterials;
        public Material[] enemy3TowerMaterials;
    }
}