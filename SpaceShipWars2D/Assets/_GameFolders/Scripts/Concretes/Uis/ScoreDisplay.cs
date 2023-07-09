using SpaceShipWars2D.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace SpaceShipWars2D.Uis
{
    public class ScoreDisplay : BaseScoreDisplay
    {
        protected override void HandleOnScoreChanged(int score, int bestScore)
        {
            _scoreText.SetText(score.ToString());
        }
    }

    public abstract class BaseScoreDisplay : MonoBehaviour
    {
        [SerializeField] protected TMP_Text _scoreText;
        [SerializeField] protected PlayerDataContainerSO _playerDataContainer;

        void OnValidate()
        {
            if (_scoreText == null) _scoreText = GetComponent<TMP_Text>();
        }

        protected virtual void Start()
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

        protected abstract void HandleOnScoreChanged(int score, int bestScore);
    }
}

