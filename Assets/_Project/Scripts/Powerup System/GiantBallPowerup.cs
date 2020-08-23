using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantBallPowerup : Powerup
{
    public void OnCollect()
    {
        Debug.Log("Your ball is now HUGE");
    }
}
