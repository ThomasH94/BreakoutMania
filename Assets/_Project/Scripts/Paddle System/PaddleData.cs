using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Paddle Data", fileName = "New Paddle Data")]
public class PaddleData : ScriptableObject
{
    public float moveSpeed = 150.0f;
    public Sprite paddleSprite;
    public float paddleWidth;
}
