using cky.Reuseables.Helpers;
using CKY.Pooling;
using System.Collections;
using TownRush.Enums;
using TownRush.Interfaces;
using TownRush.Managers;
using UnityEngine;

namespace TownRush.Characters
{
    public class CharacterSpawner : SingletonPersistent<CharacterSpawner>
    {
        private Transform SoldierPrefabTr { get; set; }

        protected override void OnPerAwake()
        {
            StaticCoroutineCky.Perform(GetPrefabs());
        }

        IEnumerator GetPrefabs()
        {
            yield return null;

            var soldierSettings = GameManager.Instance.levelSettings.SoldierSettings;
            SoldierPrefabTr = soldierSettings.PrefabTr;
        }

        public void SpawnSoldier(OwnerTypes ownerType, Vector3 pos)
        {
            var character = PoolManager.Instance.Spawn(SoldierPrefabTr, pos, Quaternion.identity);

            if (character.TryGetComponent<IOwnable>(out var soldierIOwnable))
            {
                soldierIOwnable.SetOwnerType(ownerType);
            }
        }
    }
}