using SpaceShipWars2D.Abstracts.Movements;
using UnityEngine;

namespace SpaceShipWars2D.Movements
{
    public class MoveWithTranslate : IMover
    {
        readonly Transform _transform;
        
        Vector3 _movement;
        
        public MoveWithTranslate(Transform transform)
        {
            _transform = transform;
        }
        
        public void Tick(Vector2 direction)
        {
            _movement = direction;
        }

        public void FixedTick()
        {
            _transform.Translate(_movement);
        }
    }
    
    public class MoveWithTransform : IMover
    {
        readonly Transform _transform;

        Vector3 _movement;

        public MoveWithTransform(Transform transform)
        {
            _transform = transform;
        }
        
        public void Tick(Vector2 direction)
        {
            _movement = direction;
        }

        public void FixedTick()
        {
            _transform.position += _movement;
        }
    }
}

