using Platformer2D.Controllers;
using UnityEngine;

namespace Platformer2D.Managers
{
    public class EnemyMoveManager : IMovementService
    {
        readonly EnemyController _enemyController;
        readonly Vector3[] _targetPositions;
        
        Vector3 _currentTargetPosition;
        Vector3 _currentDirection;
        int _targetIndex;
        
        public EnemyMoveManager(EnemyController enemyController)
        {
            _enemyController = enemyController;
            
            _targetPositions = new Vector3[_enemyController.TargetTransforms.Length];
            for (int i = 0; i < _enemyController.TargetTransforms.Length; i++)
            {
                _targetPositions[i] = _enemyController.TargetTransforms[i].position;
            }

            _targetIndex = Random.Range(0, _targetPositions.Length);
            _currentTargetPosition = _targetPositions[_targetIndex];
            _currentDirection = (_currentTargetPosition - _enemyController.ThisTransform.position).normalized;
        }

        public void Tick()
        {
            if (Vector2.Distance(_enemyController.ThisTransform.position, _currentTargetPosition) < 0.3f)
            {
                _targetIndex++;

                if (_targetIndex >= _targetPositions.Length)
                {
                    _targetIndex = 0;
                }

                _currentTargetPosition = _targetPositions[_targetIndex];
                _currentDirection = (_currentTargetPosition - _enemyController.ThisTransform.position).normalized;
            }
        }

        public void FixedTick()
        {
            _enemyController.ThisTransform.Translate(2f * Time.deltaTime * _currentDirection);
        }
        
        public void LateTick()
        {
            _enemyController.Flip.LateTick(_currentDirection.x);
        }
    }

    public interface IMovementService
    {
        void Tick();
        void FixedTick();
        void LateTick();
    }
}