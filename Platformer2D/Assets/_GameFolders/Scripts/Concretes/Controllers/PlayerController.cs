using System;
using Platformer2D.Inputs;
using UnityEngine;

namespace Platformer2D.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        //Input => Horizontal input
        //Movement => Left Right
        InputReader _inputReader;

        void Awake()
        {
            _inputReader = new InputReader();
        }

        void Update()
        {
            Debug.Log(_inputReader.HorizontalInput);
        }
    }
}