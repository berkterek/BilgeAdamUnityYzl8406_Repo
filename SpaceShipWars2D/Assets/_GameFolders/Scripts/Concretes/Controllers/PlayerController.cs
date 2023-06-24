using SpaceShipWars2D.Abstracts.Movements;
using SpaceShipWars2D.Movements;
using UnityEngine;

namespace SpaceShipWars2D.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        /*
         *  ---------------------Odev---------------------
         *  1.Input burda alip _mover ile kullanmak sag sol asagi yukari islemleri
         *  2.InputReader icinde cevabi var ama once o tarafi kendimiz yazmayi deniyelim google arastirmasi hatta chatgpt bile olur isin icinden cikamazsaniz cevaba bakaiblirisniz
         * 
         *  --------------------Bonus---------------------
         *  3.MoveWithTranslate ile yurutme yaptik baska bir yurutme yontemi kullanalim bu yontem size kalmistir secmek ister rigidbody2d ister transform ama ikinci bir yurutme yontemi yazailm ve MoveWithTranslate yerine burda kullanalim ayni _mover ile yani IMover tipini degistirmeden kullanalim
         * 
         */
        
        IMover _mover;

        void Awake()
        {
            _mover = new MoveWithTranslate(this.transform);
        }

        void Update()
        {
            _mover.Tick(Time.deltaTime*Vector2.up);
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }
    }    
}