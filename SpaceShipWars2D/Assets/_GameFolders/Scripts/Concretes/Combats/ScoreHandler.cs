using SpaceShipWars2D.ScriptableObjects;

namespace SpaceShipWars2D.Combats
{
    public class ScoreHandler : IScoreHandler
    {
        readonly IScoreStats _scoreStats;
        readonly PlayerDataContainerSO _playerDataContainer;
        
        public ScoreHandler(ScoreHandlerDataEntity entity)
        {
            _scoreStats = entity.ScoreStats;
            _playerDataContainer = entity.PlayerDataContainer;
        }

        public void GiveScore()
        {
            _playerDataContainer.ScoreHolder.IncreaseScore(_scoreStats.Score);
        }
    }

    public interface IScoreHandler
    {
        void GiveScore();
    }

    public struct ScoreHandlerDataEntity
    {
        public IScoreStats ScoreStats { get; set; }
        public PlayerDataContainerSO PlayerDataContainer { get; set; }
    }
}