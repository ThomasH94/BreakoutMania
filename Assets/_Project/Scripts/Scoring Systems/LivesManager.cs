using BrickBreak.EventManagement;
using BrickBreak.GameManagement;
using BrickBreak.Singletons;
using TMPro;
using UnityEngine;

namespace BrickBreak.GameManagement
{

    public class LivesManager : Singleton<LivesManager>
    {
        [SerializeField] private TextMeshProUGUI livesText = null;
        [SerializeField] private bool infiniteLives = false;
        public int Lives { get; private set; }

        public int startingLives = 3;

        [SerializeField] private SceneController _sceneController;

        private void Start()
        {
            Lives = startingLives;
            UpdateLivesText();
        }

        private void OnEnable()
        {
            EventManager.StartListening("Lose Life", LoseLife);
        }

        private void OnDisable()
        {
            EventManager.StopListening("Lose Life", LoseLife);
        }

        private void UpdateLivesText()
        {
            livesText.text = infiniteLives ? "∞" : $"Lives: {Lives.ToString()}";
        }

        // Lives will always have a default amount sent in based on the levels objective to add
        // an extra layer of challenge with no way to gain additional lives
        private void LoseLife()
        {
            if (infiniteLives)
                return;

            Lives--;
            if (Lives <= 0)
            {
                GameplayManager.Instance.LevelCompleted(false);
            }
            else
            {
                UpdateLivesText();
            }

        }

        public void GainLives(int amount)
        {
            Lives += amount;
            UpdateLivesText();
        }
    }
}