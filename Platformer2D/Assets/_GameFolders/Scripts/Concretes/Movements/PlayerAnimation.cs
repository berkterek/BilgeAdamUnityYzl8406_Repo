using Platformer2D.Abstracts.Movements;
using Platformer2D.Inputs;
using UnityEngine;

namespace Platformer2D.Movements
{
    public class PlayerAnimation : IAnimation
    {
        readonly Animator _animator;
        readonly Rigidbody2D _rigidbody2D;
        readonly InputReader _inputReader;

        public PlayerAnimation(PlayerAnimationDataEntity entity)
        {
            _animator = entity.Animator;
            _rigidbody2D = entity.Rigidbody2D;
            _inputReader = entity.InputReader;
        }
        
        public void LateTick()
        {
            _animator.SetFloat("Speed", Mathf.Abs(_inputReader.HorizontalInput));
            _animator.SetBool("IsJump", !_rigidbody2D.velocity.y.Equals(0f));
            _animator.SetFloat("JumpYVelocity", _rigidbody2D.velocity.y > 0f ? 1f : -1f); //kisa yazim ternary if
            //uzun yazim if else
            // if (_rigidbody2D.velocity.y > 0f)
            // {
            //     _animator.SetFloat("JumpYVelocity", 1f);
            // }
            // else
            // {
            //     _animator.SetFloat("JumpYVelocity", -1f);
            // }
        }
    }

    public struct PlayerAnimationDataEntity
    {
        public Animator Animator { get; set; }
        public Rigidbody2D Rigidbody2D { get; set; }
        public InputReader InputReader { get; set; }
    }
}