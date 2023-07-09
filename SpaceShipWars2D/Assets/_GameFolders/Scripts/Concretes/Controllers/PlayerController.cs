using SpaceShipWars2D.Abstracts.Combats;
using SpaceShipWars2D.Abstracts.Inputs;
using SpaceShipWars2D.Abstracts.Movements;
using SpaceShipWars2D.Combats;
using SpaceShipWars2D.Inputs;
using SpaceShipWars2D.Managers;
using SpaceShipWars2D.Movements;
using SpaceShipWars2D.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWars2D.Controllers
{
    public class PlayerController : MonoBehaviour,IEntityController
    {
        [SerializeField] Sprite[] _sprites;
        [SerializeField] Animator _animator;
        [SerializeField] GameObject _tailObject;
        [SerializeField] SpriteRenderer _spriteRenderer;
        [SerializeField] PlayerDataContainerSO _playerDataContainer;

        IMover _mover;
        IMovementBorder _movementBorder;
        IInputReader _inputReader;
        IAnimationController _animation;
        IFireHandler _fireHandler;
        IHealth _health;
        IDying _dying;
        
        void OnValidate()
        {
            if (_spriteRenderer == null) _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            if (_animator == null) _animator = GetComponentInChildren<Animator>();
        }

        void Awake()
        {
            _inputReader = new InputReaderNormal();
            _health = new Health(_playerDataContainer.PlayerStats);
            _dying = new DyingWithAnimation(new DyingDataEntity()
            {
                Animator = _animator,
                DyingStats = _playerDataContainer.PlayerStats,
                TailObject = _tailObject,
                MainGameObject = this.gameObject
            });
            _mover = new MoveWithTranslate(new MovementData()
            {
                Transform = this.transform,
                MovementStats = _playerDataContainer.PlayerStats
            });
            _movementBorder = new MovementBorderForTransform(this.transform);
            _animation = new PlayerAnimationWithSprite(new PlayerAnimationWithSpriteData()
            {
                Sprites = _sprites,
                SpriteRenderer = _spriteRenderer
            });
            _fireHandler = new FireHandler(new FireData()
            {
                Transform = this.transform,
                AttackStats = _playerDataContainer.PlayerStats
            });
        }

        void OnEnable()
        {
            _health.OnDead += HandleOnDead;
            _health.OnDamageTaken += HandleOnDamageTaken;
        }

        void OnDisable()
        {
            _health.OnDead -= HandleOnDead;
            _health.OnDamageTaken -= HandleOnDamageTaken;
        }

        void Update()
        {
            if (_dying.IsDead) return;
            
            _mover.Tick(_inputReader.Direction);
            _movementBorder.Tick();
            _animation.Tick(_inputReader.Direction.x);
            _fireHandler.Tick();
        }

        void FixedUpdate()
        {
            if (_dying.IsDead) return;
            
            _mover.FixedTick();
        }

        void LateUpdate()
        {
            if (_dying.IsDead) return;
            
            _animation.LateTick();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out LaserController laserController)) return;
            
            _health.TakeDamage(laserController.Damage);
        }
        
        void HandleOnDead()
        {
            GameManager.Instance.GameOver();
            StartCoroutine(_dying.DyingProcessAsync());
        }
        
        void HandleOnDamageTaken(int currentHealth)
        {
            _playerDataContainer.PlayerStats.HealthValueChange(currentHealth);
        }
    }

    public interface IEntityController
    {
        Transform transform { get; }
    }
}