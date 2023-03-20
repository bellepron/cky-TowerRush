using cky.Reuseables.Singleton;
using System.Collections.Generic;
using TownRush.Interfaces;
using UnityEngine;

namespace TownRush.Managers
{
    public class TargetManager : SingletonPersistent<TargetManager>
    {
        [SerializeField] public List<ITarget> Targets { get; private set; } = new List<ITarget>();

        protected override void OnPerAwake()
        {
            Targets.Clear();
        }

        private void Start()
        {
            EventManager.AddTarget += AddTarget;
            EventManager.RemoveTarget += RemoveTarget;
        }

        private void AddTarget(ITarget target)
        {
            if (!Targets.Contains(target))
            {
                Targets.Add(target);
            }
        }

        private void RemoveTarget(ITarget target)
        {
            if (Targets.Contains(target))
            {
                Targets.Remove(target);
            }
        }

        public ITarget FindTarget(ITarget actor)
        {
            float minDist = Mathf.Infinity;
            ITarget closestTarget = null;

            foreach (var target in Targets)
            {
                if (actor.OwnerType != target.OwnerType)
                {
                    var dist = Vector3.Distance(actor.GetPosition(), target.GetPosition());
                    if (dist < minDist)
                    {
                        minDist = dist;
                        closestTarget = target;
                    }
                }
            }

            return closestTarget;
        }
    }
}