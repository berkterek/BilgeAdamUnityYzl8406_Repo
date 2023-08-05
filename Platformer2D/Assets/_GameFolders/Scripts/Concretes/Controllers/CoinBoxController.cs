using System.Collections;
using UnityEngine;

namespace Platformer2D.Controllers
{
    public class CoinBoxController : BaseCoinController
    {
        [SerializeField] Sprite _closedSprite;
        [SerializeField] SpriteRenderer _spriteRenderer;
        [SerializeField] Animator _animator;
        [SerializeField] bool _canCollected = true;
        
        void OnValidate()
        {
            if (_animator == null) _animator = GetComponent<Animator>();
            if (_spriteRenderer == null) _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        
        void OnCollisionEnter2D(Collision2D other)
        {
            if (!_canCollected) return;
            
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
            _canCollected = _currentCoinCounter > 0;
            _animator.SetTrigger("Collected");

            if (!_canCollected)
            {
                StartCoroutine(WaitAndSetClosedSprite());
            }
        }

        private IEnumerator WaitAndSetClosedSprite()
        {
            yield return new WaitForSeconds(1f);
            _spriteRenderer.sprite = _closedSprite;
        }
    }
}