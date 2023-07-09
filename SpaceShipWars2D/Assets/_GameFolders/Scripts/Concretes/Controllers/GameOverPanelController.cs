using SpaceShipWars2D.Managers;
using UnityEngine;

namespace SpaceShipWars2D.Controllers
{
    public class GameOverPanelController : MonoBehaviour
    {
        [SerializeField] CanvasGroup _canvasGroup;

        void OnValidate()
        {
            if (_canvasGroup == null) _canvasGroup = GetComponent<CanvasGroup>();
        }

        void OnEnable()
        {
            if (GameManager.Instance == null) return;
            GameManager.Instance.OnGameOvered += HandleOnGameOvered;
        }

        void OnDisable()
        {
            if (GameManager.Instance == null) return;
            GameManager.Instance.OnGameOvered -= HandleOnGameOvered;
        }
        
        void HandleOnGameOvered()
        {
            _canvasGroup.alpha = 1f;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
    }    
}

