using Platformer2D.Abstracts.Uis;
using Platformer2D.Managers;

namespace Platformer2D.Uis
{
    public class StartButton : BaseButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.StartGame();
        }
    }
}