using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ThirdPersonSample2.Controller
{
    public class PlayerWeaponChangeController : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        [SerializeField] GameObject _pistolObject;
        [SerializeField] InputActionReference _weapon0Reference;
        [SerializeField] InputActionReference _weapon1Reference;
        [SerializeField] InputActionReference _weapon2Reference;
        [SerializeField] bool _isWeaponChangeRoutineContinue = false;
        [SerializeField] float _lerpSpeed = 1f;

        void OnEnable()
        {
            _weapon0Reference.action.performed += HandleOnWeapon0Selection;
            _weapon0Reference.action.canceled += HandleOnWeapon0Selection;

            _weapon1Reference.action.performed += HandleOnWeapon1Selection;
            _weapon1Reference.action.canceled += HandleOnWeapon1Selection;

            _weapon2Reference.action.performed += HandleOnWeapon2Selection;
            _weapon2Reference.action.canceled += HandleOnWeapon2Selection;

            _weapon0Reference.action.Enable();
            _weapon1Reference.action.Enable();
            _weapon2Reference.action.Enable();
        }

        void OnDisable()
        {
            _weapon0Reference.action.performed -= HandleOnWeapon0Selection;
            _weapon0Reference.action.canceled -= HandleOnWeapon0Selection;

            _weapon1Reference.action.performed -= HandleOnWeapon1Selection;
            _weapon1Reference.action.canceled -= HandleOnWeapon1Selection;

            _weapon2Reference.action.performed -= HandleOnWeapon2Selection;
            _weapon2Reference.action.canceled -= HandleOnWeapon2Selection;

            _weapon0Reference.action.Disable();
            _weapon1Reference.action.Disable();
            _weapon2Reference.action.Disable();
        }

        void HandleOnWeapon0Selection(InputAction.CallbackContext context)
        {
            if (_isWeaponChangeRoutineContinue) return;
            
            if (_weapon0Reference.action.WasPressedThisFrame())
            {
                Debug.Log("Weapon 0 selected");
                StartCoroutine(NoWeaponSelectionAsync());
            }
        }

        void HandleOnWeapon1Selection(InputAction.CallbackContext context)
        {
            if (_isWeaponChangeRoutineContinue) return;
            
            if (_weapon1Reference.action.WasPressedThisFrame())
            {
                Debug.Log("Weapon 1 selected");
                StartCoroutine(PistolSelectionAsync());
            }
        }

        void HandleOnWeapon2Selection(InputAction.CallbackContext context)
        {
            if (_isWeaponChangeRoutineContinue) return;
            
            if (_weapon2Reference.action.WasPressedThisFrame())
            {
                Debug.Log("Weapon 2 selected");
            }
        }

        private IEnumerator PistolSelectionAsync()
        {
            _isWeaponChangeRoutineContinue = true;
            
            _pistolObject.gameObject.SetActive(true);

            float weigth = 0f;
            float timer = 0f;
            while (weigth < 0.99f)
            {
                timer += Time.deltaTime * _lerpSpeed;
                weigth = Mathf.Lerp(weigth, 1f, timer);
                _animator.SetLayerWeight(1, weigth);
                yield return null;
            }

            weigth = 1f;
            _animator.SetLayerWeight(1, weigth);
            
            _isWeaponChangeRoutineContinue = false;
        }

        private IEnumerator NoWeaponSelectionAsync()
        {
            _isWeaponChangeRoutineContinue = true;
            
            _pistolObject.gameObject.SetActive(false);
            
            float weigth = 1f;
            float timer = 0f;
            while (weigth > 0.1f)
            {
                timer += Time.deltaTime * _lerpSpeed;
                weigth = Mathf.Lerp(weigth, 0f, timer);
                _animator.SetLayerWeight(1, weigth);
                yield return null;
            }

            weigth = 0f;
            _animator.SetLayerWeight(1, weigth);
            
            _isWeaponChangeRoutineContinue = false;
        }
    }
}