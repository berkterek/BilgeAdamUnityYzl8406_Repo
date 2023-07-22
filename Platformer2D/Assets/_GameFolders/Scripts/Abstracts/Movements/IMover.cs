using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.Abstracts.Movements
{
    public interface IMover
    {
        void Tick(float value);
        void FixedTick();
    }    
}