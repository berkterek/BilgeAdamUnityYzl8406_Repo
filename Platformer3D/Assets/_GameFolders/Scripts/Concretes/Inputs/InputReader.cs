using UnityEngine.InputSystem;
using UnityEngine;

namespace Platformer3D.Inputs
{
    public class InputReader
    {
        readonly GameInputActions _input;

        public Vector3 Direction { get; private set; }
        public Vector2 RotationDirection { get; private set; }
        public bool CanFireSinglePress => _input.Player.Fire.WasPressedThisFrame();
        public bool CanFireContinue { get; private set; }

        //Constructor
        public InputReader()
        {
            _input = new GameInputActions();

            _input.Player.Move.performed += HandleOnPlayerMove;
            _input.Player.Move.canceled += HandleOnPlayerMove;

            _input.Player.Look.performed += HandleOnPlayerLook;
            _input.Player.Look.canceled += HandleOnPlayerLook;

            _input.Player.FireContinue.performed += HandleOnFireContinue;
            _input.Player.FireContinue.canceled += HandleOnFireContinue;

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
        
        void HandleOnFireContinue(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                CanFireContinue = true;    
            }
            else
            {
                CanFireContinue = false;
            }
        }
    }
}