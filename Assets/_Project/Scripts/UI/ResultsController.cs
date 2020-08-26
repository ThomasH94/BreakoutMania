using System;
using System.Collections;
using System.Collections.Generic;
using BrickBreak.Collectibles;
using BrickBreak.EventManagement;
using BrickBreak.GameManagement;
using TMPro;
using UnityEngine;

namespace BrickBreak.UI
{
    public class ResultsController : MonoBehaviour
    {
        [SerializeField] private GameObject successContainer = null;
        [SerializeField] private GameObject failedContainer = null;

        #region Scores

        [Header("Multipliers and Text")] [SerializeField]
        private TextMeshProUGUI scoreText = null;

        [SerializeField] private TextMeshProUGUI livesRemainingText = null;
        [SerializeField] private TextMeshProUGUI activePowerupsText = null;
        [SerializeField] private TextMeshProUGUI totalScoreText = null;
        [SerializeField] private TextMeshProUGUI highScoreText = null;
        [SerializeField] private TextMeshProUGUI newHighScoreText = null;

        private int _currentScore;
        private int _totalScore;
        private int _highScore;
        private float _currentTime;

        #endregion

        private void OnEnable()
        {
            EventManager.StartListening("Level Success", OnLevelSucceededHandler);
            EventManager.StartListening("Level Failed", OnLevelFailedHandler);
        }

        private void OnDisable()
        {
            EventManager.StopListening("Level Success", OnLevelSucceededHandler);
            EventManager.StopListening("Level Failed", OnLevelFailedHandler);
        }

        public void OnLevelSucceededHandler()
        {
            successContainer.SetActive(true);
            failedContainer.SetActive(false);
            int index = SceneController.Instance.currentLevelIndex;

            _currentScore = ScoreController.Instance.score.CurrentScore;
            _highScore = SceneController.Instance.allLevelData[index].highScore;
            _totalScore = ScoreController.Instance.CalculateTotalScore();
            _currentTime = TimerManager.Instance.CurrentTime;

            newHighScoreText.enabled = false;

            if (_currentScore > _highScore)
            {
                _highScore = _currentScore;
            }

            scoreText.text = "Score: ";
            StartCoroutine(RackUpRoutine(scoreText, _currentScore));

            livesRemainingText.text = "Lives Remaining: " + LivesManager.Instance.Lives  + " * " + ScoreController.Instance.livesMultipler;


            activePowerupsText.text = "Powerups Remaining: " + CollectibleManager.Instance.activePowerups.Count + " * " + ScoreController.Instance.powerupMultiplier;


            totalScoreText.text = "Total Score: ";
            StartCoroutine(RackUpRoutine(totalScoreText, ScoreController.Instance.CalculateTotalScore()));

            highScoreText.text = "High Score: ";
            if (_highScore > _totalScore)
            {
                StartCoroutine(RackUpRoutine(highScoreText, _highScore));
            }
            else
            {
                StartCoroutine(RackUpRoutine(highScoreText, _totalScore));
                newHighScoreText.enabled = true;
            }

        }

        // Takes a textmesh and "racks" it or rolls it up towards a desired value
        private IEnumerator RackUpRoutine(TextMeshProUGUI textToRack, int amountToRackTo, bool withPadding = true, int rackSpeed = 5)
        {

            WaitForSecondsRealtime presentationDelay = new WaitForSecondsRealtime(0.5f);
            yield return presentationDelay;

            string textValue = textToRack.text;
            int currentAmount = 0;
            
            while (currentAmount < amountToRackTo)
            {
                currentAmount += 1 * rackSpeed;

                string amountString;
                if (withPadding)
                {
                    amountString = currentAmount.ToString("0000000");
                }
                else
                {
                    amountString = currentAmount.ToString();
                }

                textToRack.text = textValue + amountString;
                yield return null;
            }
        }

        public void OnLevelFailedHandler()
        {
            successContainer.SetActive(false);
            failedContainer.SetActive(true);
        }
    }
}