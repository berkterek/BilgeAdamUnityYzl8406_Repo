using Platformer2D.Abstracts.Managers;
using Platformer2D.Abstracts.Movements;
using Platformer2D.Inputs;
using Platformer2D.Managers;
using Platformer2D.Movements;
using UnityEngine;

namespace Platformer2D.Controllers
{
    //User interface Layer
    //Kullanici kisiinin iletiisimde bulunup business tarafini calistiridigi alandir
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] int _maxJumpCounter = 2;
        [SerializeField] float _jumpForce = 500f;
        [SerializeField] Transform _transform;
        [SerializeField] Rigidbody2D _rigidbody2D;
        [SerializeField] Animator _animator;
        [SerializeField] SpriteRenderer _spriteRenderer;

        IAnimation _animation;
        IPlayerMoveService _movementManager;
        
        public InputReader InputReader { get; private set; }
        public IFlip Flip { get; private set; }
        public int MaxJumpCounter => _maxJumpCounter;
        public float JumpForce => _jumpForce;

        void OnValidate()
        {
            if (_transform == null) _transform = transform;
            if (_rigidbody2D == null) _rigidbody2D = GetComponent<Rigidbody2D>();
            if (_spriteRenderer == null) _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        void Awake()
        {
            InputReader = new InputReader();
            _movementManager = new PlayerMovementManager(this);
            Flip = new FlipWithSpriteRenderer(_spriteRenderer);
            _animation = new PlayerAnimation(new PlayerAnimationDataEntity()
            {
                Rigidbody2D = _rigidbody2D,
                Animator = _animator,
                InputReader = InputReader
            });
        }

        void Update()
        {
            _movementManager.Tick();
        }

        void FixedUpdate()
        {
            _movementManager.FixedTick();
        }

        void LateUpdate()
        {
            _animation.LateTick();
            _movementManager.LateTick();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.contacts[0].normal == Vector2.up)
            {
                _movementManager.ResetJumpCounter();
                
                
            }
        }
    }
}