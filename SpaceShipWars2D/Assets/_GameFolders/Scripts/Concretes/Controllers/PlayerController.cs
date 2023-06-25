using SpaceShipWars2D.Abstracts.Inputs;
using SpaceShipWars2D.Abstracts.Movements;
using SpaceShipWars2D.Inputs;
using SpaceShipWars2D.Movements;
using SpaceShipWars2D.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWars2D.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] LaserController _laserPrefab;
        [SerializeField] Sprite[] _sprites;
        [SerializeField] SpriteRenderer _spriteRenderer;
        [SerializeField] PlayerStatsSO _playerStats;

        IMover _mover;
        IMovementBorder _movementBorder;
        IInputReader _inputReader;
        IAnimationController _animation;

        float _currentRate = 0f;

        void OnValidate()
        {
            if (_spriteRenderer == null) _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        void Awake()
        {
            _inputReader = new InputReaderNormal();
            _mover = new MoveWithTranslate(this.transform);
            _movementBorder = new MovementBorderForTransform(this.transform);
            _animation = new PlayerAnimationWithSprite(new PlayerAnimationWithSpriteData()
            {
                Sprites = _sprites,
                SpriteRenderer = _spriteRenderer
            });
        }

        void Update()
        {
            _mover.Tick(_playerStats.MoveSpeed * Time.deltaTime * _inputReader.Direction);
            _movementBorder.Tick();
            _animation.Tick(_inputReader.Direction.x);

            _currentRate += Time.deltaTime;

            if (_currentRate > _playerStats.FireRate)
            {
                Fire();
                _currentRate = 0f;
            }
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }

        void LateUpdate()
        {
            _animation.LateTick();
        }

        void Fire()
        {
            //Instantiate bizim prefab'lerimizi runtime veya editor ama daha cok tercih edilen runtime'dir prefab nesnelerimizi olusturmamizi saglayan method'tur
            Instantiate(_laserPrefab, transform.position, Quaternion.identity);
        }
    }
}

/*
        *  ---------------------Odev---------------------
        *  1.Input burda alip _mover ile kullanmak sag sol asagi yukari islemleri
        *  2.InputReader icinde cevabi var ama once o tarafi kendimiz yazmayi deniyelim google arastirmasi hatta chatgpt bile olur isin icinden cikamazsaniz cevaba bakaiblirisniz
        * 
        *  --------------------Bonus---------------------
        *  3.MoveWithTranslate ile yurutme yaptik baska bir yurutme yontemi kullanalim bu yontem size kalmistir secmek ister rigidbody2d ister transform ama ikinci bir yurutme yontemi yazailm ve MoveWithTranslate yerine burda kullanalim ayni _mover ile yani IMover tipini degistirmeden kullanalim
        * 
        */