using SpaceShipWars2D.Abstracts.Combats;
using SpaceShipWars2D.Abstracts.Movements;
using SpaceShipWars2D.Combats;
using SpaceShipWars2D.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWars2D.Controllers
{
    public class EnemyController : MonoBehaviour,IEntityController
    {
        [SerializeField] EnemyStats _stats;
        
        IHealth _health;
        IFireHandler _fireHandler;
        IMover _mover;

        void Awake()
        {
            _fireHandler = new FireHandler(new FireData()
            {
                Transform = this.transform,
                AttackStats = _stats
            });
        }

        void Update()
        {
            //_mover.Tick(Vector3.zero);
            _fireHandler.Tick();
        }

        void FixedUpdate()
        {
            //_mover.FixedTick();
        }
    }
}

