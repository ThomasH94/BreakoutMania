using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        scoreText.text = "Score: " + _currentScore.ToString("000");
    }
}
