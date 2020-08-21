using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    // Have a list of bricks, subscribe to their OnBrickDestroyedMethod

    private Brick[] bricks = new Brick[] {};
    // Bricks --, let the score manager handle the bricks adding/removing score

    private void Start()
    {
        foreach (var brick in bricks)
        {
            brick.SetupBrick(this);
        }
    }
}
