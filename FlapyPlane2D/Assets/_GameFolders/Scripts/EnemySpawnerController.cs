using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    public EnemyController Prefab;
    public float _maxSpawnTime = 5f;

    float _currentTime = 0f;

    void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _maxSpawnTime)
        {
            //Instantiate method bizden bir prefab ister ve bu prefab'in bu method clone'unu olusturur
            //clone olusturmak 0'dan olusturmaktan daha performanslidir bu yuzden prefab uzerinden clone yaratiriz
            //bizim kullandigmiz method ikinci paramtre olarak pozisyon ister
            //bizim kullandiigmiz yontem ucuncu parametre olarak rotation ister burdaki quaternion.identity ise bize Vector3.zero ile ayni isi yapar yani 0,0,0,0 sonucunu verir
            Instantiate(Prefab, transform.position, Quaternion.identity);
            _currentTime = 0f;
        }
    }
}
