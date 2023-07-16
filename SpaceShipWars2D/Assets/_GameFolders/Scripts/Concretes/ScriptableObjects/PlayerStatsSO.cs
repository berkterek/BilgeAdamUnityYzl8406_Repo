using SpaceShipWars2D.Controllers;
using UnityEngine;
using UnityEngine.Serialization;

namespace SpaceShipWars2D.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Player Stats", menuName = "Bilge Adam/Stats/Player Stats")]
    public class PlayerStatsSO : ScriptableObject, IAttackStats, IMovementStats, IHealthStats,IDyingStats
    {
        [Header("Movements")]
        [Tooltip("This movement speed is players movement speed")]
        [SerializeField, Range(1f,10f)] float _moveSpeed = 5f;

        [FormerlySerializedAs("_laserPrefab")]
        [Header("Combats")]
        [SerializeField] LaserStatsSO _laserStats;
        [SerializeField, Range(0.1f, 2f)] float _fireRate = 0.5f;
        [SerializeField] int _maxHealth = 100;
        [SerializeField] int _maxDamage = 10;
        [SerializeField] float _dyingDelayTime = 1.3f;

        public float MoveSpeed => _moveSpeed;
        public float FireRate => _fireRate;
        public int MaxDamage => _maxDamage;
        public LaserStatsSO LaserStats => _laserStats;
        public int MaxHealth => _maxHealth;
        public float DyingDelayTime => _dyingDelayTime;

        public event System.Action<int> OnHealthValueChanged;

        public void HealthValueChange(int value)
        {
            OnHealthValueChanged?.Invoke(value);
        }
    }

    public interface IAttackStats
    {
        LaserStatsSO LaserStats { get; }
        float FireRate { get; }
        int MaxDamage { get; }
    }

    public interface IMovementStats
    {
        float MoveSpeed { get; }
    }

    public interface IHealthStats
    {
        int MaxHealth { get; }
    }

    public interface IDyingStats
    {
        float DyingDelayTime { get; }
    }
}

