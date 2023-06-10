using UnityEngine;

public class GameOverPanelController : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] GameObject _gameOverObject;

    void OnEnable()
    {
        _gameManager.OnGameOvered += HandleOnGameOvered;
    }

    void OnDisable()
    {
        _gameManager.OnGameOvered -= HandleOnGameOvered;
    }
    
    void HandleOnGameOvered()
    {
        _gameOverObject.SetActive(true);
    }
}
