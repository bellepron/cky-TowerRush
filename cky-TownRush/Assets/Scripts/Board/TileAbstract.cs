using cky.Inputs;
using DG.Tweening;
using System;
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

        public Vector3 GetPosition() => transform.position;

        public void ChangeMaterial(OwnerTypes ownerTypes)
        {
            MeshRenderer.material = MaterialHelper.SetTileMaterial(ownerTypes);
        }

        public void SetOwnerType(OwnerTypes ownerType)
        {
            OwnerType = ownerType;
            ChangeMaterial(ownerType);
            SetLayer(ownerType);

            Animation();
        }

        public void Animation()
        {
            var tr = transform;
            var y = tr.position.y;
            var seq = DOTween.Sequence();
            seq.Append(tr.DOMoveY(y + 1, 0.15f));
            seq.Join(tr.DOScale(Vector3.one * 0.9f, 0.15f));
            seq.Append(tr.DOMoveY(y, 0.1f));
            seq.Join(tr.DOScale(Vector3.one, 0.15f));
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