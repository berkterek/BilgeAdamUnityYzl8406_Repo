using UnityEngine;

namespace CircleBall3D.Controllers
{
    public class CollectableController : MonoBehaviour
    {
        [SerializeField] int _score = 1;

        void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.IncreaseScore(_score);
                Destroy(this.gameObject);
            }
        }
    }    
}