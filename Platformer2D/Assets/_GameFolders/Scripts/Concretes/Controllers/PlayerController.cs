using Platformer2D.Inputs;
using UnityEngine;

namespace Platformer2D.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Transform _transform;

        InputReader _inputReader;

        void OnValidate()
        {
            if (_transform == null) _transform = transform;
        }

        void Awake()
        {
            _inputReader = new InputReader();
        }

        void Update()
        {
            Debug.Log(_inputReader.HorizontalInput);

            //new Vector3(1f,0f,0f);
            _transform.Translate(Time.deltaTime * _inputReader.HorizontalInput * Vector3.right);
        }
    }
}