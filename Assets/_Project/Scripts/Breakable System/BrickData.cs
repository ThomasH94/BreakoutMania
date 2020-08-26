using UnityEngine;

namespace BrickBreak.Data
{

    [CreateAssetMenu(menuName = "Scriptable Objects/Brick Data", fileName = "New Brick Data")]
    public class BrickData : DataObject
    {
        [Range(0, 10)] // Change to a slider of some sort with the Custom Inspector
        public int Health;

        public Sprite brickSprite;
        public Color brickColor;
        public Sprite[] crumbleSprites;
        public int scoreAmount;
        public PhysicsMaterial2D brickPhysicsMaterial;
        public float spawnChance;
        public bool Indestructible = false;
    }
}