using Platformer2D.ScriptableObjects;
using UnityEngine;

namespace Platformer2D.Controllers
{
    public class ItemHolderController : MonoBehaviour
    {
        [SerializeField] ItemDataContainer _itemData;
        [SerializeField] SpriteRenderer _spriteRenderer;

        void OnEnable()
        {
            _spriteRenderer.sprite = _itemData.ItemSprite;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out PlayerController playerController)) return;
            
            playerController.Inventory.SetItemToSlot(_itemData);
            Destroy(this.gameObject);
        }
    }    
}

