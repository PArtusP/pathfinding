using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTile : CustomTile
{
    private void Awake()
    {
        type = TileType.Start;
        color = new Color(0.8f, 0f, 0.2f, 0.2f);
        sprite = Resources.Load<Sprite>("Sprites/bob");

        SetPosX(0);
        SetPosY(0);

    }
}
