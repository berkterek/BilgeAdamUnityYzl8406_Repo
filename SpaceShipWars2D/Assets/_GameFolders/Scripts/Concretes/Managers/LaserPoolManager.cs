using System.Collections;
using System.Collections.Generic;
using SpaceShipWars2D.Abstracts.Patterns;
using SpaceShipWars2D.Controllers;
using UnityEngine;

namespace SpaceShipWars2D.Managers
{
    public class LaserPoolManager : SingletonMonoObject<LaserPoolManager>
    {
        [SerializeField] int _poolSize = 50;
        [SerializeField] LaserController _prefab;
        
        //Queue listten farki list karmasik icinde cekelblir veya sira ile alabililriz queue ise ilk giren ilk cikar mantigi vardir ve hep bir sira ile nesneleri tek tek ceker veya icine ekleriz
        Queue<LaserController> _laserPool;

        protected override void Awake()
        {
            base.Awake();
            _laserPool = new Queue<LaserController>();
        }

        IEnumerator Start()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                var laser = Instantiate(_prefab, this.transform);
                laser.gameObject.SetActive(false);
                _laserPool.Enqueue(laser);
                yield return null;
            }
        }

        public LaserController GetLaserFromPool()
        {
            return _laserPool.Dequeue();
        }

        public void SetLaserToPool(LaserController laserController)
        {
            laserController.gameObject.SetActive(false);
            _laserPool.Enqueue(laserController);
        }
    }   
}