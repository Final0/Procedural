using UnityEngine;
using UnityEngine.Tilemaps;

public class Gol : MonoBehaviour
{
    /*[Header("Settings")] 
    [SerializeField] private int width;
    [SerializeField] private int height;*/

    [Header("TileBase")] 
    [SerializeField] private TileBase alive;
    [SerializeField] private TileBase born;
    [SerializeField] private TileBase dead;
    [SerializeField] private TileBase oneGen;
    [SerializeField] private TileBase empty;
    
    private Tilemap tilemap;

    private int[,] array2D = new int[4, 4];

    private void Awake()
    {
        tilemap = GetComponentInChildren<Tilemap>();
        
        for (var i = 0; i < array2D.GetLength(0); i++)
        {
            for (var j = 0; j < array2D.GetLength(1); j++)
            {
                tilemap.SetTile(new Vector3Int(i, j, 0), empty);
            }
        }
    }

    private void Evolve()
    {
        
    }

    private int CheckNeighboursStatus(int cellX, int cellY)
    {
        var deadCellsCount = 0;

        for (var i = -1; i < 2; i++)
        {
            for (var j = -1; j < 2; j++)
            {
                var currentCellX = cellX - i;
                var currentCellY = cellX - j;

                if (tilemap.GetTile(new Vector3Int(currentCellX, currentCellY, 0)) == dead) deadCellsCount++;
                
                if(deadCellsCount > 3) return 1;
            }
        }

        return deadCellsCount == 0 ? 1 : 0;
    }
}