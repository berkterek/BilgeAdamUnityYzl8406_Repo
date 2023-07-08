using SpaceShipWars2D.Combats;
using SpaceShipWars2D.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWars2D.Controllers
{
    public class EnemyController : MonoBehaviour,IEntityController
    {
        Health _health;
        
        void Awake()
        {
            IHealthStats stats = new HealthTestStats();
            _health = new Health(stats);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out LaserController laserController))
            {
                _health.TakeDamage(laserController.Damage);
            }
        }
    }

    public class HealthTestStats : IHealthStats
    {
        public int MaxHealth { get; } = 100;
    }
}

