using System.Collections;
using UnityEngine;

namespace cky.Reuseables.Helpers
{
    public static class StaticCoroutine
    {
        public class StaticCoroutineMono : MonoBehaviour { }
        private static StaticCoroutineMono staticCoroutine;
        public static void Perform(IEnumerator routine)
        {
            Init();

            staticCoroutine.StartCoroutine(routine);
        }
        private static void Init()
        {
            if (staticCoroutine == null)
            {
                GameObject gameObject = new GameObject("Static Coroutine");

                staticCoroutine = gameObject.AddComponent<StaticCoroutineMono>();
            }
        }
    }
}