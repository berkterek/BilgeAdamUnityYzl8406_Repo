using SpaceShipWars2D.Abstracts.Patterns;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShipWars2D.Managers
{
    public class GameManager : SingletonMonoObject<GameManager>
    {
        public event System.Action OnGameOvered;
        
        protected override void Awake()
        {
            Application.targetFrameRate = 60;
            base.Awake();
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

