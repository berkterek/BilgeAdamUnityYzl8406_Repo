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
        [SerializeField] int _maxHealth = 3;
        [SerializeField] int _currentHealth;
        [SerializeField] int _damage = 1;
        [SerializeField] Transform _lastCheckPoint;

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

        void Start()
        {
            _currentHealth = _maxHealth;
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
            var contact = other.contacts[0];
            if (contact.normal == Vector2.up) //Deal Damage
            {
                _movementManager.ResetJumpCounter();

                if (contact.collider.TryGetComponent(out EnemyController enemyController))
                {
                    Debug.Log(
                        $"<color=green>Player deal damage to enemy => {contact.collider.gameObject.name}</color>");
                    enemyController.TakeDamage(_damage);
                    _movementManager.AfterDealDamageJump();
                }
            }
            else //Take Damage
            {
                if (contact.collider.TryGetComponent(out EnemyController enemyController))
                {
                    _currentHealth -= enemyController.Damage;
                    if (_currentHealth <= 0)
                    {
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        Debug.Log(
                            $"<color=red>Player take damage from enemy => {contact.collider.gameObject.name}</color>");
                        _transform.position = _lastCheckPoint.position;
                    }
                }
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out DoorController doorController))
            {
                _lastCheckPoint = doorController.transform;
            }
        }
    }
}