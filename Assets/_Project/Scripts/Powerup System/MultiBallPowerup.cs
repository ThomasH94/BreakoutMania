using System.Linq;
using BrickBreak.Ball;
using BrickBreak.Data;
using BrickBreak.GameManagement;
using UnityEngine;

namespace BrickBreak.Collectibles
{
    public class MultiBallPowerup : Powerup
    {
        [SerializeField] private BallData multiBallData = null;

        protected override void ApplyPowerup()
        {
            if (BallManager.Instance == null)
            {
                Debug.LogError("<color=redERROR! No BallManager available..powerup failed..</color>");
                return;
            }
            
            foreach (BallController ball in BallManager.Instance.AllBalls.ToList())
            {

                BallManager.Instance.SpawnBalls((Vector2) ball.gameObject.transform.position, 2,
                    multiBallData);
            }

            base.ApplyPowerup();
        }
    }
}