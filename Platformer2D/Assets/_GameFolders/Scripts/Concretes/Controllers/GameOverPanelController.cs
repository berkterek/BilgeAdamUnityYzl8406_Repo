using Platformer2D.ScriptableObjects;
using UnityEngine;

namespace Platformer2D.Controllers
{
    public class GameOverPanelController : MonoBehaviour
    {
        [SerializeField] PlayerDataContainer _playerDataContainer;
        [SerializeField] CanvasGroup _canvasGroup;

        void OnValidate()
        {
            if (_canvasGroup == null) _canvasGroup = GetComponentInChildren<CanvasGroup>();
        }

        void OnEnable()
        {
            _playerDataContainer.OnHealthValueChanged += HandleOnHealthValueChanged;
        }
        
        void OnDisable()
        {
            _playerDataContainer.OnHealthValueChanged -= HandleOnHealthValueChanged;
        }

        void HandleOnHealthValueChanged(int currentHealth, int maxHealth)
        {
            if (currentHealth <= 0)
            {
                _canvasGroup.alpha = 1f;
                _canvasGroup.interactable = true;
                _canvasGroup.blocksRaycasts = true;
            }
        }
    }
}