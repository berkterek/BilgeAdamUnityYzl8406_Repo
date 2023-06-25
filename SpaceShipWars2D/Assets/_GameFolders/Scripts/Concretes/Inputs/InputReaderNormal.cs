using SpaceShipWars2D.Abstracts.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceShipWars2D.Inputs
{
    public class InputReaderNormal : IInputReader
    {
        public Vector2 Direction { get; private set; }

        public InputReaderNormal()
        {
            GameInputActions input = new GameInputActions();

            input.Player.Move.performed += HandleOnMovement;
            input.Player.Move.canceled += HandleOnMovement;
            
            //eger bu enable yapmazsak bu input kodlari calismaz
            input.Enable();
        }

        void HandleOnMovement(InputAction.CallbackContext context)
        {
            Direction = context.ReadValue<Vector2>();
        }
    }
}
