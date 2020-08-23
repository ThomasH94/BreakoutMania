using BrickBreak.Data.Collectables;
using UnityEngine;

namespace BrickBreak.Data
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Powerup Data", fileName = "New Powerup Data")]
    public class PowerupData : CollectableData
    {
        public string powerupName;
    }
}