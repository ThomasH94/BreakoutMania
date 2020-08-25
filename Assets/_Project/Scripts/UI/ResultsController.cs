using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultsController : MonoBehaviour
{
    [SerializeField] private GameObject successPanel;
    [SerializeField] private GameObject failedPanel;

    #region Score
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private int currentScore;
    [SerializeField] private int highScore;
    #endregion

    private void OnEnable()
    {
        EventManager.StartListening("Level Success", OnLevelSuccess);
        EventManager.StartListening("Level Failed", OnLevelFailedHandler);
    }

    private void OnDisable()
    {
        EventManager.StopListening("Level Success", OnLevelSuccess);
        EventManager.StopListening("Level Failed", OnLevelFailedHandler);
    }

    public void OnLevelSuccess()
    {
        currentScore = ScoreController.Instance.score.CurrentScore;
        highScore = GameplayManager.Instance.sceneController.currentLevelData.highScore;

        scoreText.text = "Score: " + currentScore.ToString("0000000");
        highScoreText.text = "High Score: " + highScore.ToString("0000000");
    }

    // To be used with on level success
    private IEnumerator RackUpRoutine(int currentAmount, int amountToRackUpTo)
    {
        yield break;
    }

    // To be used when you want to skip racking up
    private void FinishResultsPresentation()
    {
        
    }

    public void OnLevelFailedHandler()
    {
        Debug.Log("Results show a LOSS");
    }
    
}
