using SpaceShipWars2D.Abstracts.Movements;
using UnityEngine;

namespace SpaceShipWars2D.Movements
{
    public class PlayerAnimationWithSprite : IAnimationController
    {
        readonly SpriteRenderer _spriteRenderer;
        readonly Sprite[] _sprites;

        float _xDirection = 0f;
        
        public PlayerAnimationWithSprite(PlayerAnimationWithSpriteData data)
        {
            _spriteRenderer = data.SpriteRenderer;
            _sprites = data.Sprites;
        }

        public void Tick(float xDirection)
        {
            _xDirection = xDirection;
        }

        public void LateTick()
        {
            if (_xDirection < 0f)
            {
                _spriteRenderer.sprite = _sprites[1];
            }
            else if (_xDirection > 0f)
            {
                _spriteRenderer.sprite = _sprites[2];
            }
            else
            {
                _spriteRenderer.sprite = _sprites[0];
            }
        }
    }

    public struct PlayerAnimationWithSpriteData
    {
        public SpriteRenderer SpriteRenderer { get; set; }
        public Sprite[] Sprites { get; set; }
    }
}