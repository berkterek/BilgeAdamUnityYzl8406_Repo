using System;
using System.Collections;
using System.Collections.Generic;
using SpaceShipWars2D.Abstracts.Movements;
using SpaceShipWars2D.Movements;
using UnityEngine;

namespace SpaceShipWars2D.Controllers
{
    public class LaserController : MonoBehaviour
    {
        [SerializeField] bool _isGoingUp;
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

        void Start()
        {
            if (_isGoingUp)
            {
                _direction = Vector2.up;
            }
            else
            {
                _direction = Vector2.down;
            }
        }

        void Update()
        {
            _mover.Tick(1f * Time.deltaTime * _direction);
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }
    }
}