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
}
