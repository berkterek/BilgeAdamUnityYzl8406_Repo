using CircleBall3D.Inputs;
using CircleBall3D.Movements;
using UnityEngine;

//namespace ile biz kodlarimizi daha duzgun duzenleyebilriz ayni UnityEngine namespace veya System gibi dosya yollarini bizde bu sekil belirtebillriz namespace'ler ile
namespace CircleBall3D.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 1f;

        InputReader _inputReader;
        TranslateMovement _translateMovement;

        void Awake()
        {
            _inputReader = new InputReader();
            _translateMovement = new TranslateMovement(transform);
        }

        void Update()
        {
            _translateMovement.Tick(Time.deltaTime*_moveSpeed*_inputReader.Direction);
        }

        void FixedUpdate()
        {
            _translateMovement.FixedTick();
        }
    }    
}

