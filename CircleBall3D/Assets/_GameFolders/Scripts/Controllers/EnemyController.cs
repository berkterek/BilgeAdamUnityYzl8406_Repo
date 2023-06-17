using CircleBall3D.Movements;
using UnityEngine;
using UnityEngine.AI;

namespace CircleBall3D.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] Transform _target;

        IMovement _mover;

        void Awake()
        {
            _mover = new NavmeshAgentMovement(transform);
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
}