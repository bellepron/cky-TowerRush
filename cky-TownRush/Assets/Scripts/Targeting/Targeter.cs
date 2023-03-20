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

        [field: SerializeField] public ITarget Target { get; private set; }
        [field: SerializeField] public LayerMask TargetLayerMask { get; private set; }
        [field: SerializeField] private float StartRadius { get; set; } = 1.0f;
        [field: SerializeField] private float MaxRadius { get; set; } = 25.0f;
        [field: SerializeField] private float Radius { get; set; }
        private bool _bIsSearching;
        private int _c;

        private void FixedUpdate()
        {
            if (Target == null)
            {
                Find();
            }
            else
            {
                _c++;
                if (_c > 30)
                {
                    _c = 0;
                    Find2();
                    if (Target == null)
                        return;
                }
                CheckTargetPresence();
            }
        }

        private void CheckTargetPresence()
        {
            if (Target.GetTransform().gameObject.activeInHierarchy == false)
                Target = null;
        }

        private void OnEnable()
        {
            Target = null;
            _bIsSearching = false;
        }

        private void OnDisable()
        {
            StopAllCoroutines();
            Target = null;
            _bIsSearching = false;
        }

        //private ITarget Find()
        //{
        //    Collider[] hitColliders = Physics.OverlapSphere(transform.position, Radius);

        //    foreach (Collider col in hitColliders)
        //    {
        //        if (col.TryGetComponent<ITarget>(out var target))
        //        {
        //            if (col.TryGetComponent<IOwnable>(out var iOwnable))
        //            {
        //                if (OwnerType != iOwnable.OwnerType)
        //                {
        //                    ResetRadius();

        //                    return target;
        //                }
        //            }
        //        }
        //    }

        //    Radius++;

        //    return null;
        //}

        //private void ResetRadius()
        //{
        //    Radius = StartRadius;
        //}

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
                    if (col.TryGetComponent<ITarget>(out var target))
                    {
                        if (OwnerType != target.OwnerType)
                        {
                            Target = target;
                            _bIsSearching = false;

                            yield break;
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


        /////////////////
        ///


        private void Find2()
        {
            StartCoroutine(FindTargetObject2());
        }

        IEnumerator FindTargetObject2()
        {
            Radius = StartRadius;
            var active = true;
            while (active)
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, Radius/*, TargetLayerMask*/);

                foreach (Collider col in hitColliders)
                {
                    if (col.TryGetComponent<ITarget>(out var target))
                    {
                        if (OwnerType != target.OwnerType)
                        {
                            Target = target;
                            active = false;
                        }
                    }
                }

                yield return null;

                if (Radius < MaxRadius)
                {
                    Radius += 1;
                }
                else
                {
                    Target = null;
                    active = false;
                }
            }
        }
    }
}