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

        public DyingWithAnimation(DyingAnimationDataEntity entity)
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

    public struct DyingAnimationDataEntity
    {
        public GameObject MainGameObject { get; set; }
        public GameObject TailObject { get; set; }
        public IDyingStats DyingStats { get; set; }
        public Animator Animator { get; set; }
    }

    public class DyingWithFxEffect 
    {
        public bool IsDead { get; }

        public DyingWithFxEffect()
        {
        }
    }

    public interface IDying
    {
        bool IsDead { get; }
        IEnumerator DyingProcessAsync();
    }
}