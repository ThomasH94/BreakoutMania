using UnityEngine;

namespace BrickBreak.Utility
{
    /// <summary>
    /// The purpose of this interface is to ensure any gameobject will setup properly if setup from an external source
    /// </summary>
    public interface ISetupable
    {
        void Setup(ScriptableObject data);
    }
}