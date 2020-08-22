﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<BallController>())
        {
            EventManager.TriggerEvent("Ball Missed");
        }
    }
}