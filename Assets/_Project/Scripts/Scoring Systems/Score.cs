using TMPro;
using UnityEngine;

namespace BrickBreak.Scoring
{
    public class Score : MonoBehaviour
    {
        private int _currentScore;

        public int CurrentScore
        {
            get => _currentScore;
            set
            {
                _currentScore = value;
                UpdateScoreText();
            }
        }

        [SerializeField] private TextMeshProUGUI scoreText;

        private void Start()
        {
            SetupScore();
            UpdateScoreText();
        }

        private void SetupScore()
        {
            if (scoreText == null)
            {
                scoreText = GetComponent<TextMeshProUGUI>();
            }
        }

        private void UpdateScoreText()
        {
            // Should do an animation...
            scoreText.text = "Score: " + _currentScore.ToString("0000000");
        }
    }
}