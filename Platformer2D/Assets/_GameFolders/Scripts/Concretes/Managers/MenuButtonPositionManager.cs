using UnityEngine;

namespace Platformer2D.Managers
{
    public class MenuButtonPositionManager : MonoBehaviour
    {
        [SerializeField] RectTransform[] _rectTransforms;

#if UNITY_ANDROID
        void Start()
        {
            _rectTransforms[0].gameObject.SetActive(false);
        
            _rectTransforms[1].anchoredPosition = Vector2.zero;
        }
#endif
    }    
}