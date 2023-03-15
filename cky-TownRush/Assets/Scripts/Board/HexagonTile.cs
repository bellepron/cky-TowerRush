using UnityEngine;

namespace cky.Board
{
    public class HexagonTile : MonoBehaviour, ITile
    {
        MeshRenderer _mr;

        public void Initialize(Material material)
        {
            _mr = GetComponent<MeshRenderer>();
            ChangeMaterial(material);
        }

        public void ChangeMaterial(Material material)
        {
            _mr.material = material;
        }
    }
}