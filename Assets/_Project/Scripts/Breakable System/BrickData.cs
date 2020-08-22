using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Brick Data", fileName = "New Brick Data")]
public class BrickData : ScriptableObject
{
    public int Health;
    public Sprite brickSprite;
    public Color brickColor;
    public Sprite[] crumbleSprites;
    public int scoreAmount;
    public PhysicsMaterial2D brickPhysicsMaterial;
}