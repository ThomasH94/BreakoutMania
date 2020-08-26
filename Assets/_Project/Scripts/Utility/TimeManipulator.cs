using UnityEngine;

namespace BrickBreak.Utility
{
    public static class TimeManipulator
    {
        [ContextMenu("Pause Time")]
        public static void PauseTime()
        {
            Time.timeScale = 0;
        }

        public static void SetTimescale(float timeToSet = 1)
        {
            Time.timeScale = timeToSet;
        }

    }
}