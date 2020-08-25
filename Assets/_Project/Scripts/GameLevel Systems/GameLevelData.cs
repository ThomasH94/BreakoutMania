using System;
using BrickBreak.Data.Brick;
using UnityEngine;

namespace BrickBreak.Data
{

    /// <summary>
    /// TODO: Create a custom inspector that allows us to pick the bricks from the inspector
    /// </summary>
    [CreateAssetMenu(menuName = "Scriptable Objects/Game Level Data", fileName = "New Level Data")]
    public class GameLevelData : DataObject
    {
        //public BrickInfo[] levelBricks;
        public int highScore;
        public bool isUnlocked;

    }

    [Serializable]
    public class BrickInfo
    {
        public BrickData BrickData;
        public Vector2 Position;
    }
}