using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int PlayerScore = 0;
    
    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void GameOverProcess()
    {
        SceneManager.LoadScene("Game");
    }
}
