using TMPro;
using UnityEngine;

namespace TownRush.Buildings.Tower
{
    public class Tower : BuildingAbstract
    {
        TowerInfo _towerInfo;
        int _currentFloor;

        [SerializeField] TextMeshProUGUI currentFloorTMP;

        public override void Initialize(TowerInfo towerInfo)
        {
            GetMeshRenderer();

            _towerInfo = towerInfo;
            modelTr = transform.GetChild(0);
            SetFloor(_towerInfo.startFloor);

            ChangeMaterial();
        }

        public override void SetType<T>(T type)
        {
            _towerInfo.SetTowerType((TowerType)(object)type);

            ChangeMaterial();
        }

        public override void ChangeMaterial()
        {
            mr.materials = TowerMaterialHelper.SetMaterials(_towerInfo.towerType);
        }

        private void SetFloor(int currentFloor)
        {
            _currentFloor = currentFloor;
            modelTr.localPosition = new Vector3(0, currentFloor, 0);
            //currentFloorTMP.text = $"{_currentFloor}";
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SetType(TowerType.ENEMY3);
        }
    }
}