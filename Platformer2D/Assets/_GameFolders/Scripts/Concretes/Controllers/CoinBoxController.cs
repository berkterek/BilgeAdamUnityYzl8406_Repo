using UnityEngine;

namespace Platformer2D.Controllers
{
    public class CoinBoxController : BaseCoinController
    {
        [SerializeField] Animator _animator;
        
        bool _canCollected;

        void OnValidate()
        {
            if (_animator == null) _animator = GetComponent<Animator>();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (_canCollected) return;
            
            if (other.collider.TryGetComponent(out PlayerController playerController))
            {
                if (other.contacts[0].normal == Vector2.up)
                {
                    SetCoinToPlayer(playerController);
                }
            }
        }

        protected override void AfterCoinState()
        {
            base.AfterCoinState();
            _canCollected = _currentCoinCounter <= 0;
            _animator.SetTrigger("Collected");
        }
    }
}