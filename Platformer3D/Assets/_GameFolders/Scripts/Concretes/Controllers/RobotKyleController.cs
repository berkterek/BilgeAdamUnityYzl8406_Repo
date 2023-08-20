using Platformer3D.Abstracts.Movements;
using Platformer3D.Inputs;
using Platformer3D.Sample2.Combats;
using Platformer3D.Sample2.Movements;
using UnityEngine;

namespace Platformer3D.Sample2.Controllers
{
    public class RobotKyleController : MonoBehaviour
    {
        [SerializeField] LayerMask _LayerMask;
        [SerializeField] CharacterController _characterController;
        [SerializeField] Transform _verticalRotationTransform;
        
        IMover _mover;
        IAttack _attack;
        RotationMover _rotationMover;
        InputReader _inputReader;
        int _attackCounter;

        public Weapon Weapon { get; private set; }
        public InputReader InputReader => _inputReader;
        public LayerMask LayerMask => _LayerMask;
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
            _attack = new AttackWithSinglePress(this);
            Weapon = new Weapon();
        }

        void Update()
        {
            _mover.Tick(_inputReader.Direction);
            _rotationMover.Tick(_inputReader.RotationDirection);
            _attack.Tick();
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
            _rotationMover.FixedTick();
        }

        [ContextMenu(nameof(SwitchAttack))]
        public void SwitchAttack()
        {
            _attackCounter++;
            if (_attackCounter % 2 == 0)
            {
                _attack = new AttackWithSinglePress(this);
            }
            else
            {
                _attack = new AttackWithPressContinue(this);
            }
        }
    }

    public class Weapon
    {
        public float Damage { get; set; } = 10f;
    }
}
