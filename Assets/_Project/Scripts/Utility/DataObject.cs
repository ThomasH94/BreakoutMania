using UnityEngine;

namespace BrickBreak.Data
{

    /// <summary>
    /// This class is the basis for all data related objects including data like Paddles, Balls, Collectibles
    /// These data classes are used to store data outside of the monobehaviours associated with them to avoid
    /// monolythic monobehaviours and make finding references easy
    /// </summary>
    public abstract class DataObject : ScriptableObject
    {
        [TextArea]
        public string dataDescription;
    }
}