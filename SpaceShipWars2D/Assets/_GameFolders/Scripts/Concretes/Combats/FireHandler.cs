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

        public FireHandler(FireData data)
        {
            _transform = data.Transform;
            _attackStats = data.AttackStats;
        }
    
        public void Tick()
        {
            _currentRate += Time.deltaTime;

            if (_currentRate > _attackStats.FireRate)
            {
                Fire();
                _currentRate = 0f;
            }
        }
    
        void Fire()
        {
            //Instantiate bizim prefab'lerimizi runtime veya editor ama daha cok tercih edilen runtime'dir prefab nesnelerimizi olusturmamizi saglayan method'tur
            GameObject.Instantiate(_attackStats.LaserPrefab, _transform.position, Quaternion.identity);
        }
    }

    public struct FireData
    {
        public Transform Transform { get; set; }
        public IAttackStats AttackStats { get; set; }
    }
}
