using Platformer2D.ScriptableObjects;
using UnityEngine;

namespace Platformer2D.Controllers
{
    public class SlotController : MonoBehaviour
    {
        [SerializeField] ItemDataContainer _itemDataContainer;
        [SerializeField] SpriteRenderer _spriteRenderer;

        public bool IsSlotEmpty => _spriteRenderer.sprite == null || _itemDataContainer == null;

        void OnValidate()
        {
            if (_spriteRenderer == null) _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetItem(ItemDataContainer itemDataContainer)
        {
            _itemDataContainer = itemDataContainer;
            _spriteRenderer.sprite = itemDataContainer.ItemSprite;
        }

        public ItemDataContainer GetItem()
        {
            _spriteRenderer.sprite = null;
            return _itemDataContainer;
        }

        public void SlotClean()
        {
            _itemDataContainer = null;
            _spriteRenderer.sprite = null;
        }
    }
}