using Platformer2D.Abstracts.Movements;
using Platformer2D.Inputs;
using Platformer2D.Movements;
using UnityEngine;

namespace Platformer2D.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _jumpForce = 500f;
        [SerializeField] Transform _transform;
        [SerializeField] Rigidbody2D _rigidbody2D;

        InputReader _inputReader;
        IMover _mover;
        bool _isJump = false;

        void OnValidate()
        {
            if (_transform == null) _transform = transform;
            if (_rigidbody2D == null) _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        void Awake()
        {
            _inputReader = new InputReader();
            _mover = new MoveWithTranslate(_transform);
        }

        void Update()
        {
            _mover.Tick(_inputReader.HorizontalInput);

            if (_inputReader.IsJumpButtonDown)
            {
                _isJump = true;
            }
            //_isJump = _inputReader.IsJumpButtonDown;
        }

        void FixedUpdate()
        {
            _mover.FixedTick();

            if (_isJump)
            {
                _rigidbody2D.velocity = Vector2.zero;
                _rigidbody2D.AddForce(Time.deltaTime * _jumpForce * Vector2.up);
                _isJump = false;
            }
        }
    }
}