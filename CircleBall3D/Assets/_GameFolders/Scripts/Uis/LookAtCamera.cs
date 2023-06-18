using System;
using UnityEngine;

namespace CircleBall3D.Uis
{
    public class LookAtCamera : MonoBehaviour
    {
        [SerializeField] Transform _transform;

        Transform _lookTarget;

        void Awake()
        {
            _lookTarget = Camera.main.transform;
        }

        void OnValidate()
        {
            if (_transform == null)
            {
                _transform = transform;
            }
        }

        void Update()
        {
            _transform.LookAt(_lookTarget);
            Vector3 currentAngle = _transform.eulerAngles;
            _transform.eulerAngles = new Vector3(currentAngle.x, 0f, 0f) * -1f;
        }
    }    
}

