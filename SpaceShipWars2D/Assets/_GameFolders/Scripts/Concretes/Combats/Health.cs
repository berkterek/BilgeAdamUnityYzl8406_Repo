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
        public event System.Action<int> OnDamageTaken;
        
        public Health(IHealthStats stats)
        {
            _stats = stats;
            _currentHealth = _stats.MaxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (IsDead) return;
            
            _currentHealth -= damage;

            if (IsDead) _currentHealth = 0;
            
            OnDamageTaken?.Invoke(_currentHealth);

            if (IsDead)
            {
                OnDead?.Invoke();
            }
        }
    }

    public interface IHealth
    {
        void TakeDamage(int damage);
        event System.Action OnDead;
        event System.Action<int> OnDamageTaken;
    }
}