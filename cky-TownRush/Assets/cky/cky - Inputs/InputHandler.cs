using System;
using UnityEngine;

namespace cky.Inputs
{
    public class InputHandler : MonoBehaviour
    {
        public static event Action<Vector3> OnClick;
        [field: SerializeField] private LayerMask LayerMask { get; }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit raycastHit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out raycastHit, 100f, LayerMask))
                {
                    if (raycastHit.transform != null)
                    {
                        Execute(raycastHit.point);
                    }
                }
            }
        }

        private void Execute(Vector3 clickedPosition)
        {
            OnClick?.Invoke(clickedPosition);
        }
    }
}