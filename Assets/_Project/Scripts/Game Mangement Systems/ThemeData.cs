using UnityEngine;

namespace BrickBreak.Data
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Theme Data", fileName = "New Theme Data")]
    public class ThemeData : ScriptableObject
    {
        public Sprite ballSprite;
        public Sprite paddleSprite;
        public Sprite levelBackground;
        public Sprite brickSprite;
    }
}