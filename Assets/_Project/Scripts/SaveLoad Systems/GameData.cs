using System.Collections.Generic;
using BrickBreak.Data;
using UnityEngine;

namespace BrickBreak.GameManagement.GameData
{

    /// <summary>
    /// The purpose of this class is store store ALL of our defined Game Data that will be saved and loaded
    /// with the SaveGameManager
    /// The current approach is using the User Profiles and manipulating the data within those profiles
    /// </summary>
    [CreateAssetMenu(fileName = "New Game Data", menuName = "Scriptable Objects/Game Data")]
    public class GameData : ScriptableObject
    {
        public SaveData SaveData = new SaveData();

        public List<GameLevelData> allGameLevels;

        private void OnEnable()
        {
            for (int i = 0; i < allGameLevels.Count; i++)
            {
                SaveData.unlockedLevels.Add(allGameLevels[i].isUnlocked);
                SaveData.highScores.Add(allGameLevels[i].highScore);
                SaveData.levelCompletedTimes.Add(allGameLevels[i].levelCompletedTime);
            }
        }

        public void ResetSaveData()
        {
            // Don't change level 1
            for (int i = 1; i < allGameLevels.Count; i++)
            {
                SaveData.highScores[i] = 0;
                SaveData.unlockedLevels[i] = false;
                SaveData.levelCompletedTimes[i] = 0;
            }
        }
    }

    public class SaveData
    {
        public List<bool> unlockedLevels = new List<bool>();
        public List<int> highScores = new List<int>();
        public List<float> levelCompletedTimes = new List<float>();
    }
}