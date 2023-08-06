using Platformer2D.ScriptableObjects;
using UnityEngine;

namespace Platformer2D.Controllers
{
    public class HealthHolderController : MonoBehaviour
    {
        [SerializeField] PlayerDataContainer _playerDataContainer;
        [SerializeField] GameObject[] _hpHolders;

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
            if (currentHealth < 0) return;
            
            _hpHolders[currentHealth].gameObject.SetActive(false);
        }
    }    
}