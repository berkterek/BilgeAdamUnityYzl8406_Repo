using Platformer3D.Sample2.Controllers;
using UnityEngine;

namespace Platformer3D.Sample2.Movements
{
    public class RotationMover
    {
        readonly RobotKyleController _robotKyleController;
        readonly Camera _camera;

        float _horizontalRotation;

        public RotationMover(RobotKyleController robotKyleController)
        {
            _robotKyleController = robotKyleController;
            _camera = Camera.main;
        }

        public void Tick(Vector2 delta)
        {
            _horizontalRotation = delta.x;
        }

        public void FixedTick()
        {
            _robotKyleController.transform.Rotate(3f * Time.deltaTime * _horizontalRotation * Vector3.up);
        }
    }
}