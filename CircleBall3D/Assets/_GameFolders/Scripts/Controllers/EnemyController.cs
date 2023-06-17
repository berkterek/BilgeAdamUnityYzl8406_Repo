using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace CircleBall3D.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] Transform _target;
        [SerializeField] float _maxStopDistance = 1f;
        [SerializeField] NavMeshAgent _navMeshAgent;

        void Update()
        {
            if (_target == null) return;
            
            if (_navMeshAgent.remainingDistance < _maxStopDistance)
            {
                _navMeshAgent.isStopped = true;
            }
            else
            {
                _navMeshAgent.isStopped = false;
            }
            
            _navMeshAgent.SetDestination(_target.position);
        }
    }
}