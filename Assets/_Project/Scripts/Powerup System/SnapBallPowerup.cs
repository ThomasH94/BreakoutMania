using BrickBreak.Collectibles;
using BrickBreak.Paddles;
using UnityEngine;

namespace BrickBreak.Powerups
{

    public class SnapBallPowerup : Powerup
    {
        public GameObject ballDetector;
        public GameObject powerupUI;

        protected override void ApplyPowerup()
        {
            //Instantiate the powerupUI to the Powerup Canvas
            base.ApplyPowerup();
        }

        protected new void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<PaddleController>())
            {
                // Destroy this powerup if we already have it
                SnapBall snapBall = other.GetComponentInChildren<SnapBall>();
                if (snapBall)
                {
                    snapBall.UpdateSnapCount(3);
                }
                else
                {
                    GameObject detector = Instantiate(ballDetector, other.transform.position, Quaternion.identity);
                    detector.transform.parent = other.transform;
                }
            }
        }
    }
}