using Platformer3D.Abstracts.Movements;
using Platformer3D.Controllers;
using UnityEngine;

namespace Platformer3D.Movements
{
    public class CharacterControllerSimpleMove : IMover
    {
        readonly CharacterController _characterController;
        readonly PlayerController _playerController;

        Vector3 _movement;
        
        public CharacterControllerSimpleMove(MoveInjectionData data)
        {
            _playerController = data.PlayerController;
            _characterController = data.CharacterController;
        }
        
        public void Tick(Vector3 direction)
        {
            _movement = _playerController.MoveSpeed * Time.deltaTime * direction;
        }

        public void FixedTick()
        {
            _characterController.SimpleMove(_movement);
        }
    }
    
    public class CharacterControllerMove : IMover
    {
        readonly CharacterController _characterController;
        readonly PlayerController _playerController;
        private bool groundedPlayer;
        private float jumpHeight = 1.0f;
        private float gravityValue = -9.81f;


        private Vector3 playerVelocity;

        public CharacterControllerMove(MoveInjectionData data)
        {
            _playerController = data.PlayerController;
            _characterController = data.CharacterController;
        }
        
        public void Tick(Vector3 direction)
        {
            groundedPlayer = _characterController.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            
            if (direction != Vector3.zero)
            {
                _playerController.gameObject.transform.forward = direction;
            }
            
            playerVelocity = _playerController.MoveSpeed * Time.deltaTime * direction;
            playerVelocity.y += gravityValue * Time.deltaTime;
        }

        public void FixedTick()
        {
            _characterController.Move(playerVelocity);
            _characterController.Move(playerVelocity * Time.deltaTime);
        }
    }

    public class RigidbodyMove : IMover
    {
        readonly Rigidbody _rigidbody;
        readonly PlayerController _playerController;
        
        Vector3 _movement;

        public RigidbodyMove(MoveInjectionData data)
        {
            _rigidbody = data.Rigidbody;
            _playerController = data.PlayerController;
        }

        public void Tick(Vector3 direction)
        {
            _movement = _playerController.MoveSpeed * Time.deltaTime * direction;
        }

        public void FixedTick()
        {
            _rigidbody.velocity += _movement;

            if (_rigidbody.velocity.magnitude > 10f)
            {
                _rigidbody.velocity = Vector3.zero;
            }
        }
    }

    public class TranslateMove : IMover
    {
        readonly PlayerController _playerController;
        readonly Transform _transform;
        
        Vector3 _movement;

        public TranslateMove(MoveInjectionData data)
        {
            _playerController = data.PlayerController;
            _transform = _playerController.transform;
        }
        
        public void Tick(Vector3 direction)
        {
            _movement = _playerController.MoveSpeed * Time.deltaTime * direction;
        }

        public void FixedTick()
        {
            _transform.Translate(_movement);
        }
    }

    public struct MoveInjectionData
    {
        public CharacterController CharacterController;
        public Rigidbody Rigidbody;
        public PlayerController PlayerController;
    }
}