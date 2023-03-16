using cky.Reuseables.Helpers;
using cky.Reuseables.Managers;
using CKY.Pooling;
using System.Collections;
using TownRush.Board;
using TownRush.Buildings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TownRush.Managers
{
    public class GameManager : GameManagerAbstract
    {
        [field: SerializeField] private PoolManager PoolManager { get; set; }

        protected override void OnPerAwake()
        {
            base.OnPerAwake();

            StaticCoroutineCky.Perform(OnStart());
        }

        private IEnumerator OnStart()
        {
            yield return null;

            new EventManager();
            new BoardCreator(levelSettings);
            new BuildingSpawner(levelSettings);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                PoolManager.ResetPool();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}