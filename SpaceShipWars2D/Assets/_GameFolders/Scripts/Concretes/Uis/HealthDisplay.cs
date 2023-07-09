using System;
using SpaceShipWars2D.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace SpaceShipWars2D.Uis
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] TMP_Text _healthText;
        [SerializeField] PlayerDataContainerSO _playerDataContainer;

        void OnValidate()
        {
            if (_healthText == null) _healthText = GetComponent<TMP_Text>();
        }

        void Start()
        {
            _healthText.SetText(_playerDataContainer.PlayerStats.MaxHealth.ToString());
        }

        void OnEnable()
        {
            _playerDataContainer.PlayerStats.OnHealthValueChanged += HandleOnHealthValueChanged;
        }

        void OnDisable()
        {
            _playerDataContainer.PlayerStats.OnHealthValueChanged -= HandleOnHealthValueChanged;
        }
        
        void HandleOnHealthValueChanged(int health)
        {
            _healthText.SetText(health.ToString());
        }
    }
}