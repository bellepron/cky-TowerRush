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

        private void OnEnable() => Draw();

        public void Draw() => Animator.CrossFade(AnimatorHelper.DRAW, TransitionTime, 0);

        public void Idle() => Animator.CrossFade(AnimatorHelper.IDLE, TransitionTime, 0);

        public void Run() => Animator.CrossFade(AnimatorHelper.RUN, TransitionTime, 0);

        public void Attack() => Animator.CrossFade(AnimatorHelper.ATTACK, TransitionTime, 0);

        public void Death() => Animator.CrossFade(AnimatorHelper.DEATH, TransitionTime, 0);

        public void Win() => Animator.CrossFade(AnimatorHelper.WIN, TransitionTime, 0);

        public void Lose() => Animator.CrossFade(AnimatorHelper.LOSE, TransitionTime, 0);
    }
}