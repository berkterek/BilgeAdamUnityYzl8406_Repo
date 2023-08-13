using UnityEngine;

namespace ThirdPersonSample2.Controller
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] LayerMask _layerMask;
        [SerializeField] Transform _firePoint;
        [SerializeField] float _maxFireRate = 1f;

        float _currentFireRate = 0f;
        Camera _camera;

        void Awake()
        {
            _camera = Camera.main;
        }

        void Update()
        {
            _currentFireRate += Time.deltaTime;
            Debug.DrawLine(_firePoint.position, _firePoint.forward * 100f, Color.red);
            Debug.DrawLine(_camera.transform.position, _camera.transform.forward * 100f, Color.blue);
            
            // // Creates a Ray from the center of the viewport
            // Ray ray = Camera.main.ViewportPointToRay(new Vector3 (0.5f, 0.5f, 0));

            if (_currentFireRate > _maxFireRate)
            {
                _currentFireRate = 0f;
                Ray ray = new Ray(_firePoint.position, _firePoint.forward);

                if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, _layerMask))
                {
                    if (raycastHit.collider != null)
                    {
                        Debug.Log(raycastHit.collider);
                    }
                }
            }
        }
    }
}