using TownRush.Characters.Soldier.States;
using cky.StateMachine.Base;
using TownRush.Targeting;
using TownRush.Enums;
using UnityEngine;
using TownRush.Interfaces;
using TownRush.Helpers;
using UnityEngine.AI;

namespace TownRush.Characters.Soldier.StateMachine
{
    public class SoldierStateMachine : BaseStateMachine, IOwnable, IPooledObject
    {
        [field: SerializeField] public OwnerTypes OwnerType { get; set; }
        [field: SerializeField] public GameObject CharacterModel { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; } = 3.0f;
        [field: SerializeField] public Transform TargetTr { get; private set; }
        [field: SerializeField] public SoldierAnimator Animator { get; private set; }
        [field: SerializeField] public SkinnedMeshRenderer SkinnedMeshRendererHead { get; private set; }
        [field: SerializeField] public SkinnedMeshRenderer SkinnedMeshRendererBody { get; private set; }
        [field: SerializeField] public NavMeshAgent NavMeshAgent { get; private set; }
        [field: SerializeField] public Targeter Targeter { get; private set; }

        public void OnObjectSpawn()
        {
            Initialize();
        }

        private void Initialize()
        {
            SwitchState(new SoldierIdleState(this));
        }

        protected override void Tick()
        {
            base.Tick();
        }

        public void SetOwnerType(OwnerTypes ownerType)
        {
            OwnerType = ownerType;
            ChangeMaterial(ownerType);
        }

        public void ChangeMaterial(OwnerTypes ownerType)
        {
            SkinnedMeshRendererHead.materials = MaterialHelper.SetTowerMaterials(ownerType);
            SkinnedMeshRendererBody.materials = MaterialHelper.SetTowerMaterials(ownerType);
        }
    }
}