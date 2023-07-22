using Platformer2D.Abstracts.Movements;
using Platformer2D.Inputs;
using Platformer2D.Movements;
using UnityEngine;

namespace Platformer2D.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] int _maxJumpCounter = 2;
        [SerializeField] int _currentJumpCounter = 0;
        [SerializeField] float _jumpForce = 500f;
        [SerializeField] Transform _transform;
        [SerializeField] Rigidbody2D _rigidbody2D;
        [SerializeField] Animator _animator;
        [SerializeField] SpriteRenderer _spriteRenderer;

        InputReader _inputReader;
        IMover _mover;
        IFlip _flip;
        IAnimation _animation;
        bool _isJump = false;

        void OnValidate()
        {
            if (_transform == null) _transform = transform;
            if (_rigidbody2D == null) _rigidbody2D = GetComponent<Rigidbody2D>();
            if (_spriteRenderer == null) _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        void Awake()
        {
            _inputReader = new InputReader();
            _mover = new MoveWithTranslate(_transform);
            _flip = new FlipWithSpriteRenderer(_spriteRenderer);
            _animation = new PlayerAnimation(new PlayerAnimationDataEntity()
            {
                Rigidbody2D = _rigidbody2D,
                Animator = _animator,
                InputReader = _inputReader
            });
        }

        void Update()
        {
            _mover.Tick(_inputReader.HorizontalInput);

            if (_inputReader.IsJumpButtonDown && _currentJumpCounter < _maxJumpCounter)
            {
                _isJump = true;
            }
        }

        void FixedUpdate()
        {
            _mover.FixedTick();

            //Jump'i moduler yapalim flip veya movement gibi
            if (_isJump && _currentJumpCounter < _maxJumpCounter)
            {
                _rigidbody2D.velocity = Vector2.zero;
                _rigidbody2D.AddForce(Time.deltaTime * _jumpForce * Vector2.up);
                _isJump = false;
                _currentJumpCounter++;
            }
        }

        void LateUpdate()
        {
            _animation.LateTick();
            _flip.LateUpdate(_inputReader.HorizontalInput);
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.contacts[0].normal == Vector2.up)
            {
                _currentJumpCounter = 0;
            }
        }
    }
}