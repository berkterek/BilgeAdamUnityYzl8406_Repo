using SpaceShipWars2D.Abstracts.Movements;
using SpaceShipWars2D.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWars2D.Movements
{
    public class MoveWithTransform : IMover
    {
        readonly Transform _transform;
        readonly IMovementStats _movementStats;

        Vector3 _movement;

        public MoveWithTransform(MovementData data)
        {
            _transform = data.Transform;
            _movementStats = data.MovementStats;
        }
        
        public void Tick(Vector2 direction)
        {
            _movement = _movementStats.MoveSpeed * Time.deltaTime* direction;
        }

        public void FixedTick()
        {
            _transform.position += _movement;
        }
    }
}