using CircleBall3D.Managers;

namespace CircleBall3D.Controllers
{
    public class GameOveredCanvasGroup : BaseCanvasGroupController
    {
        void OnEnable()
        {
            GameManager.Instance.OnGameOvered += HandleOnGameOvered;
        }

        void OnDisable()
        {
            GameManager.Instance.OnGameOvered -= HandleOnGameOvered;
        }
        
        void HandleOnGameOvered()
        {
            SetActiveCanvasGroup();
        }
    }
}