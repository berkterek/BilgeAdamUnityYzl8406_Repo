using SpaceShipWars2D.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWars2D.Combats
{
    public class Health : IHealth
    {
        readonly IHealthStats _stats;
        int _currentHealth;

        bool IsDead => _currentHealth <= 0;

        public event System.Action OnDead;
        
        public Health(IHealthStats stats)
        {
            _stats = stats;
            _currentHealth = _stats.MaxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (IsDead) return;
            
            _currentHealth -= damage;
            Debug.Log(_currentHealth);

            if (IsDead)
            {
                Debug.Log("Dying");
                OnDead?.Invoke();
            }
        }
    }

    public interface IHealth
    {
        void TakeDamage(int damage);
        event System.Action OnDead;
    }
}