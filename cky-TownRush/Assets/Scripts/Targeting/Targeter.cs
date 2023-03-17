using System.Collections;
using TownRush.Enums;
using TownRush.Interfaces;
using UnityEngine;

namespace TownRush.Targeting
{
    public class Targeter : MonoBehaviour
    {
        #region Getting OwnerType

        private IOwnable _iOwnable;
        private IOwnable IOwnable
        {
            get
            {
                if (_iOwnable == null)
                {
                    if (TryGetComponent<IOwnable>(out var iOwnable))
                    {
                        _iOwnable = iOwnable;
                    }
                }

                return _iOwnable;
            }
            set { _iOwnable = value; }
        }

        private OwnerTypes OwnerType
        {
            get
            {
                return IOwnable.OwnerType;
            }
        }

        #endregion

        [field: SerializeField] public Target Target { get; private set; }
        [field: SerializeField] public LayerMask TargetLayerMask { get; private set; }
        [field: SerializeField] private float StartRadius { get; set; } = 1.0f;
        [field: SerializeField] private float MaxRadius { get; set; } = 25.0f;
        [field: SerializeField] private float Radius { get; set; }
        private bool _bIsSearching;

        private void Update()
        {
            if (Target == null)
            {
                Find();
            }
            else
            {
                CheckTargetPresence();
            }
        }

        private void CheckTargetPresence()
        {
            if (Target.gameObject.activeInHierarchy == false)
                Target = null;
        }

        private void Find()
        {
            StartCoroutine(FindTargetObject());
        }

        IEnumerator FindTargetObject()
        {
            if (_bIsSearching == true) yield break;

            _bIsSearching = true;

            Radius = StartRadius;
            while (Target == null)
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, Radius/*, TargetLayerMask*/);

                foreach (Collider col in hitColliders)
                {
                    if (col.TryGetComponent<Target>(out var target))
                    {
                        if (col.TryGetComponent<IOwnable>(out var iOwnable))
                        {
                            if (OwnerType != iOwnable.OwnerType)
                            {
                                Target = target;
                                _bIsSearching = false;

                                yield break;
                            }
                        }
                    }
                }

                yield return null;

                if (Radius < MaxRadius)
                {
                    Radius += 1;
                }
            }
        }
    }
}