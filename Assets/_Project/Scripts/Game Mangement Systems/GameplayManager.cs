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
}
