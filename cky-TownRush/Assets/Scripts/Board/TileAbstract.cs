using cky.Inputs;
using TownRush.Characters;
using TownRush.Enums;
using TownRush.Helpers;
using TownRush.Interfaces;
using UnityEngine;

namespace TownRush.Board
{
    public class TileAbstract : MonoBehaviour, ITile, IOwnable, IClickable
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
        {
            MeshRenderer.material = MaterialHelper.SetTileMaterial(ownerTypes);
        }

        public void SetOwnerType(OwnerTypes ownerType)
        {
            OwnerType = ownerType;
            ChangeMaterial(ownerType);
            SetLayer(ownerType);
        }

        private void SetLayer(OwnerTypes ownerType)
        {
            gameObject.layer = LayerHelper.CLICKABLE_TILE;
            //if (ownerType == OwnerTypes.PLAYER)
            //{
            //    gameObject.layer = LayerHelper.CLICKABLE_TILE;
            //}
            //else
            //{
            //    gameObject.layer = LayerHelper.NONCLICKABLE_TILE;
            //}
        }

        public void OnClick(Vector3 clickedPosition)
        {
            //if (OwnerType == OwnerTypes.PLAYER)
            //{
            CharacterSpawner.Instance.SpawnSoldier(OwnerType, clickedPosition);
            //}
        }
    }
}