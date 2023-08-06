using UnityEngine;

namespace Platformer2D.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Player Data Container", menuName = "Bilge Adam/Data Container/Player Data Container")]
    public class PlayerDataContainer : ScriptableObject
    {
        [SerializeField] Coin _coin;

        public Coin Coin => _coin;

        void OnEnable()
        {
#if UNITY_EDITOR
            _coin.ResetValueOnEditor();
#endif
        }
    }

    [System.Serializable]
    public class Coin
    {
        [SerializeField] int _coinValue = 0;

        public int CoinValue => _coinValue;
        public event System.Action<int> OnCoinValueChanged;

        public void IncreaseCoinProcess(int value)
        {
            _coinValue += value;
            OnCoinValueChanged?.Invoke(_coinValue);
        }

        public bool DecreaseCoinProcess(int value)
        {
            int result = _coinValue - value;

            if (result < 0)
            {
                return false;
            }

            _coinValue = result;
            OnCoinValueChanged?.Invoke(_coinValue);
            return true;
        }
#if UNITY_EDITOR
        public void ResetValueOnEditor()
        {
            _coinValue = 0;
        }
#endif
        
    }
}

