using SpaceShipWars2D.Controllers;
using UnityEngine;

namespace SpaceShipWars2D.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Player Stats", menuName = "Bilge Adam/Stats/Player Stats")]
    public class PlayerStatsSO : ScriptableObject, IAttackStats, IMovementStats, IHealthStats
    {
        [Header("Movements")]
        [Tooltip("This movement speed is players movement speed")]
        [SerializeField, Range(1f,10f)] float _moveSpeed = 5f;

        [Header("Combats")]
        [SerializeField] LaserController _laserPrefab;
        [SerializeField, Range(0.1f, 2f)] float _fireRate = 0.5f;
        [SerializeField] int _maxHealth = 100;

        public float MoveSpeed => _moveSpeed;
        public float FireRate => _fireRate;
        public LaserController LaserPrefab => _laserPrefab;
        public int MaxHealth => _maxHealth;
    }

    public interface IAttackStats
    {
        LaserController LaserPrefab { get; }
        float FireRate { get; }
    }

    public interface IMovementStats
    {
        float MoveSpeed { get; }
    }

    public interface IHealthStats
    {
        int MaxHealth { get; }
    }
}

