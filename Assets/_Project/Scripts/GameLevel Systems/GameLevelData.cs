using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Brick Data", fileName = "New Brick Data")]
public class GameLevelData : ScriptableObject
{
    public BrickData[] levelBricks;
    
}
