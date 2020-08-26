using BrickBreak.Data.Collectibles;
using UnityEngine;

namespace BrickBreak.Data
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Powerup Data", fileName = "New Powerup Data")]
    public class PowerupData : CollectibleData
    {
        private GameObject powerupPrefab;
    }
}