using UnityEngine;

namespace BrickBreak.Data.Collectibles
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Collectable", fileName = "New Collectable Data")]
    public class CollectibleData : DataObject
    {
        public GameObject collectiblePrefab;
        public int scoreAmount;
        public AudioClip collectSound;
        public int collectibleWeight;
    }
}