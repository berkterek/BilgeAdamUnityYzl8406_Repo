using UnityEngine;

public class StaticEnemyVisualController : MonoBehaviour
{
    public float _speed = 1f;
    public SpriteRenderer[] _spriteRenderers;

    void Update()
    {
        foreach (SpriteRenderer spriteRenderer in _spriteRenderers)
        {
            spriteRenderer.size += _speed * Time.deltaTime * Vector2.right;
        }
    }
}