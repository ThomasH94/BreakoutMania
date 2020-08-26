using System;
using System.Collections;
using BrickBreak.Data;
using BrickBreak.Singletons;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BrickBreak.GameManagement
{
    /// <summary>
    /// This class will hold a reference to all of the game level datas so we can load into the next gamelevel data
    /// and keep track of which level has been completed so we can save it's results
    /// </summary>
    public class SceneController : Singleton<SceneController>
    {

        public GameLevelData[] allLevelData;
        public int currentLevelIndex;

        public static event Action OnLevelWasLoaded;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
            currentLevelIndex = 0;
        }


        [ContextMenu("Reset Level Data")]
        private void ResetLevelData()
        {
            for (int i = 1; i < allLevelData.Length; i++)
            {
                allLevelData[i].ResetLevelData();
            }
        }

        [ContextMenu("Reload Scene")]
        public void ReloadScene()
        {
            SceneManager.LoadScene(allLevelData[currentLevelIndex].name);
            OnLevelWasLoaded?.Invoke();
        }

        public void LoadNextLevel()
        {
            if (currentLevelIndex == 14)
            {
                LoadScene("WorldMap");
                return;
            }

            currentLevelIndex++;
            LoadScene(allLevelData[currentLevelIndex].name);

            OnLevelWasLoaded?.Invoke();
        }

        public void LoadGameplayScene(string levelToLoad, GameLevelData data)
        {
            SceneManager.LoadScene(levelToLoad);
            currentLevelIndex = data.levelID;
            OnLevelWasLoaded?.Invoke();
        }

        public void LoadScene(string levelToLoad)
        {
            SceneManager.LoadScene(levelToLoad);
            OnLevelWasLoaded?.Invoke();
        }


        public IEnumerator LoadSceneAdditiveRoutine(string levelToLoad)
        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad, LoadSceneMode.Additive);
            Scene sceneToLoad = SceneManager.GetSceneByName(levelToLoad);
            yield return loadOperation;
            SceneManager.SetActiveScene(sceneToLoad);
        }
        
    }
}