using System.Collections;
using CircleBall3D.Controllers;
using UnityEngine;

namespace CircleBall3D.Combats
{
    public class AttackWithAnimation : MonoBehaviour
    {
        [SerializeField] EnemyController _enemyController;
        [SerializeField] GameObject _particleFx;
        [SerializeField] AudioSource _audioSource;

        //Attack method'u animasyon event'i ile calisir
        //Animation event ise Attack animsyonuna cift tikladiginizda cizgi halinde gorursunuz 
        public void Attack()
        {
            StartCoroutine(PlayFxAsync());
            _enemyController.PlayerController.Health.TakeHit(_enemyController.Stats.Damage);
            _audioSource.Play();
        }

        private IEnumerator PlayFxAsync()
        {
            _particleFx.gameObject.SetActive(true);

            yield return new WaitForSeconds(0.5f);
            
            _particleFx.gameObject.SetActive(false);
        }
    }    
}

