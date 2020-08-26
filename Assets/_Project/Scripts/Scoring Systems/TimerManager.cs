using BrickBreak.Singletons;
using TMPro;
using UnityEngine;

namespace BrickBreak.UI
{
    /// <summary>
    /// This class takes an amount of time to start counting down from, and would stop when the level completes
    /// From there, the time remaining would be added to the score with a multiplier 
    /// </summary>
    public class TimerManager : Singleton<TimerManager>
    {
        public float CurrentTime;
        public float startingTime;

        [SerializeField] private TextMeshProUGUI timerText = null;
        private bool shouldCount = false;

        public void StartCountingDown()
        {
            if (!shouldCount)
                return;

            timerText.text = DisplayTimerAsTime();
            CurrentTime = startingTime;
            CurrentTime -= Time.deltaTime;
        }

        public string DisplayTimerAsTime()
        {
            float seconds = CurrentTime % 60;
            float minutes = CurrentTime / 60;

            return minutes.ToString() + ":" + seconds.ToString("00");
        }
    }
}