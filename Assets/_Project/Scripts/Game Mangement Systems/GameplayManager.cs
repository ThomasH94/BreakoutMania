using System;
using System.Collections;
using BrickBreak.EventManagement;
using BrickBreak.Singletons;
using BrickBreak.UI;
using BrickBreak.Utility;
using UnityEngine;

namespace BrickBreak.GameManagement
{
    /// <summary>
    /// This class is responsible for managing parts of any "World" scene
    /// This class will also call for a save after each successful level completion 
    /// </summary>
    public class GameplayManager : Singleton<GameplayManager>
    {
        public static event Action OnLevelCompleted;

        private void Start()
        {
            TimeManipulator.SetTimescale(1);
        }

        [ContextMenu("Check the time")]
        private void TimeChecker()
        {
            Debug.Log("Time scale is" + Time.timeScale);
        }


        // After completing a level, always call the OnLevelCompleted event, and change the results screen
        // behavior based on the level results - win/lose
        [ContextMenu("Level Complete")]
        public void LevelCompleted(bool success)
        {
            TimeManipulator.PauseTime();
            StartCoroutine(LevelCompleteRoutine(success));
        }

        private IEnumerator LevelCompleteRoutine(bool success)
        {
            yield return SceneController.Instance.LoadSceneAdditiveRoutine("Results");
            OnLevelCompleted?.Invoke();

            if (success)
            {
                EventManager.TriggerEvent("Level Success");
                UpdateLevelData();
                SaveGameManager.Instance.SaveGameDataWithJSON();
            }
            else
            {
                EventManager.TriggerEvent("Level Failed");
            }
        }

        private void UpdateLevelData()
        {
            int levelIndex = SceneController.Instance.currentLevelIndex;
            if (ScoreController.Instance.CalculateTotalScore() >
                SceneController.Instance.allLevelData[levelIndex].highScore)
            {
                SceneController.Instance.allLevelData[levelIndex].highScore =
                    ScoreController.Instance.CalculateTotalScore();
            }

            if (TimerManager.Instance.CurrentTime >
                SceneController.Instance.allLevelData[levelIndex].levelCompletedTime)
            {
                SceneController.Instance.allLevelData[levelIndex].levelCompletedTime =
                    TimerManager.Instance.CurrentTime;
            }

            // Last level, no more to unlock
            if (levelIndex + 1 > SceneController.Instance.allLevelData.Length - 1)
                return;

            if (SceneController.Instance.allLevelData[levelIndex + 1] != null)
            {
                Debug.Log(levelIndex + "is the level index");
                SceneController.Instance.allLevelData[levelIndex + 1].isUnlocked = true;
            }
        }
    }
}