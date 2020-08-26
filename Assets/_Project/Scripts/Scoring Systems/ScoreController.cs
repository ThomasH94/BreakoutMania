using BrickBreak.Collectibles;
using BrickBreak.GameManagement;
using BrickBreak.Scoring;
using BrickBreak.Singletons;

namespace BrickBreak.UI
{

    public class ScoreController : Singleton<ScoreController>
    {
        public Score score;

        #region Multipliers

        public int livesMultipler;
        public int powerupMultiplier;

        #endregion

        private void OnEnable()
        {
            Collectible.OnAnyCollectible += UpdateScore;
        }

        private void OnDisable()
        {
            Collectible.OnAnyCollectible -= UpdateScore;
        }

        public void UpdateScore(int scoreAmount)
        {
            score.CurrentScore += scoreAmount;
        }

        public int CalculateTotalScore()
        {
            int currentScore = score.CurrentScore;
            int livesBonusScore = LivesManager.Instance.Lives * livesMultipler;
            int activePowerupBonusScore = CollectibleManager.Instance.activePowerups.Count * powerupMultiplier;

            return currentScore + livesBonusScore + activePowerupBonusScore;

        }
    }
}