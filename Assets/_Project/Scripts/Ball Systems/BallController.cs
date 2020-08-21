using System;
using System.Collections;
using System.Collections.Generic;
using BrickBreak.Paddles;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private BallData _ballData = null;
    private float moveSpeed;

    [SerializeField] private Rigidbody2D ballRigidBody = null;
    [SerializeField] private bool isNegative;
    private bool gameStarted = false;


    void Start()
    {
        SetupBall();
        ballRigidBody.AddForce(Vector2.up * 200);
    }

    private void SetupBall()
    {
        // Used for getting components, setting graphics, and more
        moveSpeed = _ballData.moveSpeed;
    }
    
    private void FixedUpdate()
    {
        //ballRigidBody.velocity = Vector2.up * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collidedObj)
    {
        PaddleController paddle = collidedObj.gameObject.GetComponent<PaddleController>();
        if (paddle)
        {
            moveSpeed = Mathf.Abs(moveSpeed);
            float hitForce = HitFactor(transform.position, 
                collidedObj.transform.position, collidedObj.collider.bounds.size.x);
            Debug.Log($"Hitforce: {hitForce}");
            
            Vector2 hitDirection = new Vector2(hitForce, 1).normalized;
            ballRigidBody.velocity = hitDirection * moveSpeed;
        }
    }

    /// <summary>
    /// When the ball hits the paddle, we need to decide where to send it based on the angle it hit from
    /// We can check the x position of the ball and the x position of the paddle
    /// From there, subtract them and divide that by the width of the paddle (which can grow with power ups)
    /// </summary>
    /// <param name="ballPosition"></param>
    /// <param name="paddlePosition"></param>
    /// <param name="paddleWidth"></param>
    /// <returns></returns>
    private float HitFactor(Vector2 ballPosition, Vector2 paddlePosition, float paddleWidth)
    {
        // Visual example:
        // || -0.5     0     0.5     <- x Position after subtraction
        // || ===================  <- Paddle
        return (ballPosition.x - paddlePosition.x) / paddleWidth;
    }
}
