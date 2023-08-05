using System.Collections;
using System.Collections.Generic;
using Platformer2D.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer2D.Managers
{
    public class GameManager : MonoBehaviour
    {
        Dictionary<int, Vector3> _levelLastPoints;

        public static GameManager Instance { get; private set; }

        int _currentSceneIndex;
        
        void Awake()
        {
            Singleton();
            Application.targetFrameRate = 60;
            _levelLastPoints = new Dictionary<int, Vector3>();
        }

        void Start()
        {
            _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }

        private void Singleton()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void LevelChangedProcess(DoorSendData doorSaveData)
        {
            if (_levelLastPoints.ContainsKey(_currentSceneIndex))
            {
                _levelLastPoints[_currentSceneIndex] = doorSaveData.Point;
            }
            else
            {
                _levelLastPoints.Add(_currentSceneIndex, doorSaveData.Point);    
            }
            
            _currentSceneIndex += doorSaveData.LevelIncreaseData;
            
            StartCoroutine(LoadSceneWithIndexAsync(_currentSceneIndex));
        }

        IEnumerator LoadSceneWithIndexAsync(int nextIndex)
        {
            yield return SceneManager.LoadSceneAsync(nextIndex);

            PlayerController playerController = null;
            while (playerController == null)
            {
                playerController = FindObjectOfType<PlayerController>();
            }

            if (_levelLastPoints.ContainsKey(nextIndex))
            {
                playerController.transform.position = _levelLastPoints[nextIndex];
            }
            else
            {
                var doorControllers = FindObjectsOfType<DoorController>();

                foreach (var doorController in doorControllers)
                {
                    if(!doorController.CanEnter) continue;

                    Vector3 point = doorController.Point;
                    playerController.transform.position = point;
                    _levelLastPoints.Add(nextIndex, point);
                }
            }
        }
    }    
    
    public struct DoorSendData
    {
        public int LevelIncreaseData { get; set; }
        public Vector3 Point { get; set; }
    }
}

