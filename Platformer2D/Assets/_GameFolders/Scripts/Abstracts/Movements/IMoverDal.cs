using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.Abstracts.Movements
{
    //Data Access Layer
    //buranin gorevi saf data tutmak burda if else yapisi olmaz
    public interface IMoverDal
    {
        void FixedTick(Vector3 direction);
    }    
}