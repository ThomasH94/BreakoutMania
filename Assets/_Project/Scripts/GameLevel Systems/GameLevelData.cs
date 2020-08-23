using System;
using UnityEngine;

/// <summary>
/// TODO: Create a custom inspector that allows us to pick the bricks from the inspector
/// </summary>
[CreateAssetMenu(menuName = "Scriptable Objects/Game Level Data", fileName = "New Level Data")]
public class GameLevelData : ScriptableObject
{
    public BrickInfo[] levelBricks;
    
}

[Serializable]
public class BrickInfo
{
    public BrickData BrickData;
    public Vector2 Position; 
}