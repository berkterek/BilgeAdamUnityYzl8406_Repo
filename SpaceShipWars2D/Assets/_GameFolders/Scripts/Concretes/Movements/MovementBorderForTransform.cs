using UnityEngine;

namespace SpaceShipWars2D.Movements
{
    public class MovementBorderForTransform : IMovementBorder
    {
        readonly Transform _transform;
        
        public MovementBorderForTransform(Transform transform)
        {
            _transform = transform;
        }

        public void Tick()
        {
            Vector3 currentPosition = _transform.position;
            float xDirection = Mathf.Clamp(currentPosition.x, -2f, 2f);
            float yDirection = Mathf.Clamp(currentPosition.y, -4.5f, 0f);

            var newPosition = new Vector3(xDirection, yDirection, 0f);
            _transform.position = newPosition;
        }
    }
}