using UnityEngine;
using UnityEngine.InputSystem;

namespace CircleBall3D.Inputs
{
    public class InputReader 
    {
        public Vector3 Direction { get; private set; }
        
        //constructor yapici method demektir yapici methodlar bir class veya struct olusurken ilk calisan method'tur.
        public InputReader()
        {
            GameInputActions input = new GameInputActions();

            input.Player.Move.started += HandleOnMovement;
            input.Player.Move.performed += HandleOnMovement;
            input.Player.Move.canceled += HandleOnMovement;
            
            input.Enable();
        }

        void HandleOnMovement(InputAction.CallbackContext context)
        {
            var inputValue = context.ReadValue<Vector2>();
            Direction = new Vector3(inputValue.x, 0f, inputValue.y);
        }
    }    
}

