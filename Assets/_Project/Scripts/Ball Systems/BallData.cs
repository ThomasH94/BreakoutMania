using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Ball Data", fileName = "New Ball Data")]
public class BallData : ScriptableObject
{
    public float moveSpeed = 100.0f;
    public Sprite ballSprite;
    
}
