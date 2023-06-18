using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CircleBall3D.Combats
{
    public class Health
    {
        readonly Image _healthBarImage;
        readonly float _maxHealth;
        float _currentHealth;
        
        public event System.Action OnDead;
        
        public Health(HealthData healthData)
        {
            _currentHealth = healthData.MaxHealth;
            _maxHealth = healthData.MaxHealth;
            _healthBarImage = healthData.HealthBarImage;
        }

        public void TakeHit(int damage)
        {
            if (_currentHealth <= 0) return;
            
            _currentHealth -= damage;
            _healthBarImage.fillAmount = _currentHealth / _maxHealth;

            if (_currentHealth <= 0)
            {
                Debug.Log("Player already dead");
                OnDead?.Invoke();
            }
        }
    }

    public struct HealthData
    {
        public int MaxHealth { get; set; }
        public Image HealthBarImage { get; set; }
    }
}

