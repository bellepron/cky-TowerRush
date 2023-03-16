using TownRush.Enums;
using TownRush.Helpers;
using TownRush.Interfaces;
using UnityEngine;

namespace TownRush.Board
{
    public class TileAbstract : MonoBehaviour, ITile, IOwnable
    {
        [field: SerializeField] public MeshRenderer MeshRenderer { get; private set; }

        public TileSettings TileSettings { get; set; }
        public OwnerTypes OwnerType { get; set; }

        void ITile.Initialize(TileSettings tileSettings)
        {
            TileSettings = tileSettings;
            MeshRenderer = GetComponent<MeshRenderer>();

            SetOwnerType(OwnerTypes.EMPTY);
        }

        Vector3 ITile.GetPosition() => transform.position;

        public void ChangeMaterial(OwnerTypes ownerTypes)
             => MeshRenderer.material = MaterialHelper.SetTileMaterial(ownerTypes);

        public void SetOwnerType(OwnerTypes ownerType)
        {
            OwnerType = ownerType;
            ChangeMaterial(ownerType);
        }
    }
}