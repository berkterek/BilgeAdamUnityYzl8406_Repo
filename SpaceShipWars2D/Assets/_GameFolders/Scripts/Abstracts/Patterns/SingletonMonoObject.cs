using UnityEngine;

namespace SpaceShipWars2D.Abstracts.Patterns
{
    //<T> bu bir generic yapidir ve T ise burda bir tipi temsil eder
    //burda hala hata vermesinin nedeni bu tipin hersey olablimesinden kaynaklidir orneign bu tip bir class veya struct olablir class ornek GameManager, SoundManager gibi ayni zamanda struct da olablir ornek int, bool, float gibi oalblir
    //bu generic tipi daha gelirgin bir hala getiririz buna filtreleme yaparak el ederiz
    //where ile biz bu tipin bir class oldgunu ve new ile bu class soyut(abstract) degil somut bir class oldugunu belirtmis oluyoruz
    public abstract class SingletonMonoObject<T> : MonoBehaviour where T : class, new()
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            transform.parent = null;

            if (Instance == null)
            {
                Instance = this as T;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}