using System.Collections.Generic;
using Platformer2D.Enums;
using Platformer2D.ScriptableObjects;
using UnityEngine;

namespace Platformer2D.Controllers
{
    public class DoorController : MonoBehaviour
    {
        [SerializeField] Sprite[] _doorSprites;
        [SerializeField] SpriteRenderer[] _doorSpriteRenderers;
        [SerializeField] List<ItemType> _itemTypes;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out PlayerController _playerController)) return;

            List<ItemDataContainer> itemDataContainers = new List<ItemDataContainer>();
            foreach (var itemType in _itemTypes)
            {
                var item = _playerController.Inventory.GetItemFromSlot(itemType);

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
            }
        }
    }
}