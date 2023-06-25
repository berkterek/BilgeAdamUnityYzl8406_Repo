using UnityEngine;

namespace SpaceShipWars2D.Managers
{
    public class GameManager : MonoBehaviour
    {
        void Awake()
        {
            Application.targetFrameRate = 60;
        }
    }    
}

