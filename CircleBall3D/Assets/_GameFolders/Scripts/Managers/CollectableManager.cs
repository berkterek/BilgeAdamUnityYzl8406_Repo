using System;
using CircleBall3D.Controllers;
using UnityEngine;

namespace CircleBall3D.Managers
{
    public class CollectableManager : MonoBehaviour
    {
        [SerializeField] CollectableController[] _collectableControllers;
        [SerializeField] int _maxScore;
        [SerializeField] int _currentScore;

        void Awake()
        {
            //GetComponent ayni GameObject uzerindeki Component'i varsa cekmeye calisir.
            //GetComponentInChildren ayni GameObject veya Child GameObject uzerinden Component cekmeye calisr
            //s takisi coguldur ve bize array yani collection yapisi doner
            _collectableControllers = GetComponentsInChildren<CollectableController>();
        }

        void OnEnable()
        {
            foreach (var collectable in _collectableControllers)
            {
                collectable.OnCollected += HandleOnCollected;
                _maxScore += collectable.Score;
            }
        }

        void OnDisable()
        {
            foreach (var collectable in _collectableControllers)
            {
                collectable.OnCollected -= HandleOnCollected;
            }
        }
        
        void HandleOnCollected(int score)
        {
            _currentScore += score;

            if (_currentScore >= _maxScore)
            {
                GameManager.Instance.LevelComplete();
            }
        }
    }    
}

