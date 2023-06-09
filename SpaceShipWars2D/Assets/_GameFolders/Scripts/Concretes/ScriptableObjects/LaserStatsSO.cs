using UnityEngine;

namespace SpaceShipWars2D.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Laser Stats", menuName = "Bilge Adam/Stats/Laser Stats")]
    public class LaserStatsSO : ScriptableObject, IMovementStats,ILaserDyingStats
    {
        [Header("Dying Values")]
        [SerializeField] Sprite _dyingSprite;
        [SerializeField] float _delayTime = 0.5f;
        
        [Header("Movement Values")]
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] bool _isGoingUp;

        public Vector2 OneWayDirection { get; private set; }
        public float MoveSpeed => _moveSpeed;
        public Sprite DyingSprite => _dyingSprite;
        public float DelayTime => _delayTime;

        void OnEnable()
        {
            if (_isGoingUp)
            {
                OneWayDirection = Vector2.up;
            }
            else
            {
                OneWayDirection = Vector2.down;
            }
        }
    }

    public interface ILaserDyingStats
    {
        Sprite DyingSprite { get; }
        float DelayTime { get; }
    }
}

