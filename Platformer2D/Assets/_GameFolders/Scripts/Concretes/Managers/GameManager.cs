using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer2D.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        int _currentSceneIndex;
        
        void Awake()
        {
            Singleton();
            Application.targetFrameRate = 60;
        }

        void Start()
        {
            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }

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

        public void LevelChangedProcess(int value)
        {
            _currentSceneIndex += value;
            StartCoroutine(LoadSceneWithIndexAsync(_currentSceneIndex));
        }

        IEnumerator LoadSceneWithIndexAsync(int nextIndex)
        {
            yield return SceneManager.LoadSceneAsync(nextIndex);
        }
    }    
}

