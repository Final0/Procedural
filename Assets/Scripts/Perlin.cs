using UnityEngine;
using UnityEngine.Tilemaps;
using Random = System.Random;

public class Perlin : MonoBehaviour
{
    [SerializeField] private TileBase black, white, green;

    [SerializeField] private int seed, seedGround, seedGrass;
    [SerializeField] private int width, height;

    [SerializeField] private float zoom;

    [Range(0, 1)] [SerializeField] private float threshold;
    
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap grassTilemap;

    private void Start()
    {
        var random = new Random(seed);
        seedGround = random.Next() / 1000000;
        seedGrass = random.Next() / 1000000;
    }

    private void Update()
    {
        ApplyOnTilemap(groundTilemap, seedGround, black, white);
        ApplyOnTilemap(grassTilemap, seedGrass, green);
    }

    private void ApplyOnTilemap(Tilemap tilemap, int actualSeed, TileBase tileBase1, TileBase tileBase2)
    {
        tilemap.ClearAllTiles();

        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                tilemap.SetTile(new Vector3Int(i, j, 0),
                    Mathf.PerlinNoise(actualSeed + i * zoom, actualSeed + j * zoom) > threshold ? tileBase1 : tileBase2);
            }
        }
    }
    
    private void ApplyOnTilemap(Tilemap tilemap, int actualSeed, TileBase tileBase1)
    {
        tilemap.ClearAllTiles();

        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                if(Mathf.PerlinNoise(actualSeed + i * zoom, actualSeed + j * zoom) > threshold) 
                    tilemap.SetTile(new Vector3Int(i, j, 0), tileBase1);
            }
        }
    }
}