using UnityEngine;
using UnityEngine.Tilemaps;

public class BSP : MonoBehaviour
{
    [SerializeField] private TileBase cell;
    [SerializeField] private TileBase roomCell;

    [SerializeField] private int iterations;

    private Tilemap tilemap;

    private readonly Room mapRoom = new Room(0, 50, 0, 50);

    private void Awake()
    {
        tilemap = GetComponentInChildren<Tilemap>();

        InitializeCells();
    }
    
    private void InitializeCells()
    {
        for (var i = 0; i < mapRoom.MaxX(); i++)
        {
            for (var j = 0; j < mapRoom.MaxY(); j++)
            {
                if(i == 0) tilemap.SetTile(new Vector3Int(i, j, 0), roomCell);
                else if(j == 0) tilemap.SetTile(new Vector3Int(i, j, 0), roomCell);
                else if (i == mapRoom.MaxX() - 1) tilemap.SetTile(new Vector3Int(i, j, 0), roomCell);
                else if (j == mapRoom.MaxY() - 1) tilemap.SetTile(new Vector3Int(i, j, 0), roomCell);
                else tilemap.SetTile(new Vector3Int(i, j, 0), cell);
            }
        }
        
        Split(iterations, mapRoom);
    }


    private void Split(int nbIterations, Room room)
    {
        if(nbIterations == 0) return;

        var rooms = SplitRooms(room.MinX(), room.MaxX(), room.MinY(), room.MaxY());
        
        Split(nbIterations - 1, rooms[0]);
        Split(nbIterations - 1, rooms[1]);
    }
    
    private Room[] SplitRooms(int minX, int maxX, int minY, int maxY)
    {
        var axe = Random.Range(0, 2);

        if (axe == 0)
        {
            var cellRandomCoordinate = Random.Range(1, maxX);
                    
            for (var x = minX + 1; x < maxX; x++)
            {
                tilemap.SetTile(new Vector3Int(x, cellRandomCoordinate, 0), roomCell);
            }

            var room1 = new Room(minX, maxX, minY, cellRandomCoordinate);
            var room2 = new Room(minX, maxX, cellRandomCoordinate, maxY);
            
            return new[] {room1, room2};
        }
        else
        {
            var cellRandomCoordinate = Random.Range(1, maxY);
                    
            for (var y = minY + 1; y < maxY; y++)
            {
                tilemap.SetTile(new Vector3Int(cellRandomCoordinate, y, 0), roomCell);
            }
            
            var room1 = new Room(minX, cellRandomCoordinate, minY, maxY);
            var room2 = new Room(cellRandomCoordinate, maxX, minY, maxY);
            
            return new[] {room1, room2};
        }
    }
}

public class Room
{
    private readonly int minimumX;
    private readonly int maximumX;
    private readonly int minimumY;
    private readonly int maximumY;

    public Room(int minX, int maxX, int minY, int maxY)
    {
        minimumX = minX;
        maximumX = maxX;

        minimumY = minY;
        maximumY = maxY;
    }

    public int MinX() => minimumX;
    public int MaxX() => maximumX;
    public int MinY() => minimumY;
    public int MaxY() => maximumY;
}