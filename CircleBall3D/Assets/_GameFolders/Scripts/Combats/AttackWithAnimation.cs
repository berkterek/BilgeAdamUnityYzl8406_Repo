using CircleBall3D.Controllers;
using UnityEngine;

public class AttackWithAnimation : MonoBehaviour
{
    [SerializeField] EnemyController _enemyController;

    //Attack method'u animasyon event'i ile calisir
    //Animation event ise Attack animsyonuna cift tikladiginizda cizgi halinde gorursunuz 
    public void Attack()
    {
        _enemyController.PlayerController.TakeHit(_enemyController.Stats.Damage);
    }
}
