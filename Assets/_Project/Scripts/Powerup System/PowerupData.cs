using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Brick Data", fileName = "New Brick Data")]
public class PowerupData : CollectableData
{
    //TODO: Create a base scriptable object - dataobject - that all of our data classes will inherit from for things like description, name, etc.
    public string powerupName;
}
