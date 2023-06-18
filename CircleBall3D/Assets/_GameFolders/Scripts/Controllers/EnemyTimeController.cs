using System.Collections;
using UnityEngine;

namespace CircleBall3D.Controllers
{
    public class EnemyTimeController : MonoBehaviour
    {
        [SerializeField] int _damage = 10000;
        [SerializeField] float _levelPlayMaxTime = 120f;

        float _currentTime = 0f;
        bool _isAttackCompleted = false;
        PlayerController _playerController;

        //Start method'u normal bir void ile yazilablir ve ayni zamanda IEnumerator yani corutine olarakta yazilablir bir ozel method'tur bu sadece unity hazir methodlari arasinda Start icin gecerlidir
        IEnumerator Start()
        {
            //Race condition bir kodun baska bir koddan once calisip ve biz o kodu cagirdigimzda hata almamiz demektir ornek bizim burdaki planimiz once PlayerController'i sahne uzerinde bulucaz ki bulmak icin bu player'in sahne uzerinde yani bu scriptten once olusmasi gerekmektedir ama once bu script olursa ve bu scirpt henuz olusmamiz player'i arasa bulamicaktir ve burdaki player null kalicaktir biz burda player uzerinde bir islem yapmaya calistirimgizda hata alicaz bu hataya race condition denir.
            //FindObjectOfType tipten sahne uzerindeki butun nesnelere tek tek bakar ilk buldugu tipi doner bu yontem sayesinde surukle birak yapmayiz
            yield return new WaitForSeconds(2f);
            _playerController = FindObjectOfType<PlayerController>();
            Debug.Log(_playerController.name);
            Debug.Log("EnemyTimeController Start method'u bekledi ve calisti");
        }

        void Update()
        {
            if (_isAttackCompleted) return;
            
            _currentTime += Time.deltaTime;

            if (_currentTime >= _levelPlayMaxTime)
            {
                _playerController.TakeHit(_damage);
                _isAttackCompleted = true;
            }
        }
    }
}

