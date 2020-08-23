using System;
using System.Collections;
using System.Collections.Generic;
using BrickBreak.Data;
using UnityEngine;

public class SnapBall : MonoBehaviour
{
    private BallDetector _ballDetector;

    private void Start()
    {
        if (_ballDetector == null)
            _ballDetector = GetComponent<BallDetector>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Snap();
        }
    }

    public void Snap()
    {
        if (_ballDetector.ball)
        {
            BallManager.Instance.SnapBall(_ballDetector.ball);
        }
    }
}