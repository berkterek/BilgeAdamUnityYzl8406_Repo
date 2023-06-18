using CircleBall3D.Enums;
using CircleBall3D.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace CircleBall3D.Uis
{
    public class NavigationButton : MonoBehaviour
    {
        [SerializeField] SceneEnum _sceneEnum;
        [SerializeField] Button _button;

        void OnValidate()
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }
        }

        void OnEnable()
        {
            _button.onClick.AddListener(HandleOnButtonClicked);
        }

        void OnDisable()
        {
            _button.onClick.RemoveListener(HandleOnButtonClicked);
        }
        
        void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadSceneByEnum(_sceneEnum);
        }
    }    
}

