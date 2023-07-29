using Platformer2D.Abstracts.Managers;
using Platformer2D.Abstracts.Movements;
using Platformer2D.Combats;
using Platformer2D.Managers;
using Platformer2D.Movements;
using UnityEngine;
using UnityEngine.Serialization;

namespace Platformer2D.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] Transform _thisTrasform;
        [SerializeField] Transform[] _targetTransforms;
        [SerializeField] SpriteRenderer _spriteRenderer;
        [SerializeField] int _maxHealth;
        [SerializeField] int _currentHealth;
        [SerializeField] int damageValue = 1;

        IMovementService _movementManager;
        ITakeAndDealDamageCombatService _combatService;
        
        public IFlip Flip { get; private set; }
        public Transform ThisTransform => _thisTrasform;
        public Transform[] TargetTransforms => _targetTransforms;
        public int DamageValue => damageValue;
        public int MaxHealth => _maxHealth;
        public IHealthService HealthManager => _combatService;
        public IAttackService AttackManager => _combatService;


        void OnValidate()
        {
            if (_spriteRenderer == null) _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            if (_thisTrasform == null) _thisTrasform = transform;
        }

        void Awake()
        {
            _movementManager = new EnemyMoveManager(this);
            Flip = new FlipWithSpriteRenderer(_spriteRenderer);
            _combatService = new EnemyCombatManager(this);
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
            _movementManager.LateTick();
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}