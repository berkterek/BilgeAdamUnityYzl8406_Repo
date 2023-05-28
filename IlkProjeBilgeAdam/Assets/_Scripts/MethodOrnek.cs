using UnityEngine;

//MonoBehavior ozel bir class'tir ve bu class sayesinde biz yarattimiz script'leri GameObject'ler uzerine atayabiliriz
public class MethodOrnek : MonoBehaviour
{
    //Method nedir ne isimize yararlar? 
    //Methodlar bir yapiyi bir mantigi bir islemi calistirmak icin kulladigmiz yapilardir ornek iki sayinin toplami gibi bu islemeri methodlari icinde yapariz bu en temel method kullanimidir ikinici en temel kullanim ise kendini tekrar eden kodlari tekrar terar yazmamak icin biz o kod blogunu methodlastiririz ve ayni kodlari tekrar tekrar yazmak yerine sadece o methodu kullairiz
    //unity'e baktigmöizda burda ozel methodlar vardir ve bu ozel methodlar MonoBehaviour'in icinden gelir o sayede biz o ozel methodlara ulasabilriz bu ozel methodlari siralicak olursak mono class ozel baslangic bitis methodlari => "Awake, Start, OnEnable, OnDisable, Destroy" loop => "Update-FixedUpdate ve LateUpdate" Fiziksel methodlar =>  "OnCollisionEnter, OnCollisionExit, OnCollisionStay, OnTriggerEnter, OnTriggerExit, OnTriggerStay"
    
    //access modifier => public private protected internal
    //method'lar ikiye ayrilir deger donduren ve deger dondurmeyen eger deger dondurmuyorsa void keyword yazilir eger deger donduruyorsa donen tip yazilir ornk int,string veya custom class veya struct gibi
    //Method adi yazilir ve her class icinde unique isim yazilir
    //sonuna parantez ac kapat eklenir bu parantezlerin amaci ekleme nedeni bu method parametre alabilr veya alamz eger parametre aliyorsa parantez icine aldigi tip yazilir ornek int string gibi eger burdaki gibi parametre almiyorsa sadece paranterz ac kapat yazilir
    //en son kodun calsicagi scope araliklari verilir bunun nedneni ise bu method baslangic scope icinde kod calismaya baslar bitis scope icinde kod biter
    //deger dondurmeyen ve parametre almayan bir method'tur
    public void DegerDondurmeyenMethod()
    {//baslangic scope
        
        //code buraya yazilir
        
        int sayi1 = 10;
        int sayi2 = 20;

        //bu new'leme islemine instance alma ornegini almak denir ram uzerinde alan acmak
        // Int32 sayi3 = new Int32();
        // sayi3 = 10;

        int sonuc = sayi1 + sayi2;

        Debug.Log(sonuc);

    }//bitis scope

    public void DegerDondurmeyenVeParametreAlanMethod1(int sayi1, int sayi2)
    {
        int sonuc = sayi1 + sayi2;
        Debug.Log(sonuc);
    }
    
    //deger donduren method bizim normal deger dondurmeyen methodlarda bir islem olur ve o sonuc orda yazdilir ve biter tekrar ona ulasamayiz deger donduren methodflarda ise islem olur ve biz method icerisindeki islem sonucu koda geri veririz ve islem sonuucu ulasip tekrar kullanabilriiz anlamina gellir

    public string DegerDondurenVeParametreAlanMethodlar(int sayi1, int sayi2)
    {
        int sonuc = sayi1 + sayi2;
        Debug.Log(sonuc);

        return sonuc.ToString();
    }

    public OdevScript OdevScript;
    
    OdevScript _odevScript;

    //Awake ozel bir method'tur bir mono class'in ile calisan method'udur ilk bastan awake calsir ve awake her script'te sadece bir kere calsir
    //Awake kullanim amaci instance olusturma ve refereans yakalamak icidir
    void Awake()
    {
        //bu yapi ile biz target frame yani oyununun almais gerek limit frame'i fixleyebilriz
        Application.targetFrameRate = 60;
        //baska bir script'i mono script'i ayni game object uzerinden cagirmak icin GetComponent kullanilir
         _odevScript = GetComponent<OdevScript>(); //cache
        Debug.Log(nameof(Awake));
    }

    //OnEnable ikinci calisan method'tur Awake'ten sonra OnEnable calir on enable'in farki Awake ve Start her scirpt icin bir kere calsir OnEnable ise bagli oldugu GameObject veya GameObject uzerinde kendiside olablir her enable oldugunda tekrar tekrar caliri
    //OnEnable birden cok tetiklenmeisni bekledigimiz senaryolar icin kullairzi ve Event Attachlemek icinde kullanir
    void OnEnable()
    {
        Debug.Log(nameof(OnEnable));
    }

    //Start method ayni awake gibi bir kere calisir mono icinde calisan 3. method'tur siralama soyledir Awake-OnEnable-Start seklindedir Start icinde calistirgiimzi yapi genelde Awake icinde cache'ledigmiz degiskenlerin methodlarini tetikleriz
    void Start()
    {
        //DegerDondurmeyenVeParametreAlanMethod1(10,20); //30
        //DegerDondurmeyenVeParametreAlanMethod1(30,50); //80
        //DegerDondurmeyenVeParametreAlanMethod1(100,200); //300

       // string value = DegerDondurenVeParametreAlanMethodlar(10, 20);
       // Debug.Log("Sonuc => " + value);
       Debug.Log(nameof(Start));
       _odevScript.OrnekMethod();
    }

    //Update oyun dongusudur ve her bir frame'de bir calisir Update genelde hesap kipat islerinde kullanilir veya gelen input input alma gibi islerde kullanirlir
    void Update()
    {
        Debug.Log(nameof(Update));
    }

    //FixedUpdate 0.02 sayinyede bir calir hatta settings icinde bu ayar degistirileblirdir veya fizik motorulya senkronize calsir yani update gibi herbir framede bir gibi degil fizik moturunun kullanimina gore bir framede birden fazlada calisiabilr
    //FixedUpdate nerelerde kullaniriz genelde fizik islemleriyle birlikte kullaniriz orngin karakter haraket etmesi gibi
    void FixedUpdate()
    {
        Debug.Log(nameof(FixedUpdate));
    }
    
    //LateUpdate ayni Update gibi herbir frame de bir calisir Update'den farki en son calir kullanildigi yer ise Update input aldi FixedUpdate input'i isledi ve Haraket ettirdi karakteri LateUpdate icinde ise son islmeler ornek Animator motoru calsir ve animasyonlari calsitiridigmiz alandir veya son olarak butun islemlerden sonra tekrar bir hesap kitap yapmak istersek gene LateUPdate kullanilir
    void LateUpdate()
    {
        Debug.Log(nameof(LateUpdate));
    }
}
