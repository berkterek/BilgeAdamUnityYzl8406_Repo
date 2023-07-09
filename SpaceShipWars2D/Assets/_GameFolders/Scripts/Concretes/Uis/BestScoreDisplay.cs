namespace SpaceShipWars2D.Uis
{
    public class BestScoreDisplay : BaseScoreDisplay
    {
        protected override void Start()
        {
            _scoreText.SetText(_playerDataContainer.ScoreHolder.BestScore.ToString());
        }

        protected override void HandleOnScoreChanged(int score, int bestScore)
        {
            _scoreText.SetText(bestScore.ToString());
        }
    }
}