using Platformer2D.Abstracts.Movements;
using UnityEngine;

namespace Platformer2D.Movements
{
    public class FlipWithSpriteRenderer : IFlip
    {
        readonly SpriteRenderer _spriteRenderer;
        
        public FlipWithSpriteRenderer(SpriteRenderer spriteRenderer)
        {
            _spriteRenderer = spriteRenderer;
        }
        
        public void LateTick(float value)
        {
            if (value > 0f)
            {
                _spriteRenderer.flipX = false;
            }
            else if (value < 0f)
            {
                _spriteRenderer.flipX = true;
            }
        }
    }

    public class FlipWithScale : IFlip
    {
        readonly Transform _transform;
        
        public FlipWithScale(Transform transform)
        {
            _transform = transform;
        }
        
        public void LateTick(float value)
        {
            if (value == 0f) return;
            
            _transform.localScale = new Vector3(value, 1f, 1f);
        }
    }
}