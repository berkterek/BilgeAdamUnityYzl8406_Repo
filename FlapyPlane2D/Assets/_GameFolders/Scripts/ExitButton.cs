using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    [SerializeField] Button _button;

    void OnEnable()
    {
        _button.onClick.AddListener(HandleOnButtonClicked);
    }

    void OnDisable()
    {
        _button.onClick.RemoveListener(HandleOnButtonClicked);
    }
    
    void HandleOnButtonClicked()
    {
        _gameManager.Exit();
    }
}
