using BrickBreak.Ball;
using BrickBreak.Collectables;
using BrickBreak.Paddles;
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
        else if(other.GetComponent<Collectable>())
        {
            Destroy(other);
        }
    }
}