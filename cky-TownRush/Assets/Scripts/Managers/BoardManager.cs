using System.Linq;
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
        IOwnable[] buildings;

        public BoardManager(ITile[,] tiles)
        {
            _tiles = tiles;
            buildings = MonoBehaviour.FindObjectsOfType<BuildingAbstract>().OfType<IOwnable>().ToArray();

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
                    IOwnable closestBuilding = null;

                    foreach (var building in buildings)
                    {
                        var dist = Vector3.Distance(tile.GetPosition(), building.GetPosition());

                        if (dist < minDist)
                        {
                            minDist = dist;
                            closestBuilding = building;
                        }
                    }

                    var tileAbstract = (TileAbstract)tile;
                    if (tileAbstract.TryGetComponent<IOwnable>(out var tileIOwnable))
                    {
                        tileIOwnable.SetOwnerType(closestBuilding.OwnerType);
                    }
                    else
                    {
                        Debug.Log("TileAbstract.cs is not inherited IOwnable");
                    }
                }
            }
        }
    }
}