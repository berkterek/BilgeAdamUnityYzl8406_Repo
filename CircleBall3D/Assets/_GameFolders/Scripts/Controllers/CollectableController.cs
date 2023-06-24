using UnityEngine;

namespace CircleBall3D.Controllers
{
    public class CollectableController : MonoBehaviour
    {
        [SerializeField] int _score = 1;
        [SerializeField] GameObject _fxObject;
        [SerializeField] GameObject _bodyObject;
        [SerializeField] Collider _collider;
        [SerializeField] AudioSource _audioSource;

        public event System.Action<int> OnCollected;
        public int Score => _score;

        void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                _collider.enabled = false;
                OnCollected?.Invoke(_score);
                _bodyObject.SetActive(false);
                _fxObject.SetActive(true);
                _audioSource.Play();
            }
        }
    }    
}