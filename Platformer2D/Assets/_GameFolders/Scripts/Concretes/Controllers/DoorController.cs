using System.Collections.Generic;
using Platformer2D.Enums;
using Platformer2D.Managers;
using Platformer2D.ScriptableObjects;
using UnityEngine;

namespace Platformer2D.Controllers  
{
    public class DoorController : MonoBehaviour
    {
        [SerializeField] int _levelValue = 1;
        [SerializeField] bool _canOpen = false;
        [SerializeField] bool _canEnter = false;
        [SerializeField] Collider2D _openCollider;
        [SerializeField] Collider2D _enterCollider;
        [SerializeField] Sprite[] _doorSprites;
        [SerializeField] SpriteRenderer[] _doorSpriteRenderers;
        [SerializeField] List<ItemType> _itemTypes;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out PlayerController playerController)) return;

            if (_canEnter)
            {
                GameManager.Instance.LevelChangedProcess(_levelValue);
            }

            OpenDoorProcess(playerController);
        }

        private void OpenDoorProcess(PlayerController playerController)
        {
            if (!_canOpen) return;

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
                Debug.Log("Start door open process");
                for (int i = 0; i < _doorSpriteRenderers.Length; i++)
                {
                    _doorSpriteRenderers[i].sprite = _doorSprites[i];
                }

                _canOpen = false;
                
                _openCollider.enabled = false;
                _enterCollider.enabled = true;
                
                _canEnter = true;
            }
        }
    }
}