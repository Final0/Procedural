using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BSP : MonoBehaviour
{
    [Header("Tiles")]
    [SerializeField] private TileBase cell;
    [SerializeField] private TileBase wallCell;
    [SerializeField] private TileBase roomCell;

    [Header("Settings")]
    [Range(1, 4)][SerializeField] private int iterations;
    [Range(0, 1)] [SerializeField] private float minSlice, maxSlice;

    private Tilemap tilemap;

    private readonly Room map = new Room(0, 50, 0, 50);

    private float chanceModifier = 0.5f;

    private List<Room> rooms = new List<Room>();

    private void Awake()
    {
        tilemap = GetComponentInChildren<Tilemap>();

        InitializeCells();
    }
    
    private void InitializeCells()
    {
        for (var i = 0; i < map.MaxX; i++)
        {
            for (var j = 0; j < map.MaxY; j++)
            {
                if(i == 0) tilemap.SetTile(new Vector3Int(i, j, 0), wallCell);
                else if(j == 0) tilemap.SetTile(new Vector3Int(i, j, 0), wallCell);
                else if (i == map.MaxX - 1) tilemap.SetTile(new Vector3Int(i, j, 0), wallCell);
                else if (j == map.MaxY - 1) tilemap.SetTile(new Vector3Int(i, j, 0), wallCell);
                else tilemap.SetTile(new Vector3Int(i, j, 0), cell);
            }
        }
        
        Split(iterations, map);
    }

    private void GenerateRooms()
    {
        foreach (var room in rooms)
        {
            var roomStartX = room.MinX + Random.Range(1, room.MaxX / 4);
            var roomEndX = room.MaxX - Random.Range(1, room.MaxX / 4);
            
            var roomStartY = room.MinY + Random.Range(1, room.MaxY / 4);
            var roomEndY = room.MaxY - Random.Range(1, room.MaxY / 4);
            
            for (var i = roomStartX; i < roomEndX; i++)
            {
                for (var j = roomStartY; j < roomEndY; j++)
                {
                    tilemap.SetTile(new Vector3Int(i, j, 0), roomCell);
                }
            }
        }
    }
    
    private void Split(int nbIterations, Room room)
    {
        if (nbIterations == 0) return;
        
        var splitsRooms = SplitRooms(room.MinX, room.MaxX, room.MinY, room.MaxY);

        if (nbIterations == 1)
        {
            rooms.Add(splitsRooms[0]);
            rooms.Add(splitsRooms[1]);
        }
        
        Split(nbIterations - 1, splitsRooms[0]);
        Split(nbIterations - 1, splitsRooms[1]);
    }
    
    private Room[] SplitRooms(int minX, int maxX, int minY, int maxY)
    {
        if (Random.Range(0f, 1f) > chanceModifier)
        {
            chanceModifier += 0.1f;
            
            var height = maxY - minY;
            
            var min = (int)(height * minSlice) + minY;
            var max = (int)(height * maxSlice) + minY;
            
            var cellRandomCoordinate = Random.Range(min, max);

            for (var x = minX + 1; x < maxX; x++)
            {
                tilemap.SetTile(new Vector3Int(x, cellRandomCoordinate, 0), wallCell);
            }

            var room1 = new Room(minX, maxX, minY, cellRandomCoordinate);
            var room2 = new Room(minX, maxX, cellRandomCoordinate, maxY);
            
            return new[] {room1, room2};
        }
        else
        {
            chanceModifier -= 0.1f;
            
            var width = maxX - minX;
            
            var min = (int)(width * minSlice) + minX;
            var max = (int)(width * maxSlice) + minX;
            
            var cellRandomCoordinate = Random.Range(min, max);

            for (var y = minY + 1; y < maxY; y++)
            {
                tilemap.SetTile(new Vector3Int(cellRandomCoordinate, y, 0), wallCell);
            }
            
            var room1 = new Room(minX, cellRandomCoordinate, minY, maxY);
            var room2 = new Room(cellRandomCoordinate, maxX, minY, maxY);

            return new[] {room1, room2};
        }
    }

    public void Generate()
    {
        tilemap.ClearAllTiles();
        rooms.Clear();
        InitializeCells();
    }
}

public class Room
{
    public readonly int MinX, MaxX, MinY, MaxY;

    public Room(int minimumX, int maximumX, int minimumY, int maximumY)
    {
        MinX = minimumX;
        MaxX = maximumX;
        MinY = minimumY;
        MaxY = maximumY;
    }
}