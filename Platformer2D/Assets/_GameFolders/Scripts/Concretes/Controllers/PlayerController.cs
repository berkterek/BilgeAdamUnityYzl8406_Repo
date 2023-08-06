using Platformer2D.Abstracts.Managers;
using Platformer2D.Abstracts.Movements;
using Platformer2D.Inputs;
using Platformer2D.Managers;
using Platformer2D.Movements;
using Platformer2D.ScriptableObjects;
using UnityEngine;

namespace Platformer2D.Controllers
{
    //User interface Layer
    //Kullanici kisiinin iletiisimde bulunup business tarafini calistiridigi alandir
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] PlayerDataContainer _playerDataContainer;
        [SerializeField] int _maxJumpCounter = 2;
        [SerializeField] float _jumpForce = 500f;
        [SerializeField] Transform _transform;
        [SerializeField] Rigidbody2D _rigidbody2D;
        [SerializeField] Animator _animator;
        [SerializeField] SpriteRenderer _spriteRenderer;
        [SerializeField] int _maxHealth = 3;
        [SerializeField] int _damageValue = 1;
        [SerializeField] Transform _lastCheckPoint;
        [SerializeField] InventoryController _inventoryController;

        IAnimation _animation;
        IPlayerMoveService _movementManager;
        ITakeAndDealDamageCombatService _combatManager;

        public InputReader InputReader { get; private set; }
        public IFlip Flip { get; private set; }
        public int MaxJumpCounter => _maxJumpCounter;
        public float JumpForce => _jumpForce;
        public int MaxHealth => _maxHealth;
        public int DamageValueValue => _damageValue;
        public IPlayerMoveService MovementManager => _movementManager;
        public Transform LastCheckPoint => _lastCheckPoint;
        public InventoryController Inventory => _inventoryController;
        public PlayerDataContainer PlayerDataContainer => _playerDataContainer;

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
            _combatManager = new PlayerCombatManager(this);
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
                    _combatManager.GiveDamageProcess(enemyController.HealthManager);
                }
            }
            else //Take Damage
            {
                if (contact.collider.TryGetComponent(out EnemyController enemyController))
                {
                    _combatManager.TakeDamageProcess(enemyController.AttackManager.Damage);
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