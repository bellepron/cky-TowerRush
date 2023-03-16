using UnityEngine;

namespace TownRush.Helpers
{
    public class AnimatorHelper : MonoBehaviour
    {
        public static readonly int IDLE = Animator.StringToHash("Idle");
        public static readonly int WALK = Animator.StringToHash("Walk");
        public static readonly int ATTACK = Animator.StringToHash("Attack");

        public const string TAG_IDLE = "Idle";
        public const string TAG_WALK = "Walk";
        public const string TAG_ATTACK = "ATTACK";
    }
}