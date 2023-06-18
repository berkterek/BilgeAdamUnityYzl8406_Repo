using UnityEngine;

namespace CircleBall3D.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public event System.Action OnLevelCompleted;

        void Awake()
        {
            Singleton();
        }

        //singleton pattern bir design patterndir ve diger design pattern'lerle ayni mantiktadir yani kaliplasmias sorunlarin kaliplasmis cozumudur burda bir singleton yontemi kullaniyoruz mantigi sudur static bir instance icinde ilk gelen referansi tutuyoruz ve eger Instance null ise ilk referansi sakla ve oyun sonuna kadar onu kullan demis olduk unity game engine kullandigimz icin burda hersey game object uzerinden yurur ve burda bir singleton mantigi kullandimizdan ayni seyi o referansi saklayan GameObject icinde yapariz DontDestroyOnLoad method'u o game object'in butun oyun boyunca saklanacaigni ifade eder else icine gelicek olursa yeni olucan GameObject'leri yok et dmeis olduk boylelikle hem class referansi olarak hemde game object olarak bir tekillik yakalamis olduk.
        private void Singleton()
        {
            if (Instance == null)
            {
                Instance = this;    
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void LevelCompleted()
        {
            Debug.Log("Level Completed");
            OnLevelCompleted?.Invoke();
        }
    }   
}