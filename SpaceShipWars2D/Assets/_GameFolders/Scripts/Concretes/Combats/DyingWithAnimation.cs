using System.Collections;
using SpaceShipWars2D.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWars2D.Combats
{
    public class DyingWithAnimation : IDying
    {
        readonly Animator _animator;
        readonly GameObject _tailObject;
        readonly GameObject _mainGameObject;
        readonly IDyingStats _dyingStats;

        public bool IsDead { get; private set; }

        public DyingWithAnimation(DyingDataEntity entity)
        {
            _animator = entity.Animator;
            _mainGameObject = entity.MainGameObject;
            _tailObject = entity.TailObject;
            _dyingStats = entity.DyingStats;
        }

        public IEnumerator DyingProcessAsync()
        {
            IsDead = true;
            _tailObject.SetActive(false);
            _animator.SetTrigger("Dying");
            
            yield return new WaitForSeconds(_dyingStats.DyingDelayTime);
            
            GameObject.Destroy(_mainGameObject);
        }
    }

    public class DyingWithFxEffect : IDying
    {
        readonly GameObject _fxObject;
        readonly GameObject _tailObject;
        readonly GameObject _mainGameObject;
        readonly GameObject _bodyObject;
        readonly Collider2D _collider2D; 
        readonly IDyingStats _dyingStats;
        
        public bool IsDead { get; private set; }
        
        public DyingWithFxEffect(DyingDataEntity entity)
        {
            _fxObject = entity.FxObject;
            _tailObject = entity.TailObject;
            _mainGameObject = entity.MainGameObject;
            _dyingStats = entity.DyingStats;
            _bodyObject = entity.BodyObject;
            _collider2D = entity.Collider2D;
        }
        
        public IEnumerator DyingProcessAsync()
        {
            IsDead = true;
            _collider2D.enabled = false;
            _bodyObject.SetActive(false);
            _tailObject.SetActive(false);
            _fxObject.SetActive(true);
            yield return new WaitForSeconds(_dyingStats.DyingDelayTime);
            
            GameObject.Destroy(_mainGameObject);
        }
    }
    
    public struct DyingDataEntity
    {
        public GameObject MainGameObject { get; set; }
        public GameObject FxObject { get; set; }
        public GameObject TailObject { get; set; }
        public IDyingStats DyingStats { get; set; }
        public Animator Animator { get; set; }
        public GameObject BodyObject { get; set; }
        public Collider2D Collider2D { get; set; }
    }

    public interface IDying
    {
        bool IsDead { get; }
        IEnumerator DyingProcessAsync();
    }
}