using TownRush.Helpers;
using UnityEngine;

namespace TownRush.Characters.Soldier
{
    public class SoldierAnimator : MonoBehaviour
    {
        [field: SerializeField] private Animator Animator { get; set; }
        [field: SerializeField] private float TransitionTime { get; set; }
        private float MovementSpeed { get; set; }

        public void UpdateValues(float movementSpeed, float cookSpeed)
        {
            MovementSpeed = movementSpeed;

            UpdateSpeed();
        }

        private void UpdateSpeed()
        {
            if (Animator.GetCurrentAnimatorStateInfo(0).IsTag(AnimatorHelper.TAG_WALK))
            {
                SetAnimatorSpeed(MovementSpeed);
            }
        }

        private void SetAnimatorSpeed(float value) => Animator.speed = value;

        public void Idle() => Animator.CrossFade(AnimatorHelper.IDLE, TransitionTime, 0);

        public void Walk() => Animator.CrossFade(AnimatorHelper.WALK, TransitionTime, 0);

        public void Attack() => Animator.CrossFade(AnimatorHelper.ATTACK, TransitionTime, 0);
        public void Win() => Animator.CrossFade(AnimatorHelper.WIN, TransitionTime, 0);

        public void Lose() => Animator.CrossFade(AnimatorHelper.LOSE, TransitionTime, 0);
    }
}