using CircleBall3D.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CircleBall3D.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] int _maxLevel = 3;
        [SerializeField] int _currentLevel = 1;

        public static GameManager Instance { get; private set; }

        public event System.Action OnLevelCompleted;
        public event System.Action OnGameOvered;

        void Awake()
        {
            Singleton();
        }

        void Start()
        {
            _currentLevel = SceneManager.GetActiveScene().buildIndex;
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

        public void LevelComplete()
        {
            Debug.Log("Level Completed");
            OnLevelCompleted?.Invoke();
        }

        public void GameOver()
        {
            Debug.Log("Game Overed");
            OnGameOvered?.Invoke();
        }

        public void LoadSceneByEnum(SceneEnum sceneEnum)
        {
            switch (sceneEnum)
            {
                case SceneEnum.Menu:
                    SceneManager.LoadScene("Menu");
                    break;
                case SceneEnum.Restart:
                    SceneManager.LoadScene("Level" + _currentLevel);
                    break;
                case SceneEnum.Level:
                    _currentLevel++;
                    if (_currentLevel <= _maxLevel)
                    {
                        SceneManager.LoadScene("Level" + _currentLevel);
                    }
                    else
                    {
                        _currentLevel = 1;
                        SceneManager.LoadScene("Level" + _currentLevel);
                    }
                    break;
                case SceneEnum.Start:
                    _currentLevel = 1;
                    SceneManager.LoadScene("Level" + _currentLevel);
                    break;
            }
        }

        public void ExitGame()
        {
            Debug.Log($"{nameof(ExitGame)} Triggered");
            Application.Quit();
        }
    }
}