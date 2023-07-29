using UnityEngine;

namespace Platformer2D.Movements
{
    public class JumpWithRigidbody : IJump
    {
        readonly Rigidbody2D _rigidbody2D;

        public JumpWithRigidbody(Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
        }
        
        public void FixedTick(float jumpForce)
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Time.deltaTime * jumpForce * Vector2.up);
        }
    }

    public interface IJump
    {
        void FixedTick(float jumpForce);
    }
}