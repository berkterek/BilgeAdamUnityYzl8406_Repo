using System;
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

        IMover _mover;
        Vector2 _direction;

        void OnValidate()
        {
            if (_transform == null) _transform = transform;
        }

        void Awake()
        {
            _mover = new MoveWithTransform(_transform);
        }

        void Update()
        {
            _mover.Tick(_stats.MoveSpeed * Time.deltaTime * _stats.OneWayDirection);
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }
    }
}