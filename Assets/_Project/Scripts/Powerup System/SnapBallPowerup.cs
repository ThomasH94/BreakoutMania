using BrickBreak.Collectables;
using BrickBreak.Paddles;
using Unity.Mathematics;
using UnityEngine;

public class SnapBallPowerup : Powerup
{
    public GameObject ballDetector;
    
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PaddleController>())
        {
            // Destroy this powerup if we already have it
            GameObject detector = Instantiate(ballDetector, other.transform.position, Quaternion.identity);
            detector.transform.parent = other.transform;
        }
    }
}