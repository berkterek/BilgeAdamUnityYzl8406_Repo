using UnityEngine;

namespace SpaceShipWars2D.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New ScoreHolder",
        menuName = "Bilge Adam/Holders/Score Holder")]
    public class ScoreHolderSO : ScriptableObject
    {
        [SerializeField] int _score = 0;
        [SerializeField] int _bestScore;

        public event System.Action<int,int> OnScoreValueChanged;
        public int BestScore => _bestScore;

        void OnEnable()
        {
            ResetCurrentScore();
        }

        public void IncreaseScore(int value)
        {
            _score += value;
            
            if (_score > _bestScore)
            {
                _bestScore = _score;
            }
            
            OnScoreValueChanged?.Invoke(_score, _bestScore);
        }

        public bool DecreaseScore(int value)
        {
            int result = _score - value;

            if (result >= 0)
            {
                _score = result;
                OnScoreValueChanged?.Invoke(_score, _bestScore);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ResetCurrentScore()
        {
            _score = 0;
        }
    }
}