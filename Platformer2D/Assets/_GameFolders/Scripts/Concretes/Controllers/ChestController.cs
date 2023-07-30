using UnityEngine;

namespace Platformer2D.Controllers
{
    public class ChestController : MonoBehaviour
    {
        [SerializeField] GameObject _itemHolder;
        [SerializeField] Animator _animator;
        [SerializeField] Collider2D _collider2D;

        void OnValidate()
        {
            if (_animator == null) _animator = GetComponent<Animator>();
            if (_collider2D == null) _collider2D = GetComponent<Collider2D>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out PlayerController playerController)) return;
            
            _animator.SetTrigger("Open");
            _collider2D.enabled = false;
        }
    }    
}

