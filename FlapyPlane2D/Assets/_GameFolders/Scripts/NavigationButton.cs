using UnityEngine;
using UnityEngine.UI;

public class NavigationButton : MonoBehaviour
{
    [SerializeField] string _sceneName;
    [SerializeField] GameManager _gameManager;
    [SerializeField] Button _button;

    void OnEnable()
    {
        //onClick bizin normal event'lerimiz gibi degildir bu bir unity event'tir ve unity event'Lere bir method eklemk istedigimzde AddListener ile ekleriz
        //unity event ve normal event'lerin arasindaki fark sudur unity event hem inspector uzerinde hemde code uzerinden event'e method ataybiliizr ve biz inspector uzerinden game object veya component atayarak event'lere method atayabilirz. normal event'lerde ise sadece kod uzerinden method atayabilriz
        _button.onClick.AddListener(HandleOnButtonClicked);
    }

    void OnDisable()
    {
        //remove ile bu attach'i kaldirmis oluruz event uzerinden
        _button.onClick.RemoveListener(HandleOnButtonClicked);
    }
    
    void HandleOnButtonClicked()
    {
        _gameManager.LoadSceneWithSceneName(_sceneName);
    }
}
