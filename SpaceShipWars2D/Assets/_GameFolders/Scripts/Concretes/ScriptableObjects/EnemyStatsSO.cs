using SpaceShipWars2D.Controllers;
using UnityEngine;

namespace SpaceShipWars2D.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Enemy Stats", menuName = "Bilge Adam/Stats/Enemy Stats")]
    public class EnemyStatsSO : ScriptableObject, IAttackStats, IMovementStats, IHealthStats, IDyingStats,IScoreStats
    {
        [Header("Movements")]
        [Tooltip("This movement speed is players movement speed")]
        [SerializeField, Range(1f,10f)] float _moveSpeed = 5f;

        [Header("Combats")]
        [SerializeField] LaserController _laserPrefab;
        [SerializeField, Range(0.1f, 10f)] float _minFireRate = 0.5f;
        [SerializeField, Range(0.1f, 10f)] float _maxFireRate = 2f;
        [SerializeField] int _maxHealth = 100;
        [SerializeField] int _maxDamage = 10;
        [SerializeField] int _minDamage = 2;
        [SerializeField] float _dyingDelayTime = 1f;
        [SerializeField] int _minScore = 5;
        [SerializeField] int _maxScore = 10;

        public LaserController LaserPrefab => _laserPrefab;
        public float FireRate => Random.Range(_minFireRate, _maxFireRate);
        public int MaxDamage => Random.Range(_minDamage, _maxDamage);
        public float MoveSpeed => _moveSpeed;
        public int MaxHealth => _maxHealth;
        public float DyingDelayTime => _dyingDelayTime;
        public int Score => Random.Range(_minScore, _maxScore);
    }

    public interface IScoreStats
    {
        int Score { get; }
    }
}