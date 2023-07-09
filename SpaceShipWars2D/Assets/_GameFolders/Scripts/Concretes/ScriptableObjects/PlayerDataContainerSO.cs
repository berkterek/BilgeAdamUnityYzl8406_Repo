using UnityEngine;

namespace SpaceShipWars2D.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New PlayerDataContainer",
        menuName = "Bilge Adam/Data Container/Player Data Container")]
    public class PlayerDataContainerSO : ScriptableObject
    {
        [SerializeField] int _score = 0;
        [SerializeField] PlayerStatsSO _playerStats;

        public PlayerStatsSO PlayerStats => _playerStats;

        public int Score
        {
            get => _score;
            set => _score = value;
        }
    }
}