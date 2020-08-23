using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapBallPowerup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.AddComponent<SnapBall>();
    }
}