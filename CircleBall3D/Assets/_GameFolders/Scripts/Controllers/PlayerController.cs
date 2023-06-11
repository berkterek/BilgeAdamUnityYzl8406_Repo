using CircleBall3D.Inputs;
using CircleBall3D.Movements;
using UnityEngine;

//namespace ile biz kodlarimizi daha duzgun duzenleyebilriz ayni UnityEngine namespace veya System gibi dosya yollarini bizde bu sekil belirtebillriz namespace'ler ile
namespace CircleBall3D.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] int _playerScore = 0;
        [SerializeField] float _moveSpeed = 1f;

        InputReader _inputReader;
        IMovement _mover;

        void Awake()
        {
            _inputReader = new InputReader();
            _mover = new RigidbodyAddForceMovement(transform);
        }

        void Update()
        {
            _mover.Tick(Time.deltaTime * _moveSpeed * _inputReader.Direction);
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }

        int _index = 0;

        [ContextMenu(nameof(ChangeMovement))]
        public void ChangeMovement()
        {
            _index++;

            if (_index % 2 == 0)
            {
                _mover = new TranslateMovement(transform);
                Debug.Log(nameof(TranslateMovement));
            }
            else
            {
                _mover = new RigidbodyAddForceMovement(transform);
                Debug.Log(nameof(RigidbodyAddForceMovement));
            }
        }

        public void IncreaseScore(int score)
        {
            _playerScore += score;
        }
    }
}