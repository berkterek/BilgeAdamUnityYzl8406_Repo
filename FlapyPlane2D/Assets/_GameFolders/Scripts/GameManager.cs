using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int _playerScore = 0;

    public int PlayerScore
    {
        get => _playerScore;
        set => _playerScore = value;
    }
    
    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void GameOverProcess()
    {
        SceneManager.LoadScene("Game");
    }
}
