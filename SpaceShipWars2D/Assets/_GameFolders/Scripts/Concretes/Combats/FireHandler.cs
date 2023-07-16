using SpaceShipWars2D.Abstracts.Combats;
using SpaceShipWars2D.Managers;
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
            var laserController = LaserPoolManager.Instance.GetLaserFromPool();
            laserController.SetLaserData(_attackStats.LaserStats);
            laserController.gameObject.layer = _attackStats.LaserStats.LayerIndex;
            laserController.Damage = _attackStats.MaxDamage;
            laserController.transform.position = _transform.position;
            laserController.gameObject.SetActive(true);
        }
    }

    public struct FireData
    {
        public Transform Transform { get; set; }
        public IAttackStats AttackStats { get; set; }
    }
}
