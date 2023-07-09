using System;
using SpaceShipWars2D.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace SpaceShipWars2D.Uis
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] TMP_Text _scoreText;
        [SerializeField] PlayerDataContainerSO _playerDataContainer;

        void OnValidate()
        {
            if (_scoreText == null) _scoreText = GetComponent<TMP_Text>();
        }

        void Start()
        {
            _scoreText.SetText("0");
        }

        void OnEnable()
        {
            _playerDataContainer.ScoreHolder.OnScoreValueChanged += HandleOnScoreChanged;
        }

        void OnDisable()
        {
            _playerDataContainer.ScoreHolder.OnScoreValueChanged -= HandleOnScoreChanged;
        }
        
        void HandleOnScoreChanged(int score)
        {
            _scoreText.SetText(score.ToString());
        }
    }
}

