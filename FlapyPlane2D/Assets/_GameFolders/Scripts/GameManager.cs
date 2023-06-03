using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void GameOverProcess()
    {
        SceneManager.LoadScene("Game");
    }
}
