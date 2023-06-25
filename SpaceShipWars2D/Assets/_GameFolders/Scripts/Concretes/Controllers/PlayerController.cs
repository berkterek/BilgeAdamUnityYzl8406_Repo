using SpaceShipWars2D.Abstracts.Inputs;
using SpaceShipWars2D.Abstracts.Movements;
using SpaceShipWars2D.Inputs;
using SpaceShipWars2D.Movements;
using UnityEngine;

namespace SpaceShipWars2D.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _moveSpeed = 5f;
        
        IMover _mover;
        IMovementBorder _movementBorder;
        IInputReader _inputReader;

        void Awake()
        {
            _inputReader = new InputReaderNormal();
            _mover = new MoveWithTranslate(this.transform);
            _movementBorder = new MovementBorderForTransform(this.transform);
        }

        void Update()
        {
            _mover.Tick(_moveSpeed * Time.deltaTime * _inputReader.Direction);
            _movementBorder.Tick();
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
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