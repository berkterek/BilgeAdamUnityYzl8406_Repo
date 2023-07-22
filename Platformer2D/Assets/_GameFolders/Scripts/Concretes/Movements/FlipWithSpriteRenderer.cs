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
        
        public void LateUpdate(float value)
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
}