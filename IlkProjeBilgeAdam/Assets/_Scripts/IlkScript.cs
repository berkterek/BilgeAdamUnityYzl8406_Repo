using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlkScript : MonoBehaviour
{
    public int OrnekTamSayi;
    public float OrnekOndalikliSayi;
    public GameObject OrnekGameObject;

    //Bu bir yorum satiridir
    //Bu bir method'tur iconu mor kuptur
    /*
     *
     * coklu
     * yorum
     * satiri
     *
     */
    void Start()
    {
        //Debug.Log unity uzerinde console uzerine yazdirmaya yarar.
        Debug.Log("Hello World!");

        //Debug.Log(10 + 10 + 1000);
        int sayi = 10 + 10 + 1000; //1020 => degerini sayi degiskeninn icine atamis oluyoruz
        //Debug.Log(sayi); // => 1020 yazdirmasini bekleriz

        Debug.Log(sayi + 2000); // sayi + 2000 yani sayi degiskeinin icinde 1020 degeri var yani 1020 + 2000 demis oluyoruz

        //Enemy => 10
        //Health => 100

        int currentHealth = 100; //ram uzerinde 32bit'lik yer kaplar
        int enemyDamage = 10; //ram uzerinde 32bit'lik yer kaplar

        //= burda atama operatorudur sagdaki degerleri sola atar
        currentHealth/*90*/ = currentHealth/*100*/ - enemyDamage/*10*/;

        Debug.Log(currentHealth);
    }
}