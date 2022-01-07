using UnityEngine;
using UnityEngine.Tilemaps;
using Random = System.Random;

public class Perlin : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float zoom;
    
    [Header("TileBase")] 
    [SerializeField] private TileBase grass;
    [SerializeField] private TileBase grass1;
    [SerializeField] private TileBase tree;
    [SerializeField] private TileBase spike;

    [Header("Seeds")]
    [SerializeField] private int seedGround;
    [SerializeField] private int seedTrees;
    [SerializeField] private int seedSpikes;
    
    [Header("Thresholds")] 
    [Range(0, 1)] [SerializeField] private float groundThreshold;
    [Range(0, 1)] [SerializeField] private float treesThreshold;
    [Range(0, 1)] [SerializeField] private float spikesThreshold;
    
    [Header("Tilemaps")] 
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap treesTilemap;
    [SerializeField] private Tilemap spikesTilemap;

    private const int Div = 1000000;

    private void Start()
    {
        var random = new Random();
        seedGround = random.Next() / Div;
        seedTrees = random.Next() / Div;
    }

    private void Update()
    {
        ApplyOnTilemap(groundTilemap, seedGround, groundThreshold, grass, grass1);
        ApplyOnTilemap(treesTilemap, seedTrees, treesThreshold, tree);
        ApplyOnTilemap(spikesTilemap, seedSpikes, spikesThreshold, spike);
    }

    private void ApplyOnTilemap(Tilemap tilemap, int seed, float threshold, TileBase tileBase1, TileBase tileBase2)
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
    
    private void ApplyOnTilemap(Tilemap tilemap, int seed, float threshold, TileBase tileBase)
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