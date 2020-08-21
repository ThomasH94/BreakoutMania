using System;
using System.Collections;
using System.Collections.Generic;
using BrickBreak.Breakable;
using UnityEngine;

public class Brick : MonoBehaviour, IDamagable
{
    // Could have brick types that give you points, light up, and maybe stuff like glass that subtracts points

    #region Events


    #endregion

    public BrickManager currentBrickManager = null;
    

    public BrickData _brickData;
    public int Health { get; set; }

    public void SetupBrick(BrickManager brickManager)
    {
        //Health = _brickData.Health;
        Health = 1;
        currentBrickManager = brickManager;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<BallController>())
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        Health--;
        if (Health <= 0)
        {
            // Destroy and add points -- play animation and sounds on hit
            Destroy(gameObject);
        }
    }
}
