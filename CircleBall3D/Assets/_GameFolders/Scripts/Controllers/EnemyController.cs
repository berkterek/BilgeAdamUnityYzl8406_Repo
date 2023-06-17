using CircleBall3D.Movements;
using UnityEngine;
using UnityEngine.AI;

namespace CircleBall3D.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] EnemyStatsSO _enemyStats;
        [SerializeField] Transform _target;
        [SerializeField] Animator _animator;

        IMovement _mover;

        void Awake()
        {
            _mover = new NavmeshAgentMovement(new NavmeshAgentMovementData()
            {
                Animator = _animator,
                Transform = this.transform,
                Stats = _enemyStats
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
        public Animator Animator { get; set; }
        public EnemyStatsSO Stats { get; set; }
    }
}