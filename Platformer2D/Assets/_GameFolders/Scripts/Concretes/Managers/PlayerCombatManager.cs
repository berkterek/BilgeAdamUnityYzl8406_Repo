using Platformer2D.Combats;
using Platformer2D.Controllers;
using UnityEngine;

namespace Platformer2D.Managers
{
    public class PlayerCombatManager :  ITakeAndDealDamageCombatService
    {
        readonly PlayerController _playerController;
        readonly IHealth _health;
        readonly IDamage _damage;

        public PlayerCombatManager(PlayerController playerController)
        {
            _playerController = playerController;
            _health = new Health(playerController.MaxHealth);
            _damage = new Damage(playerController.DamageValueValue);
        }

        public void GiveDamageProcess(IHealthService healthService)
        {
            healthService.TakeDamageProcess(_damage);
            Debug.Log($"<color=green>Player deal damage to enemy</color>");
            _playerController.MovementManager.AfterDealDamageJump();
        }

        public void TakeDamageProcess(IDamage damage)
        {
            _health.TakeDamage(_damage);
        }
    }

    public interface ITakeAndDealDamageCombatService : IHealthService ,IAttackService
    {
        
    }

    public interface IHealthService
    {
        void TakeDamageProcess(IDamage damage);
    }

    public interface IAttackService
    {
        void GiveDamageProcess(IHealthService healthService);
    }
}