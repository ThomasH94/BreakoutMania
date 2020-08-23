using UnityEngine;

namespace BrickBreak.Data
{

    public abstract class DataObject : ScriptableObject
    {
        public string dataName;
        public string dataDescription;
    }
}