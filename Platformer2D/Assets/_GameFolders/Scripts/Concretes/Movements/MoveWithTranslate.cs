using Platformer2D.Abstracts.Movements;
using UnityEngine;

namespace Platformer2D.Movements
{
    public class MoveWithTranslate : IMover
    {
        readonly Transform _transform;
        float _horizontal;

        public MoveWithTranslate(Transform transform)
        {
            _transform = transform;
        }

        public void Tick(float value)
        {
            _horizontal = value;
        }

        public void FixedTick()
        {
            _transform.Translate(2f * _horizontal * Time.deltaTime * Vector3.right);
        }
    }
}