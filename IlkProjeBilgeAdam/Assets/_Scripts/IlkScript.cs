using UnityEngine;

public class IlkScript : MonoBehaviour
{
    //Global Degisken veya field
    public int CurrentHealth = 200;
    public int SonicCoin = 1000; //++ => 1001 1002 1003 / direkt 0 //default 100
    public int OrnekTamSayi; //tam sayi
    public float OrnekOndalikliSayi; //ondalikli sayimiz
    public GameObject OrnekGameObject; //GameObject kendisi
    public Vector2 Vector2; //2d 
    public Vector3 Vector3; //3d
    public string OrnekString;
    public GameObject BosGecilebilir1;
    public string BosGecilebilir2;
    public int BosGecilemeyen1;
    public float BosGecilemeyen2;
    public Vector2 BosGecilemeyen3;
    public Vector3 BosGecilemeyen4;

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
        //value icine Hello World Again! string degerini atadim.
        string value = "Hello World Again!"; 
        Debug.Log(value); //value icindeki degeri Debug.Log icinde yazdirdim 
        value = value + " " + "Hello Again and Again"; //value degerini maniple ettim ve birseyler ekledim => "Hello World Again! Hello Again and Again"
        Debug.Log(value); //ayni value degerini debug.Log icinde yazdirdim
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
    public int BuyValue = 10;

    [ContextMenu(nameof(BuyItem))]
    public void BuyItem()
    {
        //Coin degeririnin dusmesini beklerim
        /*
         * 1.Coin degeri ve satin alinan fiyat birimin birbirinden cikarilmasi ve islem sonunu
         * 2.Yapilan islemin oyuncuya veya kullanici kisisine gosterilmesi
         */

        int result = Coin - BuyValue;

        //eger result degeri 0'dan buyuk veya esit ise satin alma islemini yap
        //eger result degeri 0'dan kucukse
        //if eger anlamindadir c#(csharp) icinde sart anlami katar ornegin sonuc 0'dan buyukse veya sonuc 0'a esit ise gibi sartlari kontrol ettiririz
        //result > 0 => result'in degeri 0'dan buyukse
        //result < 0 => result'in degeri 0'dan kucukse
        //result >= 0 => result'in degeri 0'dan buyukse veya 0'a esitse
        //result <= 0 => result'in degeri 0'dan kucukse veya 0'a esitse
        //result == 0 => result'in degeri 0'a esit mi? tek esittir "=" atama operatorudur // cift esittir "==" bir sart operatorudur yani esit mi diye soran operatordur
        if (result >= 0)
        {
            //Debug.Log(result);
            Coin = result;
            //int => 10
            //string = "10"
            string stringResult = Coin.ToString(); //tipten tipi direkt atamlar yapamayiz burda oldugu gibi int tipli bir deger string'e veya string bir degiskene atmak istersek onu convert etmeliyiz
            //ToString() method'u int olan degeri string'e convert etmis oldu ve bunun bu string'e donen int degeri artik matematiksel hic bir degeri yoktur
            string message = "Satis islemi gerceklesti " + stringResult;
            Debug.Log(message);
        }
        else // else tap tap yazarsaniz kendi otomatik yazicaktir scope'lariyla beraber
        {
            //if else if fark etmez else yapisi yukaridaki sartlardan biri calismaz ise else sarti herzmaan calir
            //result 0'dan buyuk veya esit degilse 0'dan kucuktur yani satir islemi para veya coin degeri yetmedigi icin gerceklestirilemez
            //Debug.Log(Coin);
            Debug.Log("Oyuncu parasi veya coin yeterli degildir");
        }
    }

    //ContextMenu bir attribute'tur ve attribute'lar bizim methodlarimiza nitelik veya ozellik katmalaridir bu ContextMenu attribute bu methodlarin editor inspector uzerinde script'timize sag tikladigmiizda bu methodlari cagirmamizi saglar
    [ContextMenu(nameof(SellItem))]
    public void SellItem()
    {
        //Coin = Coin + SellValue;
        Coin += SellValue; // Coint = Coin + SellValue; / + - * /
        //Coin++; Coin += 1 / Coin = Coin + 1
        //Coin--; Coin -= 1 / Coin = Coin - 1
        Debug.Log(Coin);
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

    [ContextMenu(nameof(IfElseOrnek))]
    public void IfElseOrnek()
    {
        //Random.Range method bize rasgele sayi urutmemizi saglar
        int randomNumber = Random.Range(0, 100);

        //if - else
        //if - else if ... - else
        //if
        //if - else if ...
        if (randomNumber < 50)
        {
            //birinci string combine yontemi 
            //randomNumber veya randomNumber.ToString() yazilablir eger ToString yazmazsaniz bile c# bunu kendi otomatik yapicaktir
            Debug.Log("Random Sayi 50'den kucuktur " + randomNumber.ToString());
        }
        else if (randomNumber > 50)
        {
            //$ dolar isareti ile string combine edeiblirz iki yontemde ayni mantikta calisir hic bir farki yoktur
            Debug.Log($"Random Sayi 50'den buyuktur {randomNumber}");
        }
        else if (false)
        {

        }
        else if (false)
        {

        }
        else
        {
            Debug.Log("Random Sayi 50'e esittir");
        }
    }
}