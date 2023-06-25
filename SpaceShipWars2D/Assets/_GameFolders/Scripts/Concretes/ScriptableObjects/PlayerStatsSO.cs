using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipWars2D.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Player Stats", menuName = "Bilge Adam/Stats/Player Stats")]
    public class PlayerStatsSO : ScriptableObject
    {
        [Tooltip("This movement speed is players movement speed")]
        [SerializeField, Range(1f,10f)] float _moveSpeed = 5f;
        [SerializeField, Range(0.1f, 2f)] float _fireRate = 0.5f;

        public float MoveSpeed => _moveSpeed;
        public float FireRate => _fireRate;
    }    
}

