using BrickBreak.Data.Collectables;
using UnityEngine;

//TODO: Remove - Collectables cover all the bases here..
namespace BrickBreak.Data
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Powerup Data", fileName = "New Powerup Data")]
    public class PowerupData : CollectableData
    {
        private GameObject powerupPrefab;
    }
}