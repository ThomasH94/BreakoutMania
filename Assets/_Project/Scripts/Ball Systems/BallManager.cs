using System.Collections;
using System.Collections.Generic;
using BrickBreak.Ball;
using BrickBreak.Singletons;
using UnityEngine;

public class BallManager : Singleton<BallManager>
{
    public List<BallController> BallControllers { get; set; }

    private void Start()
    {
        InitBall();
    }

    private void InitBall()
    {
        Vector2 ballStartPosition = new Vector2(0,0);    // The Paddle should know this..
    }
}