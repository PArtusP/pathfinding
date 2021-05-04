using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : CustomTile
{
    private void Awake()
    {
        type = TileType.Path;
        color = new Color(0f, 5f, 0f, 1f);
        sprite = Resources.Load<Sprite>("Sprites/bob");


    }
}
