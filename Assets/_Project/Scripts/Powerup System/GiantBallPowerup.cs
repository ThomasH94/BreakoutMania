using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantBallPowerup : Powerup
{
    public override void OnCollect()
    {
        Debug.Log("Your ball is now HUGE");
    }
}
