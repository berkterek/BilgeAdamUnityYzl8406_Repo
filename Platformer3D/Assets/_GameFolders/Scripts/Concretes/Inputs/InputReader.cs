using UnityEngine.InputSystem;
using UnityEngine;

namespace Platformer3D.Inputs
{
    public class InputReader
    {
        readonly GameInputActions _input;

        public Vector3 Direction { get; set; }
        public Vector2 RotationDirection { get; set; }

        //Constructor
        public InputReader()
        {
            _input = new GameInputActions();

            _input.Player.Move.performed += HandleOnPlayerMove;
            _input.Player.Move.canceled += HandleOnPlayerMove;

            _input.Player.Look.performed += HandleOnPlayerLook;
            _input.Player.Look.canceled += HandleOnPlayerLook;
            
            _input.Enable();
        }

        //Destructor
        ~InputReader()
        {
           _input.Disable(); 
        }
        
        void HandleOnPlayerMove(InputAction.CallbackContext context)
        {
            var vector2Direction = context.ReadValue<Vector2>();
            Direction = new Vector3(vector2Direction.x, 0f, vector2Direction.y);
        }
        
        void HandleOnPlayerLook(InputAction.CallbackContext context)
        {
            RotationDirection = context.ReadValue<Vector2>();
        }
    }
}