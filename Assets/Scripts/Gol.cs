using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Gol : MonoBehaviour
{
    [SerializeField] private float timeToEvolve;
    
    [Header("TileBase")] 
    [SerializeField] private TileBase alive;
    [SerializeField] private TileBase born;
    [SerializeField] private TileBase dead;
    [SerializeField] private TileBase oneGen;
    [SerializeField] private TileBase empty;
    
    private Tilemap tilemap;

    private int[,] array2D = new int[6, 6];
    
    private int width, height;

    private void Awake()
    {
        tilemap = GetComponentInChildren<Tilemap>();

        width = array2D.GetLength(0);
        height = array2D.GetLength(1);
        
        InitializeCells();
        InvokeRepeating(nameof(Evolve), timeToEvolve, timeToEvolve);
    }

    private void InitializeCells()
    {
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                tilemap.SetTile(new Vector3Int(i, j, 0), empty);
            }
        }
        
        tilemap.SetTile(new Vector3Int(1, 2, 0), alive);
        tilemap.SetTile(new Vector3Int(1, 3, 0), alive);
        tilemap.SetTile(new Vector3Int(2, 1, 0), alive);
        tilemap.SetTile(new Vector3Int(4, 2, 0), alive);
        tilemap.SetTile(new Vector3Int(4, 3, 0), alive);
        tilemap.SetTile(new Vector3Int(3, 4, 0), alive);
    }

    private void Evolve()
    {
        var newArray2D = new int[width, height];
        
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                newArray2D[i, j] = CheckNeighboursStatus(i, j);
            }
        }
        
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                var currentCell = new Vector3Int(i, j, 0);

                switch (newArray2D[i, j])
                {
                    case 0:
                        tilemap.SetTile(currentCell, empty);
                        break;
                    case 1:
                        tilemap.SetTile(currentCell, alive);
                        break;
                }
            }
        }
    }
    
    private int CheckNeighboursStatus(int cellX, int cellY)
    {
        var cellsCount = 0;

        for (var i = -1; i < 2; i++)
        {
            for (var j = -1; j < 2; j++)
            {
                if (i == 0 & j == 0) continue;
                if(cellsCount > 3) return 0;
                
                var currentCellX = cellX + i;
                var currentCellY = cellY + j;

                var currentCell = tilemap.GetTile(new Vector3Int(currentCellX, currentCellY, 0));
                
                if (currentCell == null) continue;
                
                if (currentCell == alive) cellsCount++;
            }
        }

        return cellsCount switch
        {
            2 => 2,
            3 => 1,
            _ => 0
        };
    }
}