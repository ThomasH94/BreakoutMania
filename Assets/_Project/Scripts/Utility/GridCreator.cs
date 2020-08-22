using BrickBreak.Breakable;
using UnityEngine;

public class GridCreator2D
{
    public int[,] Grid;
    private readonly int _columnCount;
    private readonly int _rowCount;

    public GridCreator2D(int columnCount, int rowCount)
    {
        _columnCount = columnCount;
        _rowCount = rowCount;
        Grid = new int[columnCount,rowCount];
    }

    public void CreateGrid()
    {
        for (int x = 0; x < _columnCount; x++)
        {
            for (int y = 0; y < _rowCount; y++)
            {
                Grid[x, y] = Random.Range(0, 10);
                Debug.Log($"Grid at {x},{y} is {Grid[x,y]}");
            }
        }
    }
}
