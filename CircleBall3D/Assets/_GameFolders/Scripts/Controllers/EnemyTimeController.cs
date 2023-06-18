using System;
using System.Collections;
using CircleBall3D.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace CircleBall3D.Controllers
{
    public class EnemyTimeController : MonoBehaviour
    {
        [SerializeField] int _damage = 10000;
        [SerializeField] float _levelPlayMaxTime = 120f;
        [SerializeField] Image _fillerImage;

        float _currentTime = 0f;
        bool _isDone = false;
        PlayerController _playerController;

        //Start method'u normal bir void ile yazilablir ve ayni zamanda IEnumerator yani corutine olarakta yazilablir bir ozel method'tur bu sadece unity hazir methodlari arasinda Start icin gecerlidir
        IEnumerator Start()
        {
            _currentTime = _levelPlayMaxTime;
            //Race condition bir kodun baska bir koddan once calisip ve biz o kodu cagirdigimzda hata almamiz demektir ornek bizim burdaki planimiz once PlayerController'i sahne uzerinde bulucaz ki bulmak icin bu player'in sahne uzerinde yani bu scriptten once olusmasi gerekmektedir ama once bu script olursa ve bu scirpt henuz olusmamiz player'i arasa bulamicaktir ve burdaki player null kalicaktir biz burda player uzerinde bir islem yapmaya calistirimgizda hata alicaz bu hataya race condition denir.
            //FindObjectOfType tipten sahne uzerindeki butun nesnelere tek tek bakar ilk buldugu tipi doner bu yontem sayesinde surukle birak yapmayiz
            yield return new WaitForSeconds(2f);
            _playerController = FindObjectOfType<PlayerController>();
            Debug.Log(_playerController.name);
            Debug.Log("EnemyTimeController Start method'u bekledi ve calisti");
        }

        void OnEnable()
        {
            GameManager.Instance.OnLevelCompleted += HandleOnLevelCompleted;
        }

        void OnDisable()
        {
            GameManager.Instance.OnLevelCompleted -= HandleOnLevelCompleted;
        }

        void Update()
        {
            if (_isDone) return;
            
            _currentTime -= Time.deltaTime;
            _fillerImage.fillAmount = _currentTime / _levelPlayMaxTime;

            if (_currentTime <= 0f)
            {
                _playerController.TakeHit(_damage);
                _isDone = true;
                _fillerImage.fillAmount = 0f;
            }
        }
        
        void HandleOnLevelCompleted()
        {
            _isDone = true;
        }
    }
}

