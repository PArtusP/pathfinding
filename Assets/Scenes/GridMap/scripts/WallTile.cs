using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTile : CustomTile
{
    // Start is called before the first frame update
    void Start()
    {
        type = TileType.Wall;
        walkable = false;
        color = Color.red;
        sprite = Resources.Load<Sprite>("Sprites/bob");
    }

    
}
