using System;
using Platformer2D.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace Platformer2D.Uis
{
    public class CoinTextDisplay : MonoBehaviour
    {
        [SerializeField] PlayerDataContainer _playerDataContainer;
        [SerializeField] TMP_Text _text;

        void OnValidate()
        {
            if (_text == null) _text = GetComponent<TMP_Text>();
        }

        void Start()
        {
            _text.SetText(_playerDataContainer.Coin.CoinValue.ToString());
        }

        void OnEnable()
        {
            _playerDataContainer.Coin.OnCoinValueChanged += HandleOnCoinValueChanged;
        }

        void OnDisable()
        {
            _playerDataContainer.Coin.OnCoinValueChanged -= HandleOnCoinValueChanged;
        }
        
        void HandleOnCoinValueChanged(int value)
        {
            _text.SetText(value.ToString());
        }
    }    
}

