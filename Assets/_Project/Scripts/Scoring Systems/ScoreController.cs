using BrickBreak.Singletons;
using UnityEngine;

public class ScoreController : Singleton<ScoreController>
{
    [SerializeField] private Score score;

    private void UpdateScore(int scoreAmount)
    {
        score.CurrentScore += scoreAmount;
    }

}