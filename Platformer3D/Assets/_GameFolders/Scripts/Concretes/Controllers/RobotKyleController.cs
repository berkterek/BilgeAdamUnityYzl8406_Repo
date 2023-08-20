using Platformer3D.Abstracts.Movements;
using Platformer3D.Inputs;
using Platformer3D.Sample2.Movements;
using UnityEngine;

namespace Platformer3D.Sample2.Controllers
{
    public class RobotKyleController : MonoBehaviour
    {
        [SerializeField] CharacterController _characterController;
        [SerializeField] Transform _verticalRotationTransform;
        
        IMover _mover;
        RotationMover _rotationMover;
        InputReader _inputReader;

        public Transform VerticalRotationTransform => _verticalRotationTransform;

        void OnValidate()
        {
            if (_characterController == null) _characterController = GetComponent<CharacterController>();
        }

        void Awake()
        {
            _inputReader = new InputReader();
            _mover = new CharacterControllerMover(this);
            _rotationMover = new RotationMover(this);
        }

        void Update()
        {
            _mover.Tick(_inputReader.Direction);
            _rotationMover.Tick(_inputReader.RotationDirection);
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
            _rotationMover.FixedTick();
        }
    }    
}
