using CircleBall3D.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace CircleBall3D.Uis
{
    public class ExitButton : BaseButton
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.ExitGame();
        }
    }

    //abstract class soyut class'lardir bir tek amaci vardir baska class'lara miras vermektir burda kendini tekrar etme mantiyla yola cikip iki class'în ayni calisan yerlerlerini kodlarin alip base class'a verdik ve bir tane abstract method olusturup ki burda button clicklenme event'inin tektikleyen method burda class'lar icinde burdaki mantigi ayirmis olduk ayni exit button class'inda exit button islemleri olur navigation icinde navigasyon islemleri olur ama diger kendini tekrar eden yerleri base class icinde tutup ihtiyaci olan classlara verip tekrar tekrar ayni kodlari yazmamis olduk
    public abstract class BaseButton : MonoBehaviour
    {
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

        //bu bir soyut method'tur abstract method'tur ve soyut methodlarin govdeis olmaz miras verilen class'lar icinde govdesi yazilir
        protected abstract void HandleOnButtonClicked();
    }
}

