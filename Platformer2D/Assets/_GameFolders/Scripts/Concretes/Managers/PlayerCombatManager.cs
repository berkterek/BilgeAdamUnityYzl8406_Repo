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

        public IDamage Damage => _damage;

        public PlayerCombatManager(PlayerController playerController)
        {
            _playerController = playerController;
            _health = new Health(playerController.MaxHealth);
            _damage = new Damage(playerController.DamageValueValue);

            _health.OnCurrentHealthValueChanged += HandleOnCurrentHealthValueChanged;
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
        
        void HandleOnCurrentHealthValueChanged(int currentHealth, int maxHealth)
        {
            if (currentHealth <= 0)
            {
                GameObject.Destroy(_playerController.gameObject);
            }
            else
            {
                _playerController.transform.position = _playerController.LastCheckPoint.position;
                Debug.Log($"<color=red>Player take damage from enemy</color>");
            }
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
        IDamage Damage { get; }
    }
}