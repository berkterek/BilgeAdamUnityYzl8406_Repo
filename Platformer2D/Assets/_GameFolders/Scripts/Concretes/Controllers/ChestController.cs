using TMPro;
using UnityEngine;

namespace Platformer2D.Controllers
{
    public class ChestController : MonoBehaviour
    {
        [SerializeField] int _spendCoin = 5;
        [SerializeField] GameObject _itemHolder;
        [SerializeField] Animator _animator;
        [SerializeField] Collider2D _collider2D;
        [SerializeField] TMP_Text _coinValueText;

        void OnValidate()
        {
            if (_animator == null) _animator = GetComponent<Animator>();
            if (_collider2D == null) _collider2D = GetComponent<Collider2D>();
        }

        void Start()
        {
            _coinValueText.SetText(_spendCoin.ToString());
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out PlayerController playerController)) return;

            if (playerController.PlayerDataContainer.Coin.DecreaseCoinProcess(_spendCoin))
            {
                _coinValueText.SetText("0");
                _animator.SetTrigger("Open");
                _collider2D.enabled = false;                
            }
        }
    }
}