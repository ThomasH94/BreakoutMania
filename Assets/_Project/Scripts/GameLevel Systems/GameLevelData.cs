using UnityEngine;

namespace BrickBreak.Data
{

    /// <summary>
    /// Game level data serves as a way for designers to create levels by setting their brick amount, time limit, lives, and more
    /// Currently setup to load scenes with a matching name and save high scores
    /// This can be expanded upon as a way to have custom level generation
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Objects/Game Level Data", fileName = "New Level Data")]
    public class GameLevelData : DataObject
    {
        //public BrickInfo[] levelBricks;
        public int highScore;
        public bool isUnlocked;
        public float levelCompletedTime;
        public string levelCompletedTimeText;
        public string levelToLoad;
        public int brickCount;
        public int levelID;

        private void OnEnable()
        {
            DisplayCompleteTimeFormatted();
        }

        public void ResetLevelData()
        {
            highScore = 0;
            isUnlocked = false;
            levelCompletedTime = 0;
        }
        

        private void DisplayCompleteTimeFormatted()
        {
            float seconds = levelCompletedTime % 60;
            float minutes = levelCompletedTime / 60;
            levelCompletedTimeText =
                minutes.ToString() + ":" + seconds.ToString("00");
        }
    }
    
}