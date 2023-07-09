using SpaceShipWars2D.Managers;
using UnityEngine;

namespace SpaceShipWars2D.Controllers
{
    public class InputPanelController : MonoBehaviour
    {
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
            this.gameObject.SetActive(false);
        }
    }    
}

