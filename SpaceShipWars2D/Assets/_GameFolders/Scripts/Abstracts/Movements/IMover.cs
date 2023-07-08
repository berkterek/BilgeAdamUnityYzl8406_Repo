using UnityEngine;

namespace SpaceShipWars2D.Abstracts.Movements
{
    public interface IMover
    {
        void Tick(Vector2 direction);
        void FixedTick();
    }    
}

