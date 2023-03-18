using TownRush.Characters.Soldier.StateMachine;

namespace TownRush.Characters.Soldier.States
{
    public class SoldierAttackState : SoldierBaseState
    {
        public SoldierAttackState(SoldierStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            stateMachine.Animator.Attack();
            stateMachine.NavMeshAgent.isStopped = true;
        }

        public override void Exit()
        {
            stateMachine.NavMeshAgent.isStopped = false;
        }

        public override void Tick(float deltaTime)
        {
            
        }
    }
}