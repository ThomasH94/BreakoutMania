using System.Collections;
using System.Collections.Generic;
using BrickBreak.Collectibles;
using UnityEngine;

public class TimedPowerup : Powerup, ITimedDestroyable
{
    public float TimeBeforeDestroy { get; set; }
    [SerializeField] protected float startingTimeBeforeDestroy = 0; 

    protected override void ApplyPowerup()
    {
        base.ApplyPowerup();
        // Spawn the UI prefab that will go to the Powerup Canvas

    }

    
    public void DestroyAfterSetTime()
    {
        if (TimeBeforeDestroy <= 0)
        {
            OnDestroy();
        }
    }

    public void OnDestroy()
    {
        RemovePowerup();
    }
}
