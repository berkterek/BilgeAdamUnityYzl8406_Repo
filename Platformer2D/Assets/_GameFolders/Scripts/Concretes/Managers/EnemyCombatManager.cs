using Platformer2D.Combats;
using Platformer2D.Controllers;

namespace Platformer2D.Managers
{
    public class EnemyCombatManager : ITakeAndDealDamageCombatService
    {
        readonly EnemyController _enemyController;
        readonly IHealth _health;
        readonly IDamage _damage;

        public EnemyCombatManager(EnemyController enemyController)
        {
            _enemyController = enemyController;
            _health = new Health(enemyController.MaxHealth);
            _damage = new Damage(enemyController.DamageValue);
        }
        
        public void TakeDamageProcess(IDamage damage)
        {
            _health.TakeDamage(damage);
        }

        public void GiveDamageProcess(IHealthService healthService)
        {
            healthService.TakeDamageProcess(_damage);
        }
    }
}