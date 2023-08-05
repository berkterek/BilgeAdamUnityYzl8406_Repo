using UnityEngine;

namespace Platformer2D.Controllers
{
    public class CoinController : BaseCoinController
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out PlayerController playerController)) return;

            SetCoinToPlayer(playerController);
        }

        protected override void AfterCoinState()
        {
            base.AfterCoinState();
            if (_currentCoinCounter <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public abstract class BaseCoinController : MonoBehaviour
    {
        [SerializeField] int _coinValue = 1;
        [SerializeField] int _maxCoinCounter = 1;

        protected int _currentCoinCounter = 0;

        void Start()
        {
            _currentCoinCounter = _maxCoinCounter;
        }

        protected void SetCoinToPlayer(PlayerController playerController)
        {
            playerController.Coin += _coinValue;

            AfterCoinState();
        }

        protected virtual void AfterCoinState()
        {
            _currentCoinCounter--;
        }
    }
}