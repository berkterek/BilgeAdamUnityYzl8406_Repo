using UnityEngine;

namespace SpaceShipWars2D.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New ScoreHolder",
        menuName = "Bilge Adam/Holders/Score Holder")]
    public class ScoreHolderSO : ScriptableObject
    {
        [SerializeField] int _score = 0;

        public event System.Action<int> OnScoreValueChanged;

        public void IncreaseScore(int value)
        {
            _score += value;
            OnScoreValueChanged?.Invoke(_score);
        }

        public bool DecreaseScore(int value)
        {
            int result = _score - value;

            if (result >= 0)
            {
                _score = result;
                OnScoreValueChanged?.Invoke(_score);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}