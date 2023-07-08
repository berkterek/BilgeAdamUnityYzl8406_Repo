using System.Collections;
using SpaceShipWars2D.Abstracts.Movements;
using SpaceShipWars2D.Movements;
using SpaceShipWars2D.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWars2D.Controllers
{
    public class LaserController : MonoBehaviour
    {
        [SerializeField] LaserStatsSO _stats;
        [SerializeField] Transform _transform;
        [SerializeField] SpriteRenderer _bodySpriteRenderer;

        IMover _mover;
        Vector2 _direction;
        bool _isDead = false;

        void OnValidate()
        {
            if (_transform == null) _transform = transform;
            if (_bodySpriteRenderer == null) _bodySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        void Awake()
        {
            _mover = new MoveWithTransform(new MovementData()
            {
                Transform = _transform,
                MovementStats = _stats
            });
        }

        void Start()
        {
            _isDead = false;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IEntityController entityController)) return;

            StartCoroutine(DyingAsync());
        }

        void Update()
        {
            if (_isDead) return;
            
            _mover.Tick(_stats.OneWayDirection);
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }

        private IEnumerator DyingAsync()
        {
            _isDead = true;
            _mover.Tick(Vector2.zero);
            _bodySpriteRenderer.sprite = _stats.DyingSprite;
            _bodySpriteRenderer.sortingOrder = 10;
            yield return new WaitForSeconds(_stats.DelayTime);
            Destroy(this.gameObject);
        }
    }
}