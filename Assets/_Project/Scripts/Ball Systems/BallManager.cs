using System;
using System.Collections.Generic;
using BrickBreak.Ball;
using BrickBreak.Paddles;
using BrickBreak.Singletons;
using Unity.Mathematics;
using UnityEngine;

public class BallManager : Singleton<BallManager>
{
    public List<BallController> AllBalls { get; set; }
    private BallController _defaultBall;
    [SerializeField] private BallController ballPrefab;
    private Rigidbody2D _defaultBallRigidBody;
    public Action<Vector2> getPaddlePosition; 
    

    private void Start()
    {
        RespawnBall();
    }

    private void OnEnable()
    {
        BallController.OnBallDestory += RemoveBall;
    }
    
    private void OnDisable()
    {
        BallController.OnBallDestory -= RemoveBall;
    }

    private void RespawnBall()
    {
        float yOffset = 0.16f;
        Vector2 paddlePosition = PaddleController.Instance.transform.position;
        Vector2 ballStartPosition = new Vector2(paddlePosition.x,paddlePosition.y + yOffset);    // Use the paddles position and move up slightly

        // Create and setup ball if we don't have one
        if (_defaultBall == null)
        {
            _defaultBall = Instantiate(ballPrefab, Vector2.zero, Quaternion.identity);
            _defaultBallRigidBody = _defaultBall.GetComponent<Rigidbody2D>();
            
            // Add it to the list of balls, needed for multi-ball
            AllBalls = new List<BallController>() {_defaultBall};
        }

        _defaultBall.transform.position = ballStartPosition;
        _defaultBall.transform.parent = PaddleController.Instance.transform;
        _defaultBall.SetBallToServe();
    }

    private void AddBall()
    {
        //TODO: Used for Multi-Ball Power Up
    }

    public void RemoveBall(BallController ballToRemove)
    {
        AllBalls.Remove(ballToRemove);
        if (AllBalls.Count <= 0)
        {
            _defaultBall = null;
            
            EventManager.TriggerEvent("Lost Life");
            if (LivesManager.Instance.Lives > 0)
            {
                RespawnBall();
            }
        }
    }
}