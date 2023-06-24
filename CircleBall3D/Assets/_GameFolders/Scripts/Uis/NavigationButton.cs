using CircleBall3D.Enums;
using CircleBall3D.Managers;
using UnityEngine;

namespace CircleBall3D.Uis
{
    public class NavigationButton : BaseButton
    {
        [SerializeField] SceneEnum _sceneEnum;

        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadSceneByEnum(_sceneEnum);
        }
    }    
}

