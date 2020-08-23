using BrickBreak.Collectables;
using UnityEngine;

public class GiantBallPowerup : Powerup
{
    public void OnCollect()
    {
        Debug.Log("Your ball is now HUGE");
        // Tell the Ball Manager to enlarge the default ball if there is one - might not be if we have multi-ball...
        // or...we can have multiple huge balls...
    }
}