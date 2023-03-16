using cky.StateMachine.Base;
using TownRush.Characters.Soldier.States;
using UnityEngine;

namespace TownRush.Characters.Soldier.StateMachine
{
    public class SoldierStateMachine : BaseStateMachine
    {
        [field: SerializeField] public float MovementSpeed { get; private set; } = 3.0f;
        [field: SerializeField] public Transform TargetTr { get; private set; }
        [field: SerializeField] public SoldierAnimator Animator { get; private set; }
        //[field: SerializeField] public Targeter Targeter { get; private set; }

        private void Start()
        {
            SwitchState(new SoldierIdleState(this));
        }

        protected override void Tick()
        {
            base.Tick();

            if (Input.GetKeyDown(KeyCode.A)) { SwitchState(new SoldierIdleState(this)); }
            if (Input.GetKeyDown(KeyCode.S)) { SwitchState(new SoldierChargeState(this)); }
        }
    }
}