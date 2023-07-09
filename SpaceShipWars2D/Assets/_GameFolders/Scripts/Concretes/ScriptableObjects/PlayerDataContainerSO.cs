using UnityEngine;

namespace SpaceShipWars2D.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New PlayerDataContainer",
        menuName = "Bilge Adam/Data Container/Player Data Container")]
    public class PlayerDataContainerSO : ScriptableObject
    {
        [SerializeField] ScoreHolderSO _scoreHolder;
        [SerializeField] PlayerStatsSO _playerStats;

        public PlayerStatsSO PlayerStats => _playerStats;
        public ScoreHolderSO ScoreHolder => _scoreHolder;
    }
}