using UnityEngine;

//SO scriptable object oldugnu temsil eder
//scriptable object'ler en temel kullanimi bir data holder data container olmalaridir bu yapilarin tek amaci datayi bir alandan dagitmaktir Enemy orneginde move speed ve stop distance her bir enemy icin tekrar tekrar olusur ama scirptable object'ten bu bilgileri cekerlerse bu bilgler olusmaz bir kaynaktan cekmis olurlar bunun pattern olarak adi fly weight pattern diye gecer
//Scriptable object olusturma kurali Mono'dan degil ScriptableObject class'dan miras alir
//Mono'dan farki burda kullanilan methodlar Awake, OnEnable, OnDisable ve OnDestory methodlari kullanilir
//Mono class'lar bir game object uzerine attach'lenir sciprable object'ler runtime icinde olusturablirler ama en yaygin kullanimi editor uzerinde bir dosya gibi olusturmaktir cunku scriptable object'ler bir asset'tir yani bir dosya turudur.
//CreateAssetMenu attribute ile biz bu sciptable object'leri editor uzerinde olusturmayi saglariz
//fileName biz bir yeni bir scriptable object olsuturdugmuzda bu dosyanin olusma adidir.
//menuName ise bizim scriptable object'leri nasil oluturcagimizin dosya yoludur
//burda biz dosya tarafina sag tikladimizda en ustte Create goruruz ve Create icinde en tepede Bilge Adam Akademi secenegini gormus olucaz ve o bizi stats yonlendircek stats icinde de Enemy Stats yazisini gorucez tikladigmizda New Enemy Stats olusturmus olucaz
namespace CircleBall3D.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Enemy Stats",menuName = "Bilge Adam Akademi/Stats/Enemy Stats")]
    public class EnemyStatsSO : ScriptableObject
    {
        [SerializeField] int _damage = 10;
        [SerializeField] float _minAttackRate = 1.5f;
        [SerializeField] float _maxAttackRate = 3f;
        [SerializeField] float _stopDistance = 2f;
        [SerializeField] float _moveSpeed = 5f;
        [SerializeField] float _angularSpeed = 120f;

        public float MoveSpeed => _moveSpeed;
        public float AngularSpeed => _angularSpeed;
        public float StopDistance => _stopDistance;
        public int Damage => _damage;
        public float RandomAttackRate => Random.Range(_minAttackRate, _maxAttackRate);
    }    
}