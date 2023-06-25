using UnityEngine;

namespace SpaceShipWars2D.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Laser Stats", menuName = "Bilge Adam/Stats/Laser Stats")]
    public class LaserStatsSO : ScriptableObject
    {
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] bool _isGoingUp;

        public Vector2 OneWayDirection { get; private set; }
        public float MoveSpeed => _moveSpeed;

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
}

