using TownRush.Characters.Soldier.StateMachine;

namespace TownRush.Characters.Soldier.States
{
    public class SoldierChargeState : SoldierBaseState
    {
        public SoldierChargeState(SoldierStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            stateMachine.Animator.Walk();
        }

        public override void Exit()
        {

        }

        public override void Tick(float deltaTime)
        {
            if (stateMachine.Targeter.Target == null)
            {
                stateMachine.SwitchState(new SoldierIdleState(stateMachine));

                return;
            }

            stateMachine.NavMeshAgent.destination = stateMachine.Targeter.Target.GetTransform().position;
        }
    }
}