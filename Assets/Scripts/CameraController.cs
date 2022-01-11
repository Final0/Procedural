using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    [SerializeField] private TileBase alive;
    
    private Camera mainCamera;

    private Tilemap tilemap;
    private Grid grid;
    
    private void Awake()
    {
        mainCamera = Camera.main;

        tilemap = FindObjectOfType<Tilemap>();
        grid = FindObjectOfType<Grid>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && tilemap.GetTile(MousePosition()))
            tilemap.SetTile(MousePosition(), alive);
    }

    private Vector3Int MousePosition()
    {
        var mousePoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mousePoint);
    }
}