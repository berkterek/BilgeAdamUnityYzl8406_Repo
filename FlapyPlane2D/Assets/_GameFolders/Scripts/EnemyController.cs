using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float _maxLifeTime = 15f;
    public float _moveSpeed = 5f;

    float _currentTime = 0f;

    void Update()
    {
        transform.position += Time.deltaTime * _moveSpeed * Vector3.left;
    }

    void LateUpdate()
    {
        _currentTime += Time.deltaTime;
        
        if(_currentTime > _maxLifeTime)
        {
            Destroy(this.gameObject);
        }
    }
}
