using System.Collections;
using SpaceShipWars2D.Managers;
using UnityEngine;

namespace SpaceShipWars2D.Controllers
{
    public class GameOverPanelController : MonoBehaviour
    {
        [SerializeField] float _duration = 3f;
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
            StartCoroutine(HandleOnGameOverAsync());
        }

        private IEnumerator HandleOnGameOverAsync()
        {
            yield return new WaitForSeconds(2f);
            
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            
            float timer = 0f;
            while (_canvasGroup.alpha < 1f)
            {
                timer += Time.deltaTime;
                _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, 1f, timer / _duration);
                yield return null;
            }
        }
    }    
}

