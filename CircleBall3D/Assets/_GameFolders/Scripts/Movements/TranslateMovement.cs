using CircleBall3D.Controllers;
using UnityEngine;
using UnityEngine.AI;

namespace CircleBall3D.Movements
{
    public class TranslateMovement : IMovement
    {
        //readonly referansi bir kere atanicak bu atama islemi sadece constructor uzerinde olucak ve bir daha degismicek demektir bunun boyle yazilmasi normal yazilmasindan daha performanslidir
        readonly Transform _transform;
        float _moveSpeed = 5f;

        Vector3 _direction;

        //bu class olusma aninda bir transform ister kimin oldugu onemli degildir
        public TranslateMovement(Transform transform)
        {
            _transform = transform;
        }

        //Update method'u icinde calsicagini temsil eder
        public void Tick(Vector3 direction)
        {
            _direction = direction;
        }

        //FixedUpdate method'u icinde calisicagini temsil eder
        public void FixedTick()
        {
            _transform.Translate(_direction);
        }
    }

    public class RigidbodyAddForceMovement : IMovement
    {
        readonly Rigidbody _rigidbody;

        Vector3 _direction;

        public RigidbodyAddForceMovement(Transform transform)
        {
            _rigidbody = transform.GetComponent<Rigidbody>();
        }

        public void Tick(Vector3 direction)
        {
            _direction = direction;
        }

        public void FixedTick()
        {
            _rigidbody.AddForce(_direction);

            const float maxVelocityMagnitude = 10f;
            if (_rigidbody.velocity.magnitude > maxVelocityMagnitude)
            {
                _rigidbody.velocity = _rigidbody.velocity.normalized * maxVelocityMagnitude;
            }
        }
    }

    public class NavmeshAgentMovement : IMovement
    {
        readonly NavMeshAgent _navMeshAgent;
        readonly Animator _animator;
        readonly EnemyStatsSO _stats;

        Vector3 _direction;
        
        public NavmeshAgentMovement(NavmeshAgentMovementData data)
        {
            _navMeshAgent = data.Transform.GetComponent<NavMeshAgent>();
            _stats = data.Stats;
            _animator = data.Animator;
        }
        
        public void Tick(Vector3 direction)
        {
            SetSpeeds();
            
            _direction = direction;

            if (_navMeshAgent.remainingDistance < _stats.StopDistance)
            {
                _navMeshAgent.isStopped = true;
            }
            else
            {
                _navMeshAgent.isStopped = false;
            }
            
            //Enemy Animator icindeki MoveLocomotion MoveVelocity paramtresine navmesh agent icinden gelen movement hizi ve max hizi bolup 0 ile 1 arasinda bir deger aldik ve bu degeri MoveVelocity paramtresine gonderdik bu yapi cunku 0 ile 1 degerini alir bunu yaptigmizda yurume ile animasyon senkron bir sekilde calismis oldu 
            _animator.SetFloat("MoveVelocity",Mathf.Clamp01(_navMeshAgent.velocity.magnitude / _navMeshAgent.speed));
        }

        public void FixedTick()
        {
            _navMeshAgent.SetDestination(_direction);
        }

        private void SetSpeeds()
        {
            if (_stats.MoveSpeed.Equals(_navMeshAgent.speed) &&
                _stats.AngularSpeed.Equals(_navMeshAgent.angularSpeed)) return;
            
            _navMeshAgent.speed = _stats.MoveSpeed;
            _navMeshAgent.angularSpeed = _stats.AngularSpeed;
        }
    }

    //IMovement bir interface'tir interface'ler soyut yapilardir ve biz interface yardimyla bu ornekte movement yapisi daha moduler hale getirmis olduk runtime da bile degitirilebilen bir hala esneklige getirmis olduk,
    //interface calisma mantigi sudur kendisi verdigimiz method veya property'leri bir kontrat olarak gorur ve miras alan siniflara bu yapilari verir ve bu yapilarin olmais garanti oldugundan dolayi IMovevemnt degiskeni kimi tuttugnu bilmez sadece IMovemnt interface'dne miras aldigin bilmesi onun icin yeterlidir bu yuzden interface yapilari cok esnek ve kuvvetli yapilardir
    public interface IMovement
    {
        void Tick(Vector3 direction);
        void FixedTick();
    }
}