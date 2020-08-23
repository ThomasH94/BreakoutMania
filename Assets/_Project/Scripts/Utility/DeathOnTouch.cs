using BrickBreak.Ball;
using UnityEngine;

public class DeathOnTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        BallController ballToRemove = other.GetComponent<BallController>();
        if (ballToRemove)
        {
            ballToRemove.DestroyBall();
        }
    }
}