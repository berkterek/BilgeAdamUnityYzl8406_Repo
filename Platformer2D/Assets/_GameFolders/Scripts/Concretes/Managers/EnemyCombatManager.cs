using Platformer2D.Combats;
using Platformer2D.Controllers;
using UnityEngine;

namespace Platformer2D.Managers
{
    public class EnemyCombatManager : ITakeAndDealDamageCombatService
    {
        readonly EnemyController _enemyController;
        readonly IHealth _health;
        readonly IDamage _damage;

        public IDamage Damage => _damage;

        public EnemyCombatManager(EnemyController enemyController)
        {
            _enemyController = enemyController;
            _health = new Health(enemyController.MaxHealth);
            _damage = new Damage(enemyController.DamageValue);

            _health.OnCurrentHealthValueChanged += HandleOnCurrentHealthValueChanged;
        }

        public void TakeDamageProcess(IDamage damage)
        {
            if (_health.CurrentHealth <= 0) return;
            
            _health.TakeDamage(damage);
        }

        public void GiveDamageProcess(IHealthService healthService)
        {
            healthService.TakeDamageProcess(_damage);
        }

        void HandleOnCurrentHealthValueChanged(int currentHealth, int maxHealth)
        {
            if (currentHealth <= 0)
            {
                GameObject.Destroy(_enemyController.gameObject);    
            }
        }
    }
}