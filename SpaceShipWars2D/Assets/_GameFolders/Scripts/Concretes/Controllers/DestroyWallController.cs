using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipWars2D.Controllers
{
    public class DestroyWallController : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
        }
    }    
}