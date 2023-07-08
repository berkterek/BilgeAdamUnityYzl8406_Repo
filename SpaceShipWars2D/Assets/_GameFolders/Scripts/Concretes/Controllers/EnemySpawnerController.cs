using UnityEngine;

namespace SpaceShipWars2D.Controllers
{
    public class EnemySpawnerController : MonoBehaviour
    {
        [SerializeField] EnemyController _prefab;
        [SerializeField] Transform _startPosition;
        [SerializeField] Transform[] _targets;
        [SerializeField] float _minSpawnRate = 1f;
        [SerializeField] float _maxSpawnRate = 4f;

        float _currentSpawnRate = 0f;
        float _currentMaxSpawnRate = 0f;

        void Start()
        {
            GetRandomTime();
        }

        void Update()
        {
            _currentSpawnRate += Time.deltaTime;

            if (_currentSpawnRate > _currentMaxSpawnRate)
            {
                _currentSpawnRate = 0f;
                GetRandomTime();
                Spawn();
            }
        }

        void Spawn()
        {
            var enemy =Instantiate(_prefab, _startPosition.position, _startPosition.rotation);
            enemy.SetTargets(_targets);
        }

        private void GetRandomTime()
        {
            _currentMaxSpawnRate = Random.Range(_minSpawnRate, _maxSpawnRate);
        }
    }    
}

