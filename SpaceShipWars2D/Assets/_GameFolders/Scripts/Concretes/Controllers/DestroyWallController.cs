using SpaceShipWars2D.Managers;
using UnityEngine;

namespace SpaceShipWars2D.Controllers
{
    public class DestroyWallController : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out LaserController laserController))
            {
                LaserPoolManager.Instance.SetLaserToPool(laserController);
            }
            else
            {
                Destroy(other.gameObject);    
            }
        }
    }    
}