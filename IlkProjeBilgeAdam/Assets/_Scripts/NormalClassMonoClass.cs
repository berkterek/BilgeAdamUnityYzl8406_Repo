using System;
using UnityEngine;

//MonoBehavior class sayesinde biz kendi custom olsuturdumuz class'lari game object uzerinde atamamizi saglariz
public class NormalClassMonoClass : MonoBehaviour
{
    public string InputIsim;
    public string InputSoyisim;
    public int InputYasi;

    [ContextMenu(nameof(InsanOlustur))]
    public void InsanOlustur()
    {
        Insan insan = new Insan();
        insan.Isim = InputIsim;
        // if (insan.Isim == "") return;

        insan.Soyisim = InputSoyisim;
        // if (insan.Soyisim == "") return;

        insan.Yasi = InputYasi;
        // if (insan.Yasi < 13 || insan.Yasi > 110) return;

        insan.ErkekMi = true;

        Debug.Log("Database server'a bilgiler gonderildi");
    }

    [ContextMenu(nameof(CalisanOlustur))]
    public void CalisanOlustur()
    {
        Calisan calisan = new Calisan();
        calisan.Isim = InputIsim;
        // if (calisan.Isim == "") return;

        calisan.Soyisim = InputSoyisim;
        // if (calisan.Soyisim == "") return;

        calisan.Yasi = InputYasi;
        // if (calisan.Yasi < 13 || calisan.Yasi > 110) return;

        calisan.ErkekMi = true;
        calisan.Maasi = 10000;
        calisan.IseGirisTarihi = DateTime.Now;

        Debug.Log("Database server'a bilgiler gonderildi");
    }

    [ContextMenu(nameof(MusteriOlsutur))]
    public void MusteriOlsutur()
    {
        //bu sekilde de instance yazilir scope icine direkt crtl + space bastignizda butun property'leri gorebilirsiniz daha kolay bir yazimdir
        Musteri musteri = new Musteri
        {
            Isim = InputIsim,
            Soyisim = InputSoyisim,
            Yasi = InputYasi,
            ErkekMi = false,
            ZenginMi = true
        };

        Debug.Log(musteri.Isim);
    }
}

/*
 * Pascal case => yazim kurali bu kuralda kelimenin ilk harfi buyuk sonrasi kucuk iki uc kelime varsa hepsi birlesik ve hepsinde ilk harfi buyuktur sonrasi kucuktur Normal, NormalClass, NormalClassOrnek peki biz pascal yazim kuralini nerelerde kullanriiz class isimlendirirken, property isimlendirirken, method isimlendirirken public field isimlendirirken
 *
 * Camel case => bu yazim kuraliinda kelimenin ilk harfi kucuktur sonrasida kucuk yazilir ama iki uc kelimeyse diger kelimelerin ilk harfi buyuk sonrasi kucuktur ornek ornek, ornekSayi, ornekTamSayi gibi biz bu yazim kuralini local degiskenlerde kullanriiz veya paramtrelerde
 *
 * Snake case => bu yazim kuralinda kelimemin basina alt tire gelir sonraki ilk kelimeinin bas harfi kucuktur ikinci ucunku kelime varsa onlarin bas harfleri buyuktur onrek => _ornek, _ornekSayi, _ornekTamSayi gibi bu yazim kuralini biz private field'larda kullaniriz
 * 
 */

public class NormalClass : Insan
{
    void Start()
    {
    }
}

/*
 *
 * Access Modifier denir erisim belirtecleridir bir yapinin method field veya class'in ne kadar esirileblir veya erisilemez oldugnu bu yapilar belirler. public ve private miras al ve islemlerinde protected
 *
 * public
 * public su demektir en erisleblir her yerden erisileblir demektir bir yapi public olursa bir class veya method icinde baska bir method veya class artik neyse o rahatllikla erisebilr anlamina gelir
 *
 * private
 * private en erislisemezdir en kapalidir bir yapi private ise sadece yazildigi veya olusturuldugu class icerisinde erisleblir demektir disaridan erisislemez demektir
 *
 * protected
 * protected private'in bir tik acik versiyonudur private'dan farki sudur private sadece olsutugu class icinde erisileblirdir proptected ise sadece olustugu ve miras verilen class icerisinde erisleblirdir onun disinda erisilemezdir
 * 
 */

public class Insan
{
    //isim field ve bizi field'lairmizi direkt acmayiz bir method veya property uzerinden field'larimiza disaridan eristitirz veya disidan data aliriz bunun nedeni giren cikan datayi kontrol edebilmek icindir bunun adina encapsulation yani kapsulleme yontemi denir
    protected string _isim;
    private string _soyisim;
    
    //property ozellik demektir biz kendi class'larimiza property atariz ozellik atariz property methodlarin bir gelismisidir kisacasi
    public string Isim
    {
        get { return _isim;}
        set
        {
            if (value == "")
            {
                return;
            }
            
            _isim = value;
        }
    }
    public string Soyisim
    {
        get {return _soyisim;}
        set { _isim = value; }
    }
    public int Yasi { get; set; }
    public bool ErkekMi { get; set; }

    public void SetIsim(string isim)
    {
        _isim = isim;
    }

    public string GetIsim()
    {
        return _isim;
    }
}

//biz burda isin soyisim gibi bilgileri girerek kendimizi tekrar etmis olduk
//inheritance mantigi yani miras alma verme mantigi derki
//miras almada su yapilamz bir class birden fazla class'dan miras alamaz ama bir class birden fazla class'a miras verebilir
public class Calisan : Insan /*,NormalClass //hatali islem bir class birden fazla class'dan miras alamaz*/
{
    // public string Isim;
    // public string Soyisim;
    // public int Yasi;
    // public bool ErkekMi;
    public float Maasi { get; set; }
    public DateTime IseGirisTarihi { get; set; }
}

//bir class olusturun ve bu class insandan miras alsin adi musteri olsun ZenginMi
public class Musteri : Insan
{
    //prop tap tap
    public bool ZenginMi { get; set; }
}