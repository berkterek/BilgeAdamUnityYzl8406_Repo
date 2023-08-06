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

        int _nextSceneIndex;

        void Awake()
        {
            Singleton();
            Application.targetFrameRate = 60;
            _levelLastPoints = new Dictionary<int, Vector3>();
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
            int currentIndex = _nextSceneIndex;
            if (_levelLastPoints.ContainsKey(currentIndex))
            {
                _levelLastPoints[_nextSceneIndex] = doorSaveData.Point;
            }
            else
            {
                _levelLastPoints.Add(_nextSceneIndex, doorSaveData.Point);
            }

            _nextSceneIndex += doorSaveData.LevelIncreaseData;

            StartCoroutine(LoadSceneWithIndexAsync(_nextSceneIndex, currentIndex, doorSaveData.LevelName));
        }

        IEnumerator LoadSceneWithIndexAsync(int nextIndex, int currentIndex, string levelName)
        {
            yield return SceneManager.UnloadSceneAsync(currentIndex);
            yield return SceneManager.LoadSceneAsync(nextIndex, LoadSceneMode.Additive);
            
            var scene = SceneManager.GetSceneByName(levelName);
            yield return SceneManager.SetActiveScene(scene);

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
                    if (!doorController.CanEnter) continue;

                    Vector3 point = doorController.Point;
                    playerController.transform.position = point;

                    if (_levelLastPoints.ContainsKey(nextIndex))
                    {
                        _levelLastPoints[nextIndex] = point;
                    }
                    else
                    {
                        _levelLastPoints.Add(nextIndex, point);    
                    }
                    
                }
            }
        }

        public void StartGame()
        {
            Debug.Log(nameof(StartGame));
            StartCoroutine(StartGameAsync());
        }

        private IEnumerator StartGameAsync()
        {
            yield return SceneManager.LoadSceneAsync("Level_1", LoadSceneMode.Additive);
            yield return SceneManager.UnloadSceneAsync("Menu");
            yield return SceneManager.SetActiveScene(SceneManager.GetSceneByName("Level_1"));
            yield return SceneManager.LoadSceneAsync("GameUi", LoadSceneMode.Additive);
        }

        public void ExitGame()
        {
            Application.Quit();
            Debug.Log(nameof(Application.Quit));
        }

        public void ReturnMenu()
        {
            SceneManager.LoadScene("Menu");
        }

        public void PlayAgain()
        {
            ReturnMenu();
            StartCoroutine(StartGameAsync());
        }
    }

    public struct DoorSendData
    {
        public int LevelIncreaseData { get; set; }
        public Vector3 Point { get; set; }
        public string LevelName { get; set; }
    }
}