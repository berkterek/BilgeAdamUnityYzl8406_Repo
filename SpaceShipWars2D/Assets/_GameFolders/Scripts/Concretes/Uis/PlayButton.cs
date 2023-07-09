using SpaceShipWars2D.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShipWars2D.Uis
{
    public class PlayButton : BaseButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.Play();
        }
    }

    public abstract class BaseButton : MonoBehaviour
    {
        [SerializeField] protected Button _button;

        protected virtual void OnValidate()
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

