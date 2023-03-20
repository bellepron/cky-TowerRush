using System;
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

        private ITarget _target;

        private void OnEnable()
        {
            Target = null;
            _bIsSearching = false;

            StartCoroutine(StartChecking());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
            Target = null;
            _bIsSearching = false;
        }

        IEnumerator StartChecking()
        {
            while (true)
            {
                Updatee();

                yield return new WaitForSeconds(0.08f);
            }
        }

        private void Updatee()
        {
            if (Target == null)
            {
                Target = Find();
            }
            else
            {
                _target = Find();

                if (_target == null) return;

                if (Target != _target)
                {
                    Target = _target;
                }
            }
        }

        private ITarget Find()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, Radius);

            foreach (Collider col in hitColliders)
            {
                if (col.TryGetComponent<ITarget>(out var target))
                {
                    if (OwnerType != target.OwnerType)
                    {
                        ResetRadius();

                        return target;
                    }
                }
            }

            Radius++;

            return null;
        }

        private void ResetRadius()
        {
            Radius = StartRadius;
        }
    }
}