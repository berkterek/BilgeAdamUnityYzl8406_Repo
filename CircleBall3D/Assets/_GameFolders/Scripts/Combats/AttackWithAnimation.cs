using CircleBall3D.Controllers;
using UnityEngine;

namespace CircleBall3D.Combats
{
    public class AttackWithAnimation : MonoBehaviour
    {
        [SerializeField] EnemyController _enemyController;

        //Attack method'u animasyon event'i ile calisir
        //Animation event ise Attack animsyonuna cift tikladiginizda cizgi halinde gorursunuz 
        public void Attack()
        {
            _enemyController.PlayerController.Health.TakeHit(_enemyController.Stats.Damage);
        }
    }    
}

