using Platformer3D.Abstracts.Movements;
using Platformer3D.Movements;
using UnityEngine;

namespace Platformer3D.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 5f;
        [SerializeField] CharacterController _characterController;

        IMover _mover;

        public float MoveSpeed => _moveSpeed;

        void Awake()
        {
            _mover = new CharacterControllerMove(new MoveInjectionData()
            {
                PlayerController = this,
                CharacterController = _characterController
            });
        }

        void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical);

            _mover.Tick(direction);
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }
    }
}