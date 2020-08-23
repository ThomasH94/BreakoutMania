using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrickBreak.Data.Collectables
{

    [CreateAssetMenu(menuName = "Scriptable Objects/Collectable", fileName = "New Collectable Data")]
    public class CollectableData : DataObject
    {
        public int scoreAmount;
        public AudioClip collectSound;
    }
}