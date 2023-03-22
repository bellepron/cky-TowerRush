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
        BuildingAbstract[] _buildingAbstracts;
        IOwnable[,] _tileIOwnables;
        int _buildingCount;
        int _width;
        int _height;

        public BoardManager(ITile[,] tiles)
        {
            _tiles = tiles;
            _width = _tiles.GetLength(0);
            _height = _tiles.GetLength(1);
            _buildingAbstracts = MonoBehaviour.FindObjectsOfType<BuildingAbstract>();
            _buildingCount = _buildingAbstracts.Length;

            _tileIOwnables = new IOwnable[_width, _height];
            for (int j = 0; j < _height; j++)
            {
                for (int i = 0; i < _width; i++)
                {
                    if (((TileAbstract)_tiles[i, j]).TryGetComponent<IOwnable>(out var iOwnable))
                    {
                        _tileIOwnables[i, j] = iOwnable;
                    }
                    else
                    {
                        Debug.Log("TileAbstract.cs is not inherited IOwnable");
                    }
                }
            }

            AssignTilesToClosestBuilding();
        }

        private void AssignTilesToClosestBuilding()
        {
            for (int j = 0; j < _height; j++)
            {
                for (int i = 0; i < _width; i++)
                {
                    var minDist = Mathf.Infinity;
                    BuildingAbstract closestBuilding = null;

                    for (int k = 0; k < _buildingCount; k++)
                    {
                        var building = _buildingAbstracts[k];
                        var dist = Vector3.Distance(_tiles[i, j].GetPosition(), building.GetPosition());

                        if (dist < minDist)
                        {
                            minDist = dist;
                            closestBuilding = building;
                        }
                    }

                    closestBuilding.OwnedTiles.Add(_tileIOwnables[i, j]);
                }
            }
        }
    }
}