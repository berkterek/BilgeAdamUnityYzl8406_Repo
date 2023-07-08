using System;
using SpaceShipWars2D.Abstracts.Combats;
using SpaceShipWars2D.Abstracts.Movements;
using SpaceShipWars2D.Combats;
using SpaceShipWars2D.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWars2D.Controllers
{
    public class EnemyController : MonoBehaviour,IEntityController
    {
        [SerializeField] GameObject _fxObject;
        [SerializeField] GameObject _bodyObject;
        [SerializeField] GameObject _tailObject;
        [SerializeField] Collider2D _collider2D;
        [SerializeField] EnemyStatsSO _stats;
        
        IHealth _health;
        IFireHandler _fireHandler;
        IMover _mover;
        IDying _dying;

        void OnValidate()
        {
            if (_collider2D == null) _collider2D = GetComponent<Collider2D>();
        }

        void Awake()
        {
            _health = new Health(_stats);
            _fireHandler = new FireHandler(new FireData()
            {
                Transform = this.transform,
                AttackStats = _stats
            });
            _dying = new DyingWithFxEffect(new DyingDataEntity()
            {
                DyingStats = _stats,
                BodyObject = _bodyObject,
                TailObject = _tailObject,
                FxObject = _fxObject,
                Collider2D = _collider2D,
                MainGameObject = this.gameObject
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
            if (_dying.IsDead) return;

            _fireHandler.Tick();
        }

        void FixedUpdate()
        {
            if (_dying.IsDead) return;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out LaserController laserController)) return;
            
            _health.TakeDamage(laserController.Damage);
        }

        void HandleOnDead()
        {
            StartCoroutine(_dying.DyingProcessAsync());
        }
    }
}

