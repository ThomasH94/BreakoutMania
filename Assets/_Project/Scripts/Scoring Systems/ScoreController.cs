using System;
using BrickBreak.Collectables;
using BrickBreak.Singletons;
using UnityEngine;

public class ScoreController : Singleton<ScoreController>
{
    [SerializeField] private Score score = null;

    private void OnEnable()
    {
        Collectable.OnAnyCollectable += UpdateScore;
    }
    
    private void OnDisable()
    {
        Collectable.OnAnyCollectable -= UpdateScore;
    }

    public void UpdateScore(int scoreAmount)
    {
        score.CurrentScore += scoreAmount;
    }

}