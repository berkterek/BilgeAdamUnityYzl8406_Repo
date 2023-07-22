using UnityEngine.InputSystem;

namespace Platformer2D.Inputs
{
    public class InputReader
    {
        readonly GameInputActions _input;

        public float HorizontalInput { get; private set; }
        public bool IsJumpButtonDown => _input.Player.Jump.WasPressedThisFrame();
        
        public InputReader()
        {
            _input = new GameInputActions();
            _input.Player.Move.performed += HandleOnMovement;
            _input.Player.Move.canceled += HandleOnMovement;
            
            _input.Enable();
        }

        void HandleOnMovement(InputAction.CallbackContext context)
        {
            HorizontalInput = context.ReadValue<float>();
        }
    }    
}

