using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap 
{
    private Grid grid;
    private int width;
    private int height;
    private CustomTile defaultTile;


    public TileMap(int width, int height, float cellsize, CustomTile tile)
    {
        this.width = width;
        this.height = height;
        this.defaultTile = tile;
        this.grid = new Grid(width, height, 10f, new Vector3(0, 0), tile);

    }

    public class TileMapObject
    {

    }

    
}
