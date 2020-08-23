 using System.Collections;
using System.Collections.Generic;
using BrickBreak.Paddles;
using UnityEngine;

public abstract class Powerup : MonoBehaviour, ICollectable
{
    public abstract void OnCollect();

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PaddleController>())
        {
            OnCollect();
        }
    }
}
