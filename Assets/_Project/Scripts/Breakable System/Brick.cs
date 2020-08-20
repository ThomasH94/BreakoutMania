using System.Collections;
using System.Collections.Generic;
using BrickBreak.Breakable;
using UnityEngine;

public class Brick : MonoBehaviour, IDamagable
{
    public int Health { get; set; }

    public void TakeDamage()
    {
        Health--;
        if (Health <= 0)
        {
            // Destroy and add points -- play animation and sounds on hit
        }
    }
}
