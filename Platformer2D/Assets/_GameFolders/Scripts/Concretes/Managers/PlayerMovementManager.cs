using Platformer2D.Abstracts.Managers;
using Platformer2D.Abstracts.Movements;
using Platformer2D.Controllers;
using Platformer2D.Movements;
using UnityEngine;

namespace Platformer2D.Managers
{
    public class PlayerMovementManager : IPlayerMoveService
    {
        readonly PlayerController _playerController;
        readonly IMoverDal _mover;
        readonly IJump _jump;
        readonly Rigidbody2D _rigidbody2D;
        
        Vector3 _direction;
        bool _isJump = false;
        int _currentJumpCounter = 0;

        public PlayerMovementManager(PlayerController playerController)
        {
            _playerController = playerController;
            _mover = new MoveWithTranslate(_playerController.transform);
            _rigidbody2D = _playerController.GetComponent<Rigidbody2D>();
            _jump = new JumpWithRigidbody(_rigidbody2D);
        }

        public void Tick()
        {
            _direction = _playerController.InputReader.HorizontalInput * Vector3.right;
            
            //Jump input
            if (_playerController.InputReader.IsJumpButtonDown && _currentJumpCounter < _playerController.MaxJumpCounter)
            {
                _isJump = true;
            }
        }

        public void FixedTick()
        {
            if (_isJump && _currentJumpCounter < _playerController.MaxJumpCounter)
            {
                _jump.FixedTick(_playerController.JumpForce);
                _isJump = false;
                _currentJumpCounter++;
            }
            
            _mover.FixedTick(2f * Time.deltaTime * _direction);
        }

        public void LateTick()
        {
            _playerController.Flip.LateTick(_direction.x);
        }

        public void ResetJumpCounter()
        {
            _currentJumpCounter = 0;
        }
    }
}