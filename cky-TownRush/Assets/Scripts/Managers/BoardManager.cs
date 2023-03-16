using TownRush.Board;
using TownRush.Buildings;
using TownRush.Interfaces;
using UnityEngine;

namespace TownRush.Managers
{
    public class BoardManager
    {
        public static BoardManager Instance;

        ITile[,] _tiles;
        BuildingAbstract[] buildings;

        public BoardManager(ITile[,] tiles)
        {
            _tiles = tiles;
            buildings = MonoBehaviour.FindObjectsOfType<BuildingAbstract>();

            SetTileColors();

            EventManager.UpdateTileColors += SetTileColors;
        }

        public void SetTileColors()
        {
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

                    if (closestBuilding.TryGetComponent<IOwnable>(out var closestBuildingiOwnable))
                    {
                        var tileAbstract = (TileAbstract)tile;
                        if (tileAbstract.TryGetComponent<IOwnable>(out var tileIOwnable))
                        {
                            tileIOwnable.SetOwnerType(closestBuildingiOwnable.OwnerType);
                        }
                    }
                }
            }
        }
    }
}