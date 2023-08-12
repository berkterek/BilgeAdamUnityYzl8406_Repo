using UnityEngine;

namespace Platformer3D.Abstracts.Movements
{
    public interface IMover
    {
        void Tick(Vector3 direction);
        void FixedTick();
    }
}