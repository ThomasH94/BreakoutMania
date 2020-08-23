using System;
using System.Collections;
using System.Collections.Generic;
using BrickBreak.Singletons;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LivesManager : Singleton<LivesManager>
{
    [SerializeField] private TextMeshProUGUI livesText = null; 
    public int Lives
    {
        get;
        private set;
    }
    
    [SerializeField] private SceneController _sceneController;

    private void Start()
    {
        SetLives();
    }

    private void OnEnable()
    {
        EventManager.StartListening("Lost Life", UpdateLives);
    }

    private void OnDisable()
    {
        EventManager.StopListening("Lost Life", UpdateLives);
    }

    private void SetLives()
    {
        livesText.text = $"Lives: {Lives.ToString()}";
    }

    // Lives will always have a default amount sent in based on the levels objective to add
    // an extra layer of challenge with no way to gain additional lives
    private void UpdateLives()
    {
        Lives--;
        if (Lives == 0)
        {
            _sceneController.LoadAScene("MainMenu");
        }
        SetLives();
    }

}
