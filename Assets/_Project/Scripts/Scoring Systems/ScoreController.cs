using System;
using BrickBreak.Collectables;
using BrickBreak.Singletons;
using UnityEngine;

public class ScoreController : Singleton<ScoreController>
{
    public Score score;

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