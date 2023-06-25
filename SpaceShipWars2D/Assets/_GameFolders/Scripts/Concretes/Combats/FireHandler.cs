using SpaceShipWars2D.Controllers;
using SpaceShipWars2D.ScriptableObjects;
using UnityEngine;

public class FireHandler
{
    readonly Transform _transform;
    readonly LaserController _laserPrefab;
    readonly IAttackStats _attackStats;
    
    float _currentRate = 0f;

    public FireHandler()
    {
        
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
        GameObject.Instantiate(_laserPrefab, _transform.position, Quaternion.identity);
    }
}