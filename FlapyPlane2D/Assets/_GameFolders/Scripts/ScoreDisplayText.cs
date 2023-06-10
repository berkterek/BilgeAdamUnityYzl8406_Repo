using TMPro;
using UnityEngine;

public class ScoreDisplayText : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [SerializeField] GameManager _gameManager;

    void Start()
    {
        _text.SetText(_gameManager.PlayerScore.ToString());
    }

    void OnEnable()
    {
        //burda += event'e method attach'liyoruz ekliyoruz
        //              Dinlenen            Dinleyen
        _gameManager.OnScoreChanged += HandleOnScoreChanged;
        //_gameManager.OnScoreChanged += OrnekMethod;
    }

    // void OrnekMethod(int obj)
    // {
    //     
    // }

    void OnDisable()
    {
        //burda ise -= event'e method cikariyoruz isimiz bitince cunku kalan eski referans metholari missing reference hatalrai verebilir bununla karsilasmamak icin bu methodlari event'lerden cikaririz
        _gameManager.OnScoreChanged -= HandleOnScoreChanged;
        //_gameManager.OnScoreChanged -= OrnekMethod;
    }
    
    void HandleOnScoreChanged(int score)
    {
        _text.SetText(score.ToString());
    }
}