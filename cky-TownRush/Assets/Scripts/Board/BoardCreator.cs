using cky.Reuseables.Level;
using EZ_Pooling;
using TownRush.Managers;
using UnityEngine;

namespace TownRush.Board
{
    public class BoardCreator
    {
        private LevelSettings LevelSettings { get; set; }
        public ITile[,] Tiles { get; private set; }
        private Transform HexagonTilePrefabTr { get; set; }
        private int Width { get; set; }
        private int Height { get; set; }
        private float Gap { get; set; }

        private float _tileX = 1.73205f; // From Trigonometry
        private float _tileZ = 2.0f; // From Trigonometry
        private Vector3 _startPos;

        public BoardCreator(LevelSettings levelSettings)
        {
            LevelSettings = levelSettings;

            SetVariables();
            CreateBoard();
        }

        private void SetVariables()
        {
            LevelSettings = GameManager.Instance.levelSettings;
            HexagonTilePrefabTr = LevelSettings.TileSettings.TilePrefabTr;
            Width = LevelSettings.BoardWidth;
            Height = LevelSettings.BoardHeight;
            Gap = LevelSettings.TileGap;
            _startPos = new Vector3(-(Width - 1) * (_tileX * 0.5f + Gap * 0.5f), 0, -(Height - 1) * (_tileZ * 0.375f + Gap * 0.5f));

            Tiles = new ITile[Width, Height];
        }

        private void CreateBoard()
        {
            for (int j = 0; j < Height; j++)
            {
                var secondRowOffsetX = j % 2 == 0 ? 0 : (_tileX * 0.5f);

                for (int i = 0; i < Width; i++)
                {
                    Vector3 pos = _startPos + new Vector3(secondRowOffsetX + i * _tileX + i * Gap, 0, j * _tileZ * 0.75f + j * Gap);

                    var tileTr = EZ_PoolManager.Spawn(HexagonTilePrefabTr, pos, Quaternion.Euler(-90, 0, 0));

                    if (tileTr.TryGetComponent<ITile>(out var tile))
                    {
                        Tiles[i, j] = tile;

                        tile.Initialize(LevelSettings.TileSettings);
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