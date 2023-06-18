using CircleBall3D.Inputs;
using CircleBall3D.Managers;
using CircleBall3D.Movements;
using UnityEngine;
using UnityEngine.UI;

//namespace ile biz kodlarimizi daha duzgun duzenleyebilriz ayni UnityEngine namespace veya System gibi dosya yollarini bizde bu sekil belirtebillriz namespace'ler ile
namespace CircleBall3D.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Image _healthBarImage;
        [SerializeField] int _maxHealth = 100;
        [SerializeField] float _moveSpeed = 1f;

        InputReader _inputReader;
        IMovement _mover;
        bool _canMove = true;
        float _currentHealth;

        void Awake()
        {
            _inputReader = new InputReader();
            _mover = new RigidbodyAddForceMovement(transform);
        }

        void Start()
        {
            _currentHealth = _maxHealth;
        }

        void OnEnable()
        {
            GameManager.Instance.OnLevelCompleted += HandleOnLevelCompleted;
        }

        void OnDisable()
        {
            GameManager.Instance.OnLevelCompleted -= HandleOnLevelCompleted;
        }

        void Update()
        {
            if (!_canMove) return;
            
            _mover.Tick(Time.deltaTime * _moveSpeed * _inputReader.Direction);
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }

        public void TakeHit(int damage)
        {
            _currentHealth -= damage;
            _healthBarImage.fillAmount = _currentHealth / _maxHealth;
        }
        
        void HandleOnLevelCompleted()
        {
            _canMove = false;
        }

        #region Interface Ornek

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

        #endregion
    }
}