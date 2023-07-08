using System.Collections;
using SpaceShipWars2D.Abstracts.Combats;
using SpaceShipWars2D.Abstracts.Inputs;
using SpaceShipWars2D.Abstracts.Movements;
using SpaceShipWars2D.Combats;
using SpaceShipWars2D.Inputs;
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
        [SerializeField] PlayerStatsSO _playerStats;

        IMover _mover;
        IMovementBorder _movementBorder;
        IInputReader _inputReader;
        IAnimationController _animation;
        IFireHandler _fireHandler;
        IHealth _health;

        bool _isDead = false;

        void OnValidate()
        {
            if (_spriteRenderer == null) _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            if (_animator == null) _animator = GetComponentInChildren<Animator>();
        }

        void Awake()
        {
            _inputReader = new InputReaderNormal();
            _health = new Health(_playerStats);
            _mover = new MoveWithTranslate(new MovementData()
            {
                Transform = this.transform,
                MovementStats = _playerStats
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
                AttackStats = _playerStats
            });
        }

        void OnEnable()
        {
            _health.OnDead += HandleOnDead;
        }

        void OnDisable()
        {
            _health.OnDead -= HandleOnDead;
        }

        void Update()
        {
            if (_isDead) return;
            
            _mover.Tick(_inputReader.Direction);
            _movementBorder.Tick();
            _animation.Tick(_inputReader.Direction.x);
            _fireHandler.Tick();
        }

        void FixedUpdate()
        {
            if (_isDead) return;
            
            _mover.FixedTick();
        }

        void LateUpdate()
        {
            if (_isDead) return;
            
            _animation.LateTick();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out LaserController laserController)) return;
            
            _health.TakeDamage(laserController.Damage);
        }
        
        void HandleOnDead()
        {
            StartCoroutine(DyingAsync());
        }

        private IEnumerator DyingAsync()
        {
            _isDead = true;
            _animator.SetTrigger("Dying");
            _tailObject.SetActive(false);
            _mover.Tick(Vector2.zero);
            yield return new WaitForSeconds(1.4f);
            Destroy(this.gameObject);
        }
    }

    public interface IEntityController
    {
        Transform transform { get; }
    }
}