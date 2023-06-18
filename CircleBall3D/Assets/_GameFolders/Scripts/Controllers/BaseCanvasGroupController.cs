using UnityEngine;

namespace CircleBall3D.Controllers
{
    public abstract class BaseCanvasGroupController : MonoBehaviour
    {
        [SerializeField] CanvasGroup _canvasGroup;

        //OnValidate bir editor method'dur ve method sadece editor uzerinde calisir calisma sirasi ise editor derlendiginde bu method da calisir
        void OnValidate()
        {
            //editor uzerinde eger _canvasGroup null ise editor derlendiginde ayni game object'e bak varsa _canvasGroup degiskenine bunun referencasni cek demis oluyoruz yeni runtime uzerinde getcomponent ile deilg veya editor uzerinde surukle birak degil bu ise editor uzerinde otomatik bir sekilde yapimis oluyoruz
            if (_canvasGroup == null)
            {
                _canvasGroup = GetComponent<CanvasGroup>();
            }
        }

        protected void SetActiveCanvasGroup()
        {
            _canvasGroup.alpha = 1f;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
    }
}

