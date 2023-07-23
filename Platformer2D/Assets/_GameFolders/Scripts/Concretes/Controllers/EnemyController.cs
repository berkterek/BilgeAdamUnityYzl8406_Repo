using Platformer2D.Abstracts.Movements;
using Platformer2D.Movements;
using UnityEngine;

namespace Platformer2D.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] Transform _thisTrasform;
        [SerializeField] Transform[] _targetTransforms;
        [SerializeField] Vector3[] _targetPositions;
        [SerializeField] Vector3 _currentTargetPosition;
        [SerializeField] Vector3 _currentDirection;
        [SerializeField] SpriteRenderer _spriteRenderer;

        IFlip _flip;
        int _targetIndex;
        float _timer = 0f;


        void OnValidate()
        {
            if (_spriteRenderer == null) _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            if (_thisTrasform == null) _thisTrasform = transform;
        }

        void Awake()
        {
            _flip = new FlipWithSpriteRenderer(_spriteRenderer);
        }

        void Start()
        {
            _targetPositions = new Vector3[_targetTransforms.Length];
            for (int i = 0; i < _targetTransforms.Length; i++)
            {
                _targetPositions[i] = _targetTransforms[i].position;
            }

            _targetIndex = Random.Range(0, _targetPositions.Length);
            _currentTargetPosition = _targetPositions[_targetIndex];
            _currentDirection = (_currentTargetPosition - _thisTrasform.position).normalized;
        }

        void Update()
        {
            _timer += Time.deltaTime;

            if (Vector2.Distance(_thisTrasform.position, _currentTargetPosition) < 0.3f)
            {
                _timer = 0f;
                _targetIndex++;

                if (_targetIndex >= _targetPositions.Length)
                {
                    _targetIndex = 0;
                }

                _currentTargetPosition = _targetPositions[_targetIndex];
                _currentDirection = (_currentTargetPosition - _thisTrasform.position).normalized;
            }

            _thisTrasform.Translate(2f * Time.deltaTime * _currentDirection);
        }

        void LateUpdate()
        {
            _flip.LateTick(_currentDirection.x);
        }
    }
}