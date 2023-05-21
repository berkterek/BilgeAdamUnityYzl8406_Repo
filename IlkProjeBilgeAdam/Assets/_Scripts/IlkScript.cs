using UnityEngine;

public class IlkScript : MonoBehaviour
{
    //Global Degisken veya field
    public int CurrentHealth = 200;
    public int SonicCoin = 1000; //++ => 1001 1002 1003 / direkt 0
    public int OrnekTamSayi; //tam sayi
    public float OrnekOndalikliSayi; //ondalikli sayimiz
    public GameObject OrnekGameObject; //GameObject kendisi
    public Vector2 Vector2; //2d 
    public Vector3 Vector3; //3d
    public string OrnekString;
    
    //field'lara bir deger atayabilirz ama islem yapamayiz field'lara islemleri method veya property icinde yapariz
    //SonicCoin = 100 + 200;

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
        OrnekString = "Ornek string bir global degisken veya field adi verilir ve global degiskenler bu class icinde her yerden erisleblirdir.";
        //Debug.Log unity uzerinde console uzerine yazdirmaya yarar.
        Debug.Log("Hello World!");

        //Local Degisken veya local variable
        string value = "Hello World Again!";
        char value1 = 'H';
        char value2 = 'e';

        //Debug.Log(10 + 10 + 1000);
        int sayi = 10 + 10 + 1000; //1020 => degerini sayi degiskeninn icine atamis oluyoruz
        //Debug.Log(sayi); // => 1020 yazdirmasini bekleriz

        Debug.Log(sayi + 2000); // sayi + 2000 yani sayi degiskeinin icinde 1020 degeri var yani 1020 + 2000 demis oluyoruz

        //Enemy => 10
        //Health => 100

        int currentHealth = 100; //ram uzerinde 32bit'lik yer kaplar 102
        int enemyDamage = 10; //ram uzerinde 32bit'lik yer kaplar

        //= burda atama operatorudur sagdaki degerleri sola atar
        currentHealth/*90*/ = currentHealth/*100*/ - enemyDamage/*10*/;

        Debug.Log(currentHealth);
        Debug.Log(OrnekTamSayi);
        Debug.Log(OrnekOndalikliSayi);
        Debug.Log(OrnekGameObject.name);
        Debug.Log(Vector2);
        Debug.Log(Vector3);
        Debug.Log(OrnekString);
    }

    void Method()
    {
        //value = "Hello Again";
        //int currentHealth = 200; //ram odasi 502
        OrnekString = "Global degisken";
    }

    [ContextMenu(nameof(LocalDegisken))]
    public void LocalDegisken()
    {
        int sayi = 0;
        sayi = sayi + 1;
        Debug.Log(sayi);
    }

    int sayi = 0;

    [ContextMenu(nameof(GlobalDegisken))]
    public void GlobalDegisken()
    {
        sayi = sayi + 1;
        Debug.Log(sayi);
    }

    public int Coin = 100;
    public int SellValue = 10;

    [ContextMenu(nameof(BuyItem))]
    public void BuyItem()
    {
        //Coin degeririnin dusmesini beklerim
        /*
         * 1.Coin degeri ve satin alinan fiyat birimin birbirinden cikarilmasi ve islem sonunu
         * 2.Yapilan islemin oyuncuya veya kullanici kisisine gosterilmesi
         */
        int result = Coin - SellValue;
        Debug.Log(result);
        Coin = result;
        Debug.Log(Coin);
    }

    //ContextMenu bir attribute'tur ve attribute'lar bizim methodlarimiza nitelik veya ozellik katmalaridir bu ContextMenu attribute bu methodlarin editor inspector uzerinde script'timize sag tikladigmiizda bu methodlari cagirmamizi saglar
    [ContextMenu(nameof(SellItem))]
    public void SellItem()
    {

    }

    [ContextMenu(nameof(SonicTakeDamage))]
    public void SonicTakeDamage()
    {
        SonicCoin = 0;
    }

    [ContextMenu(nameof(FromBPointToCPoint))]
    public void FromBPointToCPoint()
    {
        int damage = 50;
        CurrentHealth = CurrentHealth - damage;
        Debug.Log(CurrentHealth);
    }
}