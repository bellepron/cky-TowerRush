using System;
using System.Collections;
using TownRush.Characters.Soldier;
using TownRush.Enums;
using TownRush.Interfaces;
using TownRush.Managers;
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

        #region Getting Target Manager

        private TargetManager _targetManager;
        private TargetManager TargetManager
        {
            get
            {
                if (!_targetManager)
                {
                    _targetManager = TargetManager.Instance;
                }
                return _targetManager;
            }
        }

        #endregion

        #region Getting Actor ITarget Interface

        private ITarget _actor;
        private ITarget Actor
        {
            get
            {
                if (_actor == null)
                {
                    _actor = gameObject.GetComponent<ITarget>();
                }
                return _actor;
            }
        }

        #endregion

        [field: SerializeField] public ITarget Target { get; private set; }

        private WaitForSeconds _wfsCheckInterval = new WaitForSeconds(0.05f);

        private void OnEnable()
        {
            StartCoroutine(FixableUpdate());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        IEnumerator FixableUpdate()
        {
            while (true)
            {
                Target = TargetManager.FindTarget(Actor);

                yield return _wfsCheckInterval;
            }
        }

        //private void CheckTargetPresence()
        //{
        //    if (Target.GetPosition().gameObject.activeInHierarchy == false)
        //        Target = null;
        //}
    }
}