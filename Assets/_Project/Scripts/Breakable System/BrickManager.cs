using System.Collections;
using System.Collections.Generic;
using BrickBreak.Singletons;
using UnityEngine;

public class BrickManager : Singleton<BrickManager>
{
    [SerializeField] private int brickCount = 0;
    public BrickData[] allBrickData = new BrickData[0];
    [SerializeField] private Brick[] bricks = new Brick[] {};
    private int[,] brickGrid = new int[10,2];
    private int columns;
    private int rows;

    private void Awake()
    {
        // TODO: Load bricks via addressables
    }

    private void Start()
    {
        foreach (var brick in bricks)
        {
            brick.Setup(allBrickData[0]);
        }
    }

    private void SetupBricks()
    {
        for (int i = 0; i < brickGrid.Length; i++)
        {
            for (int j = 0; j < brickGrid.Length; j++)
            {
                
            }
        }
    }

    public void BrickDestroyed(BrickData destroyedBrick)
    {
        ScoreController.Instance.UpdateScore(destroyedBrick.scoreAmount);
        brickCount--;
    }
}
