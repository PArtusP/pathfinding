using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudTile : CustomTile
{
    // Start is called before the first frame update
    private void Awake()
    {
        type = TileType.Mud;
        color = new Color(0.8f, 0.25f, 0.25f, 1.0f);
        speedModifier = 3;

    }
}
