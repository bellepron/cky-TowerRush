using cky.Buildings.Tower;
using UnityEngine;

namespace cky.Buildings
{
    public abstract class BuildingAbstract : MonoBehaviour
    {
        protected Transform modelTr;
        protected MeshRenderer mr;

        public virtual void Initialize(TowerInfo towerInfo)
        {
            GetMeshRenderer();

            ChangeMaterial();
        }

        protected void GetMeshRenderer()
        {
            mr = GetComponentInChildren<MeshRenderer>();
        }

        public abstract void SetType<T>(T type);

        public abstract void ChangeMaterial();
    }
}