using System;
using System.Collections;
using System.Collections.Generic;
using BrickBreak.Ball;
using BrickBreak.Singletons;
using UnityEngine;

public class GameplayManager : Singleton<GameplayManager>
{
    private void OnEnable()
    {
        EventManager.StartListening("Ball Missed",OnBallMissed);   
    }

    private void OnBallMissed()
    {

    }

    private void OnDisable()
    {
        EventManager.StopListening("Ball Missed",OnBallMissed);
    }
    
    //TODO: Instead of objectives, reward a high score based on this formula:
    //Current Score + Lives someMultiplier + TimeRemaining someMultiplier + somePowerUpMultiplier + friendlyBlocks;
    //GameManager can be notified OnLevelComplete from BrickManager and calculate score from there
    // Removes the need for an Objective Manager and Objectives
}
