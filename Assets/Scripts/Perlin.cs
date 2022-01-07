using UnityEngine;
using UnityEngine.Tilemaps;
using Random = System.Random;

public class Perlin : MonoBehaviour
{
    [SerializeField] private int width, height;

    [SerializeField] private float zoom;
    
    [Header("TileBase")] 
    [SerializeField] private TileBase grass;
    [SerializeField] private TileBase grass1;
    [SerializeField] private TileBase tree;

    [Header("Seeds")] 
    [SerializeField] private int defaultSeed;
    [SerializeField] private int seedGround;
    [SerializeField] private int seedTrees;
    
    [Header("Thresholds")] 
    [Range(0, 1)] [SerializeField] private float threshold;
    
    [Header("Tilemaps")] 
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap treesTilemap;

    private void Start()
    {
        var random = new Random(defaultSeed);
        seedGround = random.Next() / 1000000;
        seedTrees = random.Next() / 1000000;
    }

    private void Update()
    {
        ApplyOnTilemap(groundTilemap, seedGround, grass, grass1);
        ApplyOnTilemap(treesTilemap, seedTrees, tree);
    }

    private void ApplyOnTilemap(Tilemap tilemap, int seed, TileBase tileBase1, TileBase tileBase2)
    {
        tilemap.ClearAllTiles();

        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                tilemap.SetTile(new Vector3Int(i, j, 0),
                    Mathf.PerlinNoise(seed + i * zoom, seed + j * zoom) > threshold ? tileBase1 : tileBase2);
            }
        }
    }
    
    private void ApplyOnTilemap(Tilemap tilemap, int seed, TileBase tileBase)
    {
        tilemap.ClearAllTiles();

        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                if(Mathf.PerlinNoise(seed + i * zoom, seed + j * zoom) > threshold) 
                    tilemap.SetTile(new Vector3Int(i, j, 0), tileBase);
            }
        }
    }
}