using TownRush.Buildings;
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
            GetComponent<ITile>().ChangeMaterial(BuildingOwnerTypes.EMPTY);
        }

        void ITile.ChangeMaterial(BuildingOwnerTypes buildingOwnerTypes)
            => MeshRenderer.material = MaterialHelper.SetTileMaterial(buildingOwnerTypes);

        Vector3 ITile.GetPosition() => transform.position;
    }
}