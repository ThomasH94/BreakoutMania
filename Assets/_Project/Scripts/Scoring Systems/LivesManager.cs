using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LivesManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesText = null;
    [SerializeField] private int lives = 0;
    [SerializeField] private SceneController _sceneController;

    private void Start()
    {
        SetLives();
    }

    private void OnEnable()
    {
        EventManager.StartListening("Ball Missed", UpdateLives);
    }

    private void OnDisable()
    {
        EventManager.StopListening("Ball Missed", UpdateLives);
    }

    private void SetLives()
    {
        livesText.text = $"Lives: {lives.ToString()}";
    }

    // Lives will always have a default amount sent in based on the levels objective to add
    // an extra layer of challenge with no way to gain additional lives
    private void UpdateLives()
    {
        lives--;
        if (lives == 0)
        {
            _sceneController.LoadAScene("MainMenu");
        }
        SetLives();
    }

}
