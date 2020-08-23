﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BrickBreak.Ball;
using UnityEngine;

public class MultiBallPowerup : Powerup
{
    [SerializeField] private BallData multiBallData;
    protected override void ApplyPowerup()
    {
        float randomOffset = Random.Range(-0.3f, 0.3f);
        Vector2 positionOffset = new Vector2(randomOffset, randomOffset);
        foreach (BallController ball in BallManager.Instance.AllBalls.ToList())
        {
            BallManager.Instance.SpawnBalls((Vector2)ball.gameObject.transform.position + positionOffset, 2, multiBallData);
        }
    }
}
