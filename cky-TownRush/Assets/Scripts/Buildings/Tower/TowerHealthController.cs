using System;
using System.Collections;
using TownRush.Abstracts;
using TownRush.Enums;
using UnityEngine;

namespace TownRush.Buildings.Tower
{
    public class TowerHealthController : HealthControllerAbstract
    {
        public event Action<OwnerTypes, int> CapturedEvent;

        [field: SerializeField] public TowerController Tower { get; private set; }
        [field: SerializeField] public TowerHealthCanvasController TowerHealthCanvasController { get; private set; }

        public override void Initialize(OwnerTypes ownerType, int health)
        {
            base.Initialize(ownerType, health);

            UpdateHealthEvent += TowerHealthCanvasController.UpdateText;
            TriggerUpdateHealthEvent();
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            CapturedEvent = null;
        }

        public override void GetDamage(OwnerTypes damageFromWho, int damage)
        {
            Health = Health - damage;

            if (Health > 0)
            {

            }
            else if (Health == 0)
            {
                Death();
            }
            else if (Health < 0)
            {
                Health = 0;

                Captured(damageFromWho);
            }

            TriggerUpdateHealthEvent();
        }

        public override void Death()
        {

        }

        private void Captured(OwnerTypes damageFromWho)
        {
            StartCoroutine(ChangeOwnerAtLate(damageFromWho));
        }

        IEnumerator ChangeOwnerAtLate(OwnerTypes damageFromWho)
        {
            yield return new WaitForEndOfFrame();

            Health = Tower.TowerSettings.LevelBaseFloors[1];
            OwnerType = damageFromWho;

            TriggerCapturedEvent(damageFromWho, Health);
            TriggerUpdateHealthEvent();
        }

        private void TriggerCapturedEvent(OwnerTypes damageFromWho, int capturedHealth)
        {
            CapturedEvent?.Invoke(damageFromWho, capturedHealth);
        }
    }
}