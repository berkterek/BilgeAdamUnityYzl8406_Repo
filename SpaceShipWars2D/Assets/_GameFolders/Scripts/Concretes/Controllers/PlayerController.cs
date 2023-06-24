using SpaceShipWars2D.Abstracts.Movements;
using SpaceShipWars2D.Movements;
using UnityEngine;

namespace SpaceShipWars2D.Controllers
{
    public class PlayerController : MonoBehaviour
    {
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