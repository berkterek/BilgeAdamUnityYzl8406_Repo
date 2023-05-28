using System.Collections.Generic;
using UnityEngine;

public class LoopDongu : MonoBehaviour
{
    //Array ve List yapisi inspector uzerinde kullanilaiblin yapilardir
    public GameObject[] OrnekArray;

    public List<GameObject> ListObjects;
    //loop dongu demektir
    //dongu kendini tekrar eden ve arka arkaya olmasini istedigimzi islemleri yapmamizi saglayan yapdir
    
    
    private void Start()
    {
        //List yapimiz bizim arrayden sonra oyun dunyasinda kullnadigmiz en yayigin collection yapimizdir list'in calisma mantigi ayni array gibidir farki daha esnek olmasi array tek seferde aldigi kapasitesini listte yaptigmizda burda bu alan genisler
        
        List<string> listString = new List<string>();
        //Add method'u ile listimizi genisletebilriz yeni verileri atayabilirz
        listString.Add("Istanbul");
        listString.Add("Ankara");
        listString.Add("Izmir");

        foreach (string list in listString)
        {
            Debug.Log(list);
        }
        
        listString.Add("Adana");

        foreach (var list in listString)
        {
            Debug.Log(list);
        }
    }

    private void ArrayOrnek()
    {
        //Array'^ler bzim en ilkel collection yapimizdir ama en hizli collection yapisi oldugnu soyleyebilriz
        //Ilkellikten kastmiz sudur bir kere olusurlar ve bu olusum sonucu bizden alan acmamizi isterler 5 alan actigmizda bu arraya biz 5 deger atayabilirz 6. atadigimzda hata verir esnek bir yapi degildir
        
        string[] ornekArray1 = new string[3] { "Ankara", "Izmir", "Istanbul" };

        //burdaki [] icine yazdigmiz numara index numarasidir ve index'ler 0'dan baslar
        Debug.Log(ornekArray1[0]); //Ankara => 1
        Debug.Log(ornekArray1[1]); //Izmir => 2
        Debug.Log(ornekArray1[2]); //Istanbul => 3

        ornekArray1[3] = "Adana";
    }

    private void LoopsVeArrayGiris()
    {
        //int i = 0;
        //i++;
        //Debug.Log(i);
        //i++;
        //Debug.Log(i);
        //i++;
        //Debug.Log(i);
        //i++;
        //Debug.Log(i);
        //i++;
        //Debug.Log(i);
        //i++;
        //Debug.Log(i);
        //i++;
        //Debug.Log(i);
        //i++;
        //Debug.Log(i);
        //i++;
        //Debug.Log(i);
        //i++;
        //Debug.Log(i);
        //bu boyle gider

        //for/while/do while/foreach
        //for ile while ayni mantikta calisir diyebilirz for ile while arasinda yazim farki vardir calisma mantigi aynidir
        //for'da genelde bir saydirma islemi icin kullaniz orngin 0'dan 100'e kadar su islemi yap gibi
        //1-int j veya genelde i yazariz sayactir
        //2-sart yapisdir yani true false donen yapi burda sart saglandikca dongu calisir
        //3-j++ ise sartin sonsuza kadar gitmemsiini saglyan yapi
        //for tap tap
        //      1       2       3
        //for(int j = 0; j < 100; j++)
        //{
        //    Debug.Log(j);
        //}

        //while genelde daha az kullanilan dongudur for'a gore for sayisal ypailarda cok cok kullanilir while ise sayisal + direkt true false yapiliari icin kullanilir
        //while ile for ayni mantikta calisir sart saglandigi surece dongu calir for daha cok sayisal artislarda kullanilri while ise sayisal veya bir sart yapisai orngin string is empty veya bu tarz islemlerde while daha cok gorebilr
        //int i = 0;
        //string condition1 = null;
        //while (condition1 == null)
        //{

        //}

        //int i = 0;
        //while (i < 10)
        //{
        //    Debug.Log(i);
        //    i++;
        //}

        //do while
        //do while for ve while'dan farki do while once calsir en az bir kere sonra sarta bakar eger sart sagliniyorsa dongu sart saglandigi surece calsir ama sart saglanmiyorsa dongu calismaz for while ise sadece sart saglandiginda calisir

        // int j = 100;
        // while (j < 10)
        // {
        //     j++;
        //     print("While " + j);
        // }

        // int i = 100;
        // do
        // {
        //     Debug.Log("Do While " + i);
        //     i++;
        // } while (i < 10);
        
        //foreach
        //foreach uc dongudende farklidir ve kendisi calismak icin bizden bir collection yapisi ister ornek dizi list gibi ve bu diger dongulerden farkli olarak kendisine verilen list yapisinin her bir elemani icin calir
        //string dizisi values1 adinda bir degsiken olsuturdunuz ve bu degiskenin ram uzerinde 3 string alicak alanini acmis oldugnuz anlamina gelir
        // string[] values = new string[3]; //0. => Istanbul - 1. => Izmir - 2. => Ankara
        // values[0] = "Istanbul";
        // values[1] = "Izmir";
        // values[2] = "Ankara";

        // string[] values = new string[3] { "Istanbul", "Izmir", "Ankara" };
        string[] values = { "Istanbul", "Izmir", "Ankara" };
        //dongu icinde donguden cektigi tipi karsilicak degiskeni yazdirir
        foreach (string value in values)
        {
            Debug.Log(value);
        }

        for (int i = 0; i < values.Length; i++)
        {
            Debug.Log(values[i]);
        }
    }
}
