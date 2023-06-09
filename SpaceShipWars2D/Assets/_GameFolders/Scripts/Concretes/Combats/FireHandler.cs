using SpaceShipWars2D.Abstracts.Combats;
using SpaceShipWars2D.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWars2D.Combats
{
    public class FireHandler : IFireHandler
    {
        readonly Transform _transform;
        readonly IAttackStats _attackStats;
    
        float _currentRate = 0f;
        float _currentMaxRate = 0f;

        public FireHandler(FireData data)
        {
            _transform = data.Transform;
            _attackStats = data.AttackStats;
            _currentMaxRate = _attackStats.FireRate;
        }
    
        public void Tick()
        {
            _currentRate += Time.deltaTime;

            if (_currentRate > _currentMaxRate)
            {
                Fire();
                _currentRate = 0f;
                _currentMaxRate = _attackStats.FireRate;
            }
        }
    
        void Fire()
        {
            //Instantiate bizim prefab'lerimizi runtime veya editor ama daha cok tercih edilen runtime'dir prefab nesnelerimizi olusturmamizi saglayan method'tur
            var laserController = GameObject.Instantiate(_attackStats.LaserPrefab, _transform.position, Quaternion.identity);
            laserController.Damage = _attackStats.MaxDamage;
        }
    }

    public struct FireData
    {
        public Transform Transform { get; set; }
        public IAttackStats AttackStats { get; set; }
    }
}
