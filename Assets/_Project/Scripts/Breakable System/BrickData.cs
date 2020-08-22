using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallType
{
    Main,    // Used to check which ball to track in the case of Mult-Ball
    Bouncy,
    Huge,
    Clone
}

[CreateAssetMenu(menuName = "Scriptable Objects/Brick Data", fileName = "New Brick Data")]
public class BrickData : ScriptableObject
{
    public int Health;
    public Sprite brickSprite;
    public Color brickColor;
    public Sprite[] crumbleSprites;
    public int scoreAmount;
    public BallType ballType;
}