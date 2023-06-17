using CircleBall3D.Movements;
using UnityEngine;
using UnityEngine.AI;

namespace CircleBall3D.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] Transform _target;
        [SerializeField] Animator _animator;
        [SerializeField] float _stopDistance = 2f;
        [SerializeField] float _moveSpeed = 5f;

        IMovement _mover;

        void Awake()
        {
            _mover = new NavmeshAgentMovement(new NavmeshAgentMovementData()
            {
                Animator = _animator,
                Transform = this.transform,
                StopDistance = _stopDistance,
                MoveSpeed = _moveSpeed
            });
        }

        void Update()
        {
            if (_target == null) return;

            _mover.Tick(_target.position);
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }
    }

    public struct NavmeshAgentMovementData
    {
        public Transform Transform { get; set; }
        public float StopDistance { get; set; }
        public Animator Animator { get; set; }
        public float MoveSpeed { get; set; }
    }
}