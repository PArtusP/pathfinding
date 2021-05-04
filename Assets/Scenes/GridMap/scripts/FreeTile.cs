using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeTile : CustomTile
{
    private void Awake()
    {
        type = TileType.Free;
        color = Color.white;
        sprite = Resources.Load<Sprite>("Sprites/bob");

    }
    
    
}
