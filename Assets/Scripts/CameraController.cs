using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    [SerializeField] private TileBase alive;

    private Camera mainCamera;

    private Tilemap tilemap;
    private Grid grid;

    private Structs currrentStruct = Structs.Single;
    
    private enum Structs
    {
        Single,
        Canon,
        Grenouille,
        Clown,
        Planeur
    }
    
    private void Awake()
    {
        mainCamera = Camera.main;

        tilemap = FindObjectOfType<Tilemap>();
        grid = FindObjectOfType<Grid>();
    }

    private void Update()
    {
        DrawStructs();
    }

    private Vector3Int MousePosition()
    {
        var mousePoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mousePoint);
    }

    private void DrawStructs()
    {
        if (!Input.GetMouseButtonDown(0) || !tilemap.GetTile(MousePosition())) return;

        switch (currrentStruct)
        {
            case Structs.Single:
                tilemap.SetTile(MousePosition(), alive);
                break;
            case Structs.Planeur:
                DrawPlaneur();
                break;
            case Structs.Grenouille:
                DrawFrog();
                break;
            case Structs.Clown:
                DrawClown();
                break;
            case Structs.Canon:
                DrawCanon();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void DrawPlaneur()
    {
        tilemap.SetTile(MousePosition(), alive);
        if (tilemap.GetTile(MousePosition() + new Vector3Int(1, 0, 0))) 
            tilemap.SetTile(MousePosition() + new Vector3Int(1, 0, 0), alive);
        if (tilemap.GetTile(MousePosition() + new Vector3Int(2, 0, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(2, 0, 0), alive);
        if (tilemap.GetTile(MousePosition() + new Vector3Int(2, 1, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(2, 1, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(1, 2, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(1, 2, 0), alive);
    }
    
    private void DrawFrog()
    {
        tilemap.SetTile(MousePosition(), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(0, 1, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(0, 1, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(1, -1, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(1, -1, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(3, 1, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(3, 1, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(3, 0, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(3, 0, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(2, 2, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(2, 2, 0), alive);
    }
    
    private void DrawClown()
    {
        tilemap.SetTile(MousePosition(), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(0, 1, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(0, 1, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(0, 2, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(0, 2, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(1, 2, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(1, 2, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(2, 2, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(2, 2, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(2, 1, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(2, 1, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(2, 0, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(2, 0, 0), alive);
    }
    
    private void DrawCanon()
    {
        tilemap.SetTile(MousePosition(), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(0, 1, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(0, 1, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(1, 0, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(1, 0, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(1, 1, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(1, 1, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(10, 0, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(10, 0, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(10, -1, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(10, -1, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(11, -2, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(11, -2, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(12, -3, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(12, -3, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(13, -3, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(13, -3, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(15, -2, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(15, -2, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(16, -1, 0 )))
            tilemap.SetTile(MousePosition() + new Vector3Int(16, -1, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(16, 0, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(16, 0, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(17, 0, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(17, 0, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(14, 0, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(14, 0, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(15, 2, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(15, 2, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(13, 3, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(13, 3, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(12, 3, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(12, 3, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(11, 2, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(11, 2, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(10, 1, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(10, 1, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(20, 1, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(20, 1, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(20, 2, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(20, 2, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(20, 3, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(20, 3, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(21, 1, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(21, 1, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(21, 2, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(21, 2, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(21, 3, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(21, 3, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(22, 4, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(22, 4, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(22, 0, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(22, 0, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(24, 0, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(24, 0, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(24, -1, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(24, -1, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(24, 4, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(24, 4, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(24, 5, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(24, 5, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(34, 2, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(34, 2, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(34, 3, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(34, 3, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(35, 3, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(35, 3, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(35, 2, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(35, 2, 0), alive);
        if (tilemap.GetTile(MousePosition( )+ new Vector3Int(16, 1, 0)))
            tilemap.SetTile(MousePosition() + new Vector3Int(16, 1, 0), alive);
    }

    public void SelectSingle() => currrentStruct = Structs.Single;
    
    public void SelectPlaneur() => currrentStruct = Structs.Planeur;

    public void SelectFrog() => currrentStruct = Structs.Grenouille;

    public void SelectClown() => currrentStruct = Structs.Clown;

    public void SelectCanon() => currrentStruct = Structs.Canon;
}