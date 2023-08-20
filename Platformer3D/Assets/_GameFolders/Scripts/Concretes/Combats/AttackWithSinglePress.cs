using Platformer3D.Sample2.Controllers;
using UnityEngine;

namespace Platformer3D.Sample2.Combats
{
    public class AttackWithSinglePress : IAttack
    {
        readonly RobotKyleController _robotKyleController;
        
        public AttackWithSinglePress(RobotKyleController robotKyleController)
        {
            _robotKyleController = robotKyleController;
        }

        public void Tick()
        {
            if (!_robotKyleController.InputReader.CanFireSinglePress) return;
            
            Ray ray = Camera.main.ViewportPointToRay(new Vector3 (0.5f, 0.5f, 0));
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, _robotKyleController.LayerMask))
            {
                if (raycastHit.collider != null)
                {
                    Debug.Log(raycastHit.collider);
                    // raycastHit.collider.GetComponent<Enemy>().TakeDamage(_robotKyleController.Weapon.Damage);
                }
            }
        }
    }

    public class AttackWithPressContinue : IAttack
    {
        readonly RobotKyleController _robotKyleController;
        float _currentFireRate = 0f;
        float _maxFireRate = 0.3f;
        
        public AttackWithPressContinue(RobotKyleController robotKyleController)
        {
            _robotKyleController = robotKyleController;
        }

        public void Tick()
        {
            if (!_robotKyleController.InputReader.CanFireContinue) return;
            
            _currentFireRate += Time.deltaTime;

            if (_currentFireRate > _maxFireRate)
            {
                _currentFireRate = 0f;
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, _robotKyleController.LayerMask))
                {
                    if (raycastHit.collider != null)
                    {
                        Debug.Log(raycastHit.collider);
                    }
                }
            }
        }
    }

    public interface IAttack
    {
        void Tick();
    }
}