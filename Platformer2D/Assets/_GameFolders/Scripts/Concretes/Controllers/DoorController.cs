using System.Collections.Generic;
using Newtonsoft.Json;
using Platformer2D.Enums;
using Platformer2D.Managers;
using Platformer2D.ScriptableObjects;
using UnityEngine;

namespace Platformer2D.Controllers  
{
    public class DoorController : MonoBehaviour
    {
        //const sabit degistirilemez demek daha hazili calismasi icin boyle bir yontem kullandik
        const string DOOR_KEY = "Door_Data_";

        [SerializeField] string _levelName;
        [SerializeField] int _uniqueID = 0;
        [SerializeField] int _levelValue = 1;
        [SerializeField] bool _canOpen = false;
        [SerializeField] bool _canEnter = false;
        [SerializeField] Transform _playerSetPoint;
        [SerializeField] Collider2D _openCollider;
        [SerializeField] Collider2D _enterCollider;
        [SerializeField] Sprite[] _doorSprites;
        [SerializeField] SpriteRenderer[] _doorSpriteRenderers;
        [SerializeField] List<ItemType> _itemTypes;
        
        public bool CanEnter => _canEnter;
        public Vector3 Point => _playerSetPoint.position;

        void Start()
        {
            LoadData();
            
            if (_canEnter)
            {
                OpenDoorProcess();
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out PlayerController playerController)) return;

            if (_canEnter)
            {
                GameManager.Instance.LevelChangedProcess(new DoorSendData()
                {
                    Point = _playerSetPoint.position,
                    LevelIncreaseData = _levelValue,
                    LevelName = _levelName
                });
            }

            OpenDoorProcess(playerController);
        }

        private void OpenDoorProcess(PlayerController playerController)
        {
            if (!_canOpen || _canEnter) return;

            List<ItemDataContainer> itemDataContainers = new List<ItemDataContainer>();
            foreach (var itemType in _itemTypes)
            {
                var item = playerController.Inventory.GetItemFromSlot(itemType);

                if (item != null)
                {
                    itemDataContainers.Add(item);
                }
            }

            if (itemDataContainers.Count > 0)
            {
                foreach (var itemDataContainer in itemDataContainers)
                {
                    _itemTypes.Remove(itemDataContainer.ItemType);
                }
            }

            if (_itemTypes.Count <= 0)
            {
                OpenDoorProcess();
                
                _canEnter = true;
                SaveData();
            }
        }

        private void LoadData()
        {
            if (PlayerPrefs.HasKey(DOOR_KEY + _uniqueID))
            {
                var dataEntityCore = PlayerPrefs.GetString(DOOR_KEY + _uniqueID);
                DoorSaveData dataEntity = JsonConvert.DeserializeObject<DoorSaveData>(dataEntityCore);

                if (dataEntity.UniqueID == _uniqueID) _canEnter = dataEntity.CanEnter;
            }
        }

        private void SaveData()
        {
            DoorSaveData dataEntity = new DoorSaveData()
            {
                UniqueID = _uniqueID,
                CanEnter = _canEnter
            };

            var dataEntityCore = JsonConvert.SerializeObject(dataEntity);
            PlayerPrefs.SetString(DOOR_KEY+_uniqueID, dataEntityCore);
        }

        private void OpenDoorProcess()
        {
            Debug.Log("Start door open process");
            for (int i = 0; i < _doorSpriteRenderers.Length; i++)
            {
                _doorSpriteRenderers[i].sprite = _doorSprites[i];
            }

            _canOpen = false;
                
            _openCollider.enabled = false;
            _enterCollider.enabled = true;
        }
    }

    public struct DoorSaveData
    {
        public int UniqueID { get; set; }
        public bool CanEnter { get; set; }
    }
}