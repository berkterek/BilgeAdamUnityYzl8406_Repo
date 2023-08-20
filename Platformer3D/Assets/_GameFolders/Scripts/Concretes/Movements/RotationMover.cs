using Platformer3D.Sample2.Controllers;
using UnityEngine;

namespace Platformer3D.Sample2.Movements
{
    public class RotationMover
    {
        readonly RobotKyleController _robotKyleController;

        float _horizontalRotation;
        float _verticalRotation;
        float verticalAngle = 0f;
        float verticalRotationLimit = 35f; // Dikey

        public RotationMover(RobotKyleController robotKyleController)
        {
            _robotKyleController = robotKyleController;
        }

        public void Tick(Vector2 delta)
        {
            _horizontalRotation = delta.x;
            _verticalRotation = delta.y;
        }

        public void FixedTick()
        {
            _robotKyleController.transform.Rotate(5f * Time.deltaTime * _horizontalRotation * Vector3.up);
            
            verticalAngle -= 5f * Time.deltaTime * _verticalRotation;
            verticalAngle = Mathf.Clamp(verticalAngle, -verticalRotationLimit, verticalRotationLimit);

            _robotKyleController.VerticalRotationTransform.localRotation = Quaternion.Euler(verticalAngle, 0f, 0f);
        }
    }
}