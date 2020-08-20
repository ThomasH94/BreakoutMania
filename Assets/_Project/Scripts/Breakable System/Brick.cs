using System;
using System.Collections;
using System.Collections.Generic;
using BrickBreak.Breakable;
using UnityEngine;

public class Brick : MonoBehaviour, IDamagable
{
    // Could have brick types that give you points, light up, and maybe stuff like glass that subtracts points
    public event Action OnBrickDestroyed;
    public int Health { get; set; }

    public void TakeDamage()
    {
        Health--;
        if (Health <= 0)
        {
            // Destroy and add points -- play animation and sounds on hit
            OnBrickDestroyed.Invoke();
        }
    }
}
