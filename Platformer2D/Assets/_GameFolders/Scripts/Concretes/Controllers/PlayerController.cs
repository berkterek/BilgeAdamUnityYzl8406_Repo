using Platformer2D.Abstracts.Movements;
using Platformer2D.Inputs;
using Platformer2D.Movements;
using UnityEngine;

namespace Platformer2D.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Transform _transform;

        InputReader _inputReader;
        IMover _mover;

        void OnValidate()
        {
            if (_transform == null) _transform = transform;
        }

        void Awake()
        {
            _inputReader = new InputReader();
            _mover = new MoveWithTranslate(_transform);
        }

        void Update()
        {
            _mover.Tick(_inputReader.HorizontalInput);

            Debug.Log(_inputReader.IsJumpButtonDown);
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }
    }
}