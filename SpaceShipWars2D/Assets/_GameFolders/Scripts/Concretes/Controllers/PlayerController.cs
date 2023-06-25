using System;
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
        [SerializeField] Sprite[] _spites;
        [SerializeField] SpriteRenderer _spriteRenderer;
        [SerializeField] PlayerStatsSO _playerStats;
        
        IMover _mover;
        IMovementBorder _movementBorder;
        IInputReader _inputReader;

        void OnValidate()
        {
            if (_spriteRenderer == null) _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        void Awake()
        {
            _inputReader = new InputReaderNormal();
            _mover = new MoveWithTranslate(this.transform);
            _movementBorder = new MovementBorderForTransform(this.transform);
        }

        void Update()
        {
            _mover.Tick(_playerStats.MoveSpeed * Time.deltaTime * _inputReader.Direction);
            _movementBorder.Tick();
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }

        void LateUpdate()
        {
            if (_inputReader.Direction.x < 0f)
            {
                _spriteRenderer.sprite = _spites[1];
            }
            else if (_inputReader.Direction.x > 0f)
            {
                _spriteRenderer.sprite = _spites[2];
            }
            else
            {
                _spriteRenderer.sprite = _spites[0];
            }
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