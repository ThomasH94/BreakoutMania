using System.Collections;
using System.Collections.Generic;
using BrickBreak.Singletons;
using UnityEngine;

public class BrickManager : Singleton<BrickManager>
{
    [SerializeField] private int brickCount = 0;
    public BrickData[] allBrickData = new BrickData[0];
    [SerializeField] private Brick[] bricks = new Brick[] {};

    private GridCreator2D _gridCreator2D;

    protected override void Awake()
    {
        base.Awake();
        // TODO: Load bricks via addressables
    }

    private void Start()
    {
        _gridCreator2D = new GridCreator2D(1,1);    // TODO: Replace with this levels brick layout
        foreach (var brick in bricks)
        {
            brick.Setup(allBrickData[0]);
        }
    }

    private void SetupBricks()
    {

    }

    public void BrickDestroyed(BrickData destroyedBrick)
    {
        ScoreController.Instance.UpdateScore(destroyedBrick.scoreAmount);
        brickCount--;

        if (brickCount == 0)
        {
            EventManager.TriggerEvent("Objective Complete");
        }
    }
}
