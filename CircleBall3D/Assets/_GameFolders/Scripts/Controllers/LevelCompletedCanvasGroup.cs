using CircleBall3D.Managers;

namespace CircleBall3D.Controllers
{
    public class LevelCompletedCanvasGroup : BaseCanvasGroupController
    {
        void OnEnable()
        {
            GameManager.Instance.OnLevelCompleted += HandleOnLevelCompleted;
        }

        void OnDisable()
        {
            GameManager.Instance.OnLevelCompleted -= HandleOnLevelCompleted;
        }
        
        void HandleOnLevelCompleted()
        {
            SetActiveCanvasGroup();
        }
    }
}