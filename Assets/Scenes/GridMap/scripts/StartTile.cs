using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTile : CustomTile
{
    private void Awake()
    {
        type = TileType.Start;
        color = new Color(0.5f, 0.5f, 0.5f, 0.2f);
        
    }
}
