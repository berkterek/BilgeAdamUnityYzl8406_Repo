using System;
using Platformer2D.Abstracts.Managers;
using Platformer2D.Abstracts.Movements;
using Platformer2D.Managers;
using Platformer2D.Movements;
using UnityEngine;

namespace Platformer2D.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] Transform _thisTrasform;
        [SerializeField] Transform[] _targetTransforms;
        [SerializeField] SpriteRenderer _spriteRenderer;
        [SerializeField] int _maxHealth;
        [SerializeField] int _currentHealth;

        IMovementService _movementManager;
        
        public IFlip Flip { get; private set; }

        public Transform ThisTransform => _thisTrasform;
        public Transform[] TargetTransforms => _targetTransforms;

        void OnValidate()
        {
            if (_spriteRenderer == null) _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            if (_thisTrasform == null) _thisTrasform = transform;
        }

        void Awake()
        {
            _movementManager = new EnemyMoveManager(this);
            Flip = new FlipWithSpriteRenderer(_spriteRenderer);
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