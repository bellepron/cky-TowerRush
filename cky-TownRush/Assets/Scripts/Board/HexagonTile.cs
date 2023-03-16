using TownRush.Enums;
using TownRush.Helpers;
using UnityEngine;

namespace TownRush.Board
{
    public class HexagonTile : MonoBehaviour, ITile
    {
        [field: SerializeField] public MeshRenderer MeshRenderer { get; private set; }

        public TileSettings TileSettings { get; set; }

        void ITile.Initialize(TileSettings tileSettings)
        {
            TileSettings = tileSettings;
            MeshRenderer = GetComponent<MeshRenderer>();
            GetComponent<ITile>().ChangeMaterial(OwnerTypes.EMPTY);
        }

        void ITile.ChangeMaterial(OwnerTypes ownerTypes)
            => MeshRenderer.material = MaterialHelper.SetTileMaterial(ownerTypes);

        Vector3 ITile.GetPosition() => transform.position;
    }
}