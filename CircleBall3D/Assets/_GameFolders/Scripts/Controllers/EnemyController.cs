using System.Collections;
using CircleBall3D.Managers;
using CircleBall3D.Movements;
using CircleBall3D.ScriptableObjects;
using UnityEngine;

namespace CircleBall3D.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] EnemyStatsSO _enemyStats;
        [SerializeField] Transform _target;
        [SerializeField] Animator _animator;

        IMovement _mover;
        Coroutine _attackCoroutine;
        public PlayerController PlayerController { get; private set; }
        public EnemyStatsSO Stats => _enemyStats;

        void Awake()
        {
            _mover = new NavmeshAgentMovement(new NavmeshAgentMovementData()
            {
                Animator = _animator,
                Transform = this.transform,
                Stats = _enemyStats
            });
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
            if (_target == null) return;

            _mover.Tick(_target.position);
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }
        
        //Enter Exit bir kere calisir 
        //Enter on trigger girdiginde calisir
        //Exit ciktiginda calir
        //Stay devamli calir
        void OnTriggerEnter(Collider other)
        {
            //bu yazimin daha performansli ve temiz bir yontemi vardir
            // var enemy = other.GetComponent<EnemyController>();
            // if (enemy != null)
            // {
            //     Debug.Log("Enemy hit me!!!");
            // }

            //yukaridaki yazimin aynisidir try get component method enemy controller var mi diye bakar varsa true doner if calisir yoksa false doner if calismaz
            if (other.TryGetComponent(out PlayerController playerController))
            {
                Debug.Log("Enemy can hit player");
                // _attackCoroutine = StartCoroutine(HitAsync(playerController));
                PlayerController = playerController;
                _animator.SetBool("IsAttacking",true);
            }
        }

        //OnTriggerEnter icinde biz bir Coroutine calisitriyoruz ve bu coroutine attack islemini baslatiyor sonsuz bir dongu icinde sonsuz dongumuz bir asenkron bir islem oldugudan dolaiy unity kitlemez ve kendi kendine calisir burda yield return new waitforsecond ile bir attack rate olusturmus olduk yani dusman enemy stats icinden gelen attack rate kadar bekler ve bekledikten sonra vurma islemini yaparlar demis olduk OnTriggger exit ile bu islemi durdurmus olduk 
        
        void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerController playerController))
            {
                Debug.Log("Enemy can not hit player");
                // if (_attackCoroutine != null)
                // {
                //     StopCoroutine(_attackCoroutine);    
                // }
                
                _animator.SetBool("IsAttacking",false);
            }
        }
        
        private IEnumerator HitAsync(PlayerController playerController)
        {
            while (true)
            {
                //yield return null Update mantigiyla ayni 1 frame bekle demektir
                yield return new WaitForSeconds(_enemyStats.RandomAttackRate);
                playerController.Health.TakeHit(_enemyStats.Damage);
            }
        }
        
        void HandleOnLevelCompleted()
        {
            Destroy(this.gameObject);
        }

        #region Coroutine Senktron Asenkron

        //Coroutine'ler asenkron islemlerdir bizim simdiye kadar kullandimigz butun methodlar senktorndur yani bir islem bir yapi bitmeden digeri calismaz ama asenktorn islemler ise diger yapilardan ayri kendi basina calis isi bitince biter diger yapilar bitmis veya bitmemis baslamis veya baslamamis onemli degildir

        void Method1()
        {
            //islem
        }

        void Method2()
        {
            //islem
        }

        void Method3()
        {
            //islem
        }

        void Main()
        {
            Method1();
            StartCoroutine(MethodAsync());
            Method2();
            Method3();
        }

        //Asenkron yapilar burda kod calisirken disarida yani main method'unda kod calismaaya akmaya devam eder burda kod beklese bile Main methodu normal calismaya devam eder MethodAsync ise diye method1 2 veya 3 bitmis veya bitmemis o kisimla ilgilenmez
        public IEnumerator MethodAsync()
        {
            //islem
            yield return null;
        }

        #endregion
    }

    public struct NavmeshAgentMovementData
    {
        public Transform Transform { get; set; }
        public Animator Animator { get; set; }
        public EnemyStatsSO Stats { get; set; }
    }
}