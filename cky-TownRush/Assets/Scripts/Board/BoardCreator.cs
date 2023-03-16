using cky.Reuseables.Level;
using UnityEngine;

namespace TownRush.Board
{
    public class BoardCreator
    {
        LevelSettings _levelSettings;

        HexagonTile _hexagonTilePrefab;
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
            _levelSettings = LevelManagerAbstract.Instance.levelSettings;
            _hexagonTilePrefab = _levelSettings.hexagonTilePrefab;
            _width = _levelSettings.boardWidth;
            _height = _levelSettings.boardHeight;
            _gap = _levelSettings.tileGap;
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

                    HexagonTile tile = MonoBehaviour.Instantiate(_hexagonTilePrefab, pos, Quaternion.Euler(-90, 0, 0));
                    _tiles[i, j] = tile;

                    tile.Initialize(_levelSettings.tileSettings.emptyTileMat);
                }
            }
        }
    }
}