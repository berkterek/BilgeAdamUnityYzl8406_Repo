using UnityEngine;
using UnityEngine.UI;

namespace Platformer2D.Abstracts.Uis
{
    public abstract class BaseButton : MonoBehaviour
    {
        [SerializeField] protected Button _button;

        void OnValidate()
        {
            if (_button == null) _button = GetComponent<Button>();
        }

        protected virtual void OnEnable()
        {
            _button.onClick.AddListener(HandleOnButtonClicked);
        }

        protected virtual void OnDisable()
        {
            _button.onClick.RemoveListener(HandleOnButtonClicked);
        }

        protected abstract void HandleOnButtonClicked();
    }    
}

