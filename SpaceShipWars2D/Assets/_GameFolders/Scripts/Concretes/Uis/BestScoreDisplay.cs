namespace SpaceShipWars2D.Uis
{
    public class BestScoreDisplay : BaseScoreDisplay
    {
        protected override void HandleOnScoreChanged(int score, int bestScore)
        {
            _scoreText.SetText(bestScore.ToString());
        }
    }
}