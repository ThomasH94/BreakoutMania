using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This interfaces purpose is to ensure all interactable objects perform a behavior when interacting with physics
/// </summary>
public interface IInteractable
{
    // Attach to the ball, brick, etc. to ensure they play sounds and animation on hit if necessary
    void OnInteract();
}
