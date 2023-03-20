using TownRush.Enums;
using TownRush.Interfaces;
using UnityEngine;

namespace TownRush.Abstracts
{
    public abstract class CollisionAbstract : MonoBehaviour
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

        protected OwnerTypes OwnerType
        {
            get
            {
                return IOwnable.OwnerType;
            }
        }

        #endregion
    }
}