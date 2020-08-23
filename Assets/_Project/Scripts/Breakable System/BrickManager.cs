using System;
using System.Collections;
using System.Collections.Generic;
using BrickBreak.Breakable;
using BrickBreak.Singletons;
using UnityEngine;

public class BrickManager : Singleton<BrickManager>
{
    [SerializeField] private int brickCount = 0;
    [SerializeField] private GameObject[] bricks = new GameObject[] {};

    private GridCreator2D _gridCreator2D;

    protected override void Awake()
    {
        base.Awake();
        // TODO: Load bricks via addressables
    }

    private void OnEnable()
    {
        Brick.OnAnyBrickDied += BrickDestroyed;
    }

    private void OnDisable()
    {
        Brick.OnAnyBrickDied -= BrickDestroyed;
    }

    private void Start()
    {
        _gridCreator2D = new GridCreator2D(5,5);    // TODO: Replace with this levels brick layout
        SetupBricks();
    }

    private void SetupBricks()
    {
        //TODO: Create a grid of bricks based on the bricks we create in the level brick array, with appropriate positions to spawn them
    }

    public void BrickDestroyed(Brick destroyedBrick)
    {
        ScoreController.Instance.UpdateScore(destroyedBrick.brickData.scoreAmount);
        brickCount--;

        if (brickCount == 0)
        {
            EventManager.TriggerEvent("Objective Complete");
        }
    }
}
