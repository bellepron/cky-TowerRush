using cky.Reuseables.Helpers;
using CKY.Pooling;
using System.Collections;
using TownRush.Characters.Soldier;
using TownRush.Characters.Soldier.StateMachine;
using TownRush.Enums;
using TownRush.Managers;
using UnityEngine;

namespace TownRush.Characters
{
    public class CharacterSpawner : SingletonPersistent<CharacterSpawner>
    {
        private SoldierSettings SoldierSettings { get; set; }
        private Transform SoldierPrefabTr { get; set; }

        protected override void OnPerAwake()
        {
            StaticCoroutineCky.Perform(GetPrefabs());
        }

        IEnumerator GetPrefabs()
        {
            yield return null;

            SoldierSettings = GameManager.Instance.levelSettings.SoldierSettings;
            SoldierPrefabTr = SoldierSettings.PrefabTr;
        }

        public void SpawnSoldier(OwnerTypes ownerType, Vector3 pos)
        {
            var character = PoolManager.Instance.Spawn(SoldierPrefabTr, pos, Quaternion.identity);

            if (character.TryGetComponent<SoldierStateMachine>(out var stateMachine))
            {
                stateMachine.Initialize(SoldierSettings, ownerType);
            }
        }
    }
}