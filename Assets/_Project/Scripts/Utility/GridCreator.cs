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
    }

    public void CreateGrid(GameObject[] gridObjects)
    {
        for (int x = 0; x < _columnCount; x++)
        {
            for (int y = 0; y < _rowCount; y++)
            {
                //TODO: Grid[x,y] = 
            }
        }
    }
}
