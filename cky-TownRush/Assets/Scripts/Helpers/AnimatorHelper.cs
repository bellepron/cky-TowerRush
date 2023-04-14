using UnityEngine;

namespace TownRush.Helpers
{
    public class AnimatorHelper
    {
        public static readonly int DRAW = Animator.StringToHash("Draw");
        public static readonly int IDLE = Animator.StringToHash("Idle");
        public static readonly int RUN = Animator.StringToHash("Run");
        public static readonly int ATTACK = Animator.StringToHash("Attack");
        public static readonly int DEATH = Animator.StringToHash("Death");
        public static readonly int WIN = Animator.StringToHash("Win");
        public static readonly int LOSE = Animator.StringToHash("Lose");

        public const string TAG_IDLE = "Idle";
        public const string TAG_WALK = "Walk";
        public const string TAG_ATTACK = "Attack";
    }
}