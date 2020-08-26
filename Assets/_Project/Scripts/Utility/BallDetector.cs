using System;
using System.Collections;
using System.Collections.Generic;
using BrickBreak.Ball;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class BallDetector : MonoBehaviour
{
    public BallController ball;
    [SerializeField] private CircleCollider2D detectorCollider2D = null;
    [SerializeField] private float detectorRadius = 0;

    private void Start()
    {
        if(detectorCollider2D == null)
            detectorCollider2D = GetComponent<CircleCollider2D>();

        detectorCollider2D.isTrigger = true;
        detectorCollider2D.radius = detectorRadius;
    }

    // Capture a Ball so it can be snapped
    private void OnTriggerEnter2D(Collider2D other)
    {
        BallController capturedBall = other.gameObject.GetComponent<BallController>();
        if (capturedBall)
        {
            if (capturedBall._ballServed)
            {
                ball = capturedBall;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<BallController>() == ball)
        {
            ball = null;
        }
    }
}
