using Platformer2D.Abstracts.Movements;
using UnityEngine;

namespace Platformer2D.Movements
{
    public class MoveWithTranslate : IMover
    {
        readonly Transform _transform;

        public MoveWithTranslate(Transform transform)
        {
            _transform = transform;
        }

        public void FixedTick(Vector3 direction)
        {
            _transform.Translate(direction);
        }
    }
}