using UnityEngine;

namespace CircleBall3D.Movements
{
    public class TranslateMovement
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
}

