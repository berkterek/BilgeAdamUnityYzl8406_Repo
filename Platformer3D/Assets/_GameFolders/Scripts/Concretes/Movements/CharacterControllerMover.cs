using Platformer3D.Abstracts.Movements;
using Platformer3D.Sample2.Controllers;
using UnityEngine;

namespace Platformer3D.Sample2.Movements
{
    public class CharacterControllerMover : IMover
    {
        readonly CharacterController _characterController;
        readonly RobotKyleController _playerController;
        private bool groundedPlayer;
        private float jumpHeight = 1.0f;
        private float gravityValue = -9.81f;


        private Vector3 playerVelocity;

        public CharacterControllerMover(RobotKyleController data)
        {
            _playerController = data;
            _characterController = _playerController.GetComponent<CharacterController>();
        }

        public void Tick(Vector3 direction)
        {
            groundedPlayer = _characterController.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            
            Vector3 worldDirection = _playerController.transform.TransformDirection(direction);

            playerVelocity = 5f * Time.deltaTime * worldDirection;
            playerVelocity.y += gravityValue * Time.deltaTime;
        }

        public void FixedTick()
        {
            _characterController.Move(playerVelocity);
            _characterController.Move(playerVelocity * Time.deltaTime);
        }
    }
}