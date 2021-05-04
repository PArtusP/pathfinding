using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : CustomTile
{
    private void Awake()
    {
        type = TileType.Trap;
        color = new Color(0f, 0f, 0f, 1f);
        sprite = Resources.Load<Sprite>("Sprites/bob");


    }
}
