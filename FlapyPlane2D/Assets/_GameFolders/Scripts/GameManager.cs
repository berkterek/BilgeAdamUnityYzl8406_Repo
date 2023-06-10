using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int _playerScore = 0;

    //OnScoreChanged bir event'tir ve event'ler tetiklenen yapilardir burda biz her score degistiginde bu event'in tetiklenmeisni istiyoruz ki onu dinleyenler ayni zmaanda calissin.
    //bu yapi aslinda observer pattern'e girer observer pattern bir dinleyini ve dinleyiceleri olur dinlenen calisir ve onu dinleyenlerde ayni sekil calisirlar
    //OnScoreChanged dinlenen
    public event System.Action<int> OnScoreChanged;
    public event System.Action OnGameOvered;

    public int PlayerScore
    {
        get => _playerScore;
        set
        {
            _playerScore = value;
            //uzun yazimi
            // if (OnScoreChanged == null) return;
            //kisa yazimi "?" 
            OnScoreChanged?.Invoke(_playerScore);
        } 
    }
    
    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void GameOverProcess()
    {
        //SceneManager.LoadScene("Game");
        OnGameOvered?.Invoke();
        Time.timeScale = 0f;
    }

    public void LoadSceneWithSceneName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
}
