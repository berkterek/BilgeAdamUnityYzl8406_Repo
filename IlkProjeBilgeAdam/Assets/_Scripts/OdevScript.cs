using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OdevScript : MonoBehaviour
{
    //1.1 Sayi1 Sayi2 veya Number1 Number2 adinda iki tane field olsun bu field'lari runtime uzerinde inspector'dan degistirebilelim
    //1.2 4 tane method yazalim toplama cikarma carpma ve bolme islemi yapan burda sonuc her method calistiginda sayi1 ve sayi2 degeinin isleminin sonucunu Debug.Log() icinde ornegin toplama icin "Sayi1={Sayi1'in degeri} + Sayi2={Sayi2'in degeri} = {Sonucun degeri}" bu sekil yazdirmasini yapailm

    //2.1 Random.Range bir sayi olusturalim 0 ile 500 arasinda olsun
    //2.2 bu sayinin 250'den kucuk veya buyuk olup olmadina bakalim ve bunu console(debug.log) icinde yazdiralim ornek "Random Sayi 250'dne kucuktur => {RandomSayiDegeri}" gibi
    //2.3(bonus) 250'den kucuk ama 150'den buyuk ise console uzerinde yazdiralim 250'den buyuk ama 450'den kucuk seklinde yazdiralim

    public int Sayi1;
    public int Sayi2;
    public float Sayi3 = 5.1f;

    [ContextMenu(nameof(Topla))]
    public void Topla()
    {
        int sonuc = Sayi1 + Sayi2;
        Debug.Log($"Sayi1={Sayi1} + Sayi2={Sayi2} = {sonuc}");
        print("Sayi1=" + Sayi1 + " + Sayi2=" + Sayi2 + " = " + sonuc);
        //print(string.Format("Sayi1={0} Sayi2={1} = {2}", Sayi1, Sayi2, sonuc));
    }

    public void Cikar()
    {

    }

    public void Carp()
    {

    }

    public void Bol()
    {
        string value = string.Empty;
    }

    [ContextMenu(nameof(SartYapisi))]
    public void SartYapisi()
    {
        var resultRandomNumber = Random.Range(0, 500);

        if (resultRandomNumber < 250)
        {
            print("Random sayi 250'den kucuktur");

            if(resultRandomNumber > 150)
            {
                print("Random sayi 250'dne kucuktur ama 150'den buyuktur");
            }
        }
        else
        {
            print("Random sayi 250'den buyuk veya esittir");

            if (resultRandomNumber < 450)
            {
                print("Random sayi 250'den buyuk ama 450'den kucuktur");
            }
        }
    }

    [ContextMenu(nameof(VeriTipleri))]
    public void VeriTipleri()
    {
        //veri tiplerinde deger tip olarak unity uzerinde int float bool kullaniriz

        //int degiskenine biz string veri deger atayamayiz hata verir
        //int sayi1 = 10;//"sayi1";

        //burda da ayni yukaridaki gibi string bir degiskene int bir deger atayamyiz
        //burda ise int olan degeri ToString ile convert edip oyle string degiskenine deegrini atar
        //string deger1 = sayi1.ToString(); 

        //burdaki 10 sadece yazi karakteridir matematiksel bir degeri yoktur
        string value = "10";

        //bunlar deger tiplidir
        int number = Convert.ToInt32(value);
        //bool value1 = false;
        bool value2 = true;
        float value3 = 5.5f; //burda sayi yanina f ile yazariz bunun float oldugnu belirtiriz

        //ram uzerinde => int101 = 10
        int number1 = 10;

        //ram uzerinde => int102 = 10
        int number2 = number1;
        //number2 = 10
        //number1 = 10

        //ram int101 = 10 + 5 => 15
        number1 += 5; //number1 = 15
        //number2 = 10

        print("Number 1 => " + number1); //15
        print("Number 2 => " + number2); //10

        //referans tiplere ornek object class(string) dizi(array)


        //dizi oldugundan dolayi referans tiplidir referans tpilerin farki deger tiplerde oldugu gibi degeri degil referansi tasini yani ram kaynmak adresi tasinir

        //ram 501 => "Nur, Nil, Berk"
        //                     index        0       1       2
        string[] values1 = new string[3] { "Nur", "Nil", "Berk" };

        //ram 502 => "Bartu, Mehmet"
        //                      index       0           1
        string[] values2 = new string[2] { "Bartu", "Mehmet" };

        values2 = values1; // => ram 501 "Nur" , "Nil", "Berk" // ram adresi 501 502'in uzerinde atiyoruz burda degeri degil direkt ram adresini degsitiriyoruz
        values2[0] = "Banu"; // => "Banu", "Nil" , "Berk"

        Debug.Log(values2[0]); //"Banu"
        Debug.Log(values1[0]); //"Banu"

        //int sayi2 = "string"; //hatali yazim
        //bool deger = "string"
        //boxing
        object objectValue1 = 10; //int
        object objectValue2 = 10.5f; //float
        object objectValue3 = "string value"; //string value
        object objectValue4 = false; //bool

        //unboxing / (int)objectValue ise cast etmektir convert ile ayni sey degildir cast etmek bir tipe veya tipin ne oldugnu hatirlatmaktir convert ise bir tipten baska bir tipe cevirmektir.
        int sayi1 = (int)objectValue1;

        //var keywork
        int value11 = 10;
        var value10 = "10";
        var value12 = false;

        //hata olablicek kodu dene demektir
        try
        {
            var value14 = Convert.ToInt32("101");
            print("hersey duzgun calisti");
        }
        catch (Exception ex) //catch bu hatayi yakar anlamina gelir
        {
            print("Format hatasi yapildi");
        }
        
    }
}