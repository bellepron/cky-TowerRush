using cky.Reuseables.Level;
using CKY.Pooling;
using TownRush.Managers;
using UnityEngine;

namespace TownRush.Board
{
    public class BoardCreator
    {
        LevelSettings _levelSettings;

        Transform _hexagonTilePrefabTr;
        int _width;
        int _height;
        float _tileX = 1.73205f, _tileZ = 2.0f; // From Trigonometry
        float _gap;
        Vector3 _startPos;

        ITile[,] _tiles;

        public BoardCreator(LevelSettings levelSettings)
        {
            _levelSettings = levelSettings;

            SetVariables();
            CreateBoard();
        }

        private void SetVariables()
        {
            _levelSettings = GameManager.Instance.levelSettings;
            _hexagonTilePrefabTr = _levelSettings.TileSettings.TilePrefabTr;
            _width = _levelSettings.BoardWidth;
            _height = _levelSettings.BoardHeight;
            _gap = _levelSettings.TileGap;
            _startPos = new Vector3(-(_width - 1) * (_tileX * 0.5f + _gap * 0.5f), 0, -(_height - 1) * (_tileZ * 0.375f + _gap * 0.5f));

            _tiles = new ITile[_width, _height];
        }

        private void CreateBoard()
        {
            for (int j = 0; j < _height; j++)
            {
                var secondRowOffsetX = j % 2 == 0 ? 0 : (_tileX * 0.5f);

                for (int i = 0; i < _width; i++)
                {
                    Vector3 pos = _startPos + new Vector3(secondRowOffsetX + i * _tileX + i * _gap, 0, j * _tileZ * 0.75f + j * _gap);

                    var tileTr = PoolManager.Instance.Spawn(_hexagonTilePrefabTr, pos, Quaternion.Euler(-90, 0, 0));
                    //var tileTr = MonoBehaviour.Instantiate(_hexagonTilePrefabTr, pos, Quaternion.Euler(-90, 0, 0));

                    if (tileTr.TryGetComponent<ITile>(out var tile))
                    {
                        _tiles[i, j] = tile;

                        tile.Initialize(_levelSettings.TileSettings.EmptyTileMat);
                    }
                    else
                    {
                        Debug.LogWarning("Tile prefab is not inherited ITile interface.");
                    }
                }
            }
        }
    }
}