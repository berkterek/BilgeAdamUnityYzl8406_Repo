using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShipWars2D.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public event System.Action OnGameOvered;
        
        void Awake()
        {
            Application.targetFrameRate = 60;
            transform.parent = null;

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

        public void GameOver()
        {
            OnGameOvered?.Invoke();
        }

        public void Play()
        {
            SceneManager.LoadScene("Game");
        }

        public void Menu()
        {
            SceneManager.LoadScene("Menu");
        }
    }    
}

