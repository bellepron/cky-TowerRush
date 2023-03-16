using TownRush.Board;
using TownRush.Buildings;
using UnityEngine;

namespace TownRush.Managers
{
    public class BoardManager
    {
        public static BoardManager Instance;

        ITile[,] _tiles;

        public BoardManager(ITile[,] tiles)
        {
            _tiles = tiles;

            SetColors();
        }

        public void SetColors()
        {
            var buildings = MonoBehaviour.FindObjectsOfType<BuildingAbstract>();

            for (int j = 0; j < _tiles.GetLength(1); j++)
            {
                for (int i = 0; i < _tiles.GetLength(0); i++)
                {
                    var tile = _tiles[i, j];
                    var minDist = Mathf.Infinity;
                    BuildingAbstract closestBuilding = null;

                    foreach (var building in buildings)
                    {
                        var dist = Vector3.Distance(tile.GetPosition(), building.transform.position);

                        if (dist < minDist)
                        {
                            minDist = dist;
                            closestBuilding = building;
                        }
                    }
                    Debug.Log(closestBuilding.GetBuildingOwnerType());

                    tile.ChangeMaterial(closestBuilding.GetBuildingOwnerType());

                    //if (closestBuilding.TryGetComponent<IBuilding>(out var iBuilding))
                    //{
                    //    iBuilding.
                    //}
                }
            }
        }
    }
}