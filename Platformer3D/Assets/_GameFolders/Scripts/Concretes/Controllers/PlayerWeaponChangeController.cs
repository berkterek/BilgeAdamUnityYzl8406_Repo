using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ThirdPersonSample2.Controller
{
    public class PlayerWeaponChangeController : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        [SerializeField] GameObject _pistolObject;
        [SerializeField] GameObject _rifleObject;
        [SerializeField] InputActionReference _weapon0Reference;
        [SerializeField] InputActionReference _weapon1Reference;
        [SerializeField] InputActionReference _weapon2Reference;
        [SerializeField] bool _isWeaponChangeRoutineContinue = false;
        [SerializeField] float _lerpSpeed = 1f;

        int _lastIndex;

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
                StartCoroutine(RifleSelectionAsync());
            }
        }

        private IEnumerator PistolSelectionAsync()
        {
            yield return SelectWeapon(_pistolObject, 1);
        }

        private IEnumerator RifleSelectionAsync()
        {
            yield return SelectWeapon(_rifleObject, 2);
        }

        private IEnumerator SelectWeapon(GameObject weaponObject, int layerIndex)
        {
            _isWeaponChangeRoutineContinue = true;

            if (layerIndex != 0)
            { 
                float lastWeight = _animator.GetLayerWeight(_lastIndex);
                if (lastWeight > 0.1f)
                {
                    yield return NoWeaponSelectionAsync();
                }
            }
            
            _lastIndex = layerIndex;

            weaponObject.gameObject.SetActive(true);
            
            float weight = 0f;
            float timer = 0f;
            while (weight < 0.99f)
            {
                timer += Time.deltaTime * _lerpSpeed;
                weight = Mathf.Lerp(weight, 1f, timer);
                _animator.SetLayerWeight(layerIndex, weight);
                yield return null;
            }

            weight = 1f;
            _animator.SetLayerWeight(layerIndex, weight);
            
            _isWeaponChangeRoutineContinue = false;
        }

        private IEnumerator NoWeaponSelectionAsync()
        {
            _isWeaponChangeRoutineContinue = true;
            
            _pistolObject.gameObject.SetActive(false);
            _rifleObject.SetActive(false);
            
            float weight = 1f;
            float timer = 0f;
            while (weight > 0.1f)
            {
                timer += Time.deltaTime * _lerpSpeed;
                weight = Mathf.Lerp(weight, 0f, timer);
                _animator.SetLayerWeight(_lastIndex, weight);
                yield return null;
            }

            weight = 0f;
            _animator.SetLayerWeight(1, weight);
            
            _isWeaponChangeRoutineContinue = false;
        }
    }
}