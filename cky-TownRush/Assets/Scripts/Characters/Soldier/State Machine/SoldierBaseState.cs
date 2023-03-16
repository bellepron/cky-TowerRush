using cky.StateMachine.Base;

namespace TownRush.Characters.Soldier.StateMachine
{
    public abstract class SoldierBaseState : BaseState
    {
        protected SoldierStateMachine stateMachine;

        protected SoldierBaseState(SoldierStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
    }
}