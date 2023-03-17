using TownRush.Characters.Soldier.StateMachine;
using UnityEngine;

namespace TownRush.Characters.Soldier.States
{
    public class SoldierIdleState : SoldierBaseState
    {
        public SoldierIdleState(SoldierStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            stateMachine.Animator.Idle();
            stateMachine.NavMeshAgent.isStopped = true;
        }

        public override void Exit()
        {
            stateMachine.NavMeshAgent.isStopped = false;
        }

        public override void Tick(float deltaTime)
        {
            if (stateMachine.Targeter.Target != null)
            {
                stateMachine.SwitchState(new SoldierChargeState(stateMachine));
            }
        }
    }
}