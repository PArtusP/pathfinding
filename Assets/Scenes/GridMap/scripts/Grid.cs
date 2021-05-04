using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class Grid 
{
    private int width;
    private int  height;
    private float cellSize;
    private Vector3 originPosition;
    private GameObject map;
    private int tileNb;
    private Sprite tile;
    private CustomTile defaultTile;

    private CustomTile[,] gridArray;
    private TextMesh[,] debugTextArray;
    private SpriteRenderer[,] spriteArray; //tableau de sprite

    


    public Grid(int width, int height, float cellSIze, Vector3 originPosition, CustomTile defaultTile)
    {

        this.width = width;
        this.height = height;
        this.cellSize = cellSIze;
        this.originPosition = originPosition;
        this.defaultTile = defaultTile;

        map = GameObject.Find("Map");
        tile = Resources.Load<Sprite>("Sprites/bob"); //chargement du spite(assets/ressource/sprites/normal.png

        gridArray = new CustomTile[width, height];
        //debugTextArray = new TextMesh[width, height];
        
        spriteArray = new SpriteRenderer[width, height];

        for (int x=0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                spriteArray[x, y] = CreateTile(map.transform, "maze", GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, Color.yellow, 1f);
                SetValue(x, y, defaultTile);

                //debugTextArray[x, y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, (GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * 0.5f), 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.yellow, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.yellow, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
        
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;

    }
    private void  GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);

    }

    public void SetValue(int x, int y, CustomTile tile)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            if (gridArray[x, y]) GameObject.Destroy(gridArray[x, y].gameObject.GetComponent<CustomTile>());
            gridArray[x, y] = (CustomTile)spriteArray[x, y].gameObject.AddComponent(tile.GetType());
            gridArray[x, y].SetPosX(x);
            gridArray[x, y].SetPosY(y);
            spriteArray[x, y].color = tile.GetColor();
            Debug.Log("MazeGrid, SetValue(x:y) : Color = " + tile.GetColor());

        }

    }

    public void SetValue(Vector3 worldPosition, CustomTile tile)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, tile);

    }

    public CustomTile GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return defaultTile;
        }
    }

    public CustomTile GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
    //benshitstart
    
    public SpriteRenderer CreateTile(Transform parent, string name, Vector3 localPosition, Color color, float size)
    {
        Debug.Log("grid: Color = " + color);
        GameObject gameObject = new GameObject(name + "_tile_" + tileNb, typeof(SpriteRenderer));
        tileNb++;
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        transform.localScale = new Vector3(cellSize * .5f * size, cellSize * .5f * size);
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = tile;
        spriteRenderer.color = color;
        return spriteRenderer;
    }

    /*public void SetTile(int x, int y, CustomTile tile)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            if (gridArray[x, y]) GameObject.Destroy(gridArray[x, y].gameObject.GetComponent<CustomTile>());
            gridArray[x, y] = (CustomTile)spriteArray[x, y].gameObject.AddComponent(tile.GetType());
            gridArray[x, y].SetPosX(x);
            gridArray[x, y].SetPosY(y);
            spriteArray[x, y].color = tile.GetColor();
            Debug.Log("MazeGrid, SetValue(x:y) : Color = " + tile.GetColor());

        }
    }*/
    /*
    public void SetTileValue(Vector3 worldPosition, MazeTile tile)
    {
        int x, y;
        Debug.Log("MazeGrid, SetValue(world) : Tile type = " + tile);
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, tile);
    }*/
    //benshitend
    public int GetWidth()
    {
        return width;
    }
    public int GetHeight()
    {
        return height;
    }
    public void SetWidth(int width)
    {
        this.width = width;
    }
    public void SetHeight(int height)
    {
        this.height = height;
    }
    
}
