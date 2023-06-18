using UnityEngine;

namespace CircleBall3D.Controllers
{
    public class CollectableController : MonoBehaviour
    {
        [SerializeField] int _score = 1;

        public event System.Action<int> OnCollected;
        public int Score => _score;

        void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                OnCollected?.Invoke(_score);
                gameObject.SetActive(false);
            }
        }
    }    
}