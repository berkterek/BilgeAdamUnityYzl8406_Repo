using UnityEngine;

namespace Platformer2D.Controllers
{
    public class CoinController : MonoBehaviour
    {
        [SerializeField] int _coinValue = 1;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out PlayerController playerController)) return;

            playerController.Coin += _coinValue;
            Debug.Log("Player Coin => " + playerController.Coin);
            Destroy(this.gameObject);
        }
    }    
}