using cky.Reuseables.Helpers;
using cky.Reuseables.Managers;
using CKY.Pooling;
using System;
using System.Collections;
using TownRush.Board;
using TownRush.Buildings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TownRush.Managers
{
    public class GameManager : GameManagerAbstract
    {
        [field: SerializeField] public PoolManager PoolManager { get; private set; }

        [field: SerializeField] public EventManager EventManager { get; private set; }
        [field: SerializeField] public BoardCreator BoardCreator { get; private set; }
        [field: SerializeField] public BuildingSpawner BuildingSpawner { get; private set; }
        [field: SerializeField] public BoardManager BoardManager { get; private set; }

        protected override void OnPerAwake()
        {
            base.OnPerAwake();

            StaticCoroutineCky.Perform(OnStart());
        }

        private IEnumerator OnStart()
        {
            yield return null;

            CreateComponents();
        }

        private void CreateComponents()
        {
            EventManager = new EventManager();
            BoardCreator = new BoardCreator(levelSettings);
            BuildingSpawner = new BuildingSpawner(levelSettings);
            BoardManager = new BoardManager(BoardCreator.Tiles);
        }

        private void LoadNewScene()
        {
            PoolManager.ResetPool();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        #region Test
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                LoadNewScene();
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                EventManager.Instance.TriggerUpdateTileColors();
            }

            EventManager.Instance.TriggerUpdateTileColors();
        }
        #endregion
    }
}