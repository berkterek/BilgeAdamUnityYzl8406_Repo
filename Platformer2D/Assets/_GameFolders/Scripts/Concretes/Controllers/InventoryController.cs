using Platformer2D.ScriptableObjects;
using UnityEngine;

namespace Platformer2D.Controllers
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] SlotController[] _slotControllers;

        public void SetItemToSlot(ItemDataContainer itemDataContainer)
        {
            foreach (var slot in _slotControllers)
            {
                if(!slot.IsSlotEmpty) continue;
                
                slot.SetItem(itemDataContainer);
                break;
            }
        }

        public ItemDataContainer GetItemFromSlot()
        {
            ItemDataContainer itemDataContainer = null;
            foreach (var slot in _slotControllers)
            {
                if (slot.IsSlotEmpty) continue;

                itemDataContainer = slot.GetItem();
                slot.SlotClean();

                break;
            }

            return itemDataContainer;
        }

        public ItemDataContainer GetItemFromSlot(int index)
        {
            if (index >= _slotControllers.Length || index < 0) return null;
            return _slotControllers[index].GetItem();
        }
    }
}

