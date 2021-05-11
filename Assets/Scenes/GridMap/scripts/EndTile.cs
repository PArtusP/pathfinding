using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTile : CustomTile
{
    // Start is called before the first frame update
    private void Awake()
    {
        type = TileType.End;
        color = new Color(0.8f, 0.8f, 0.8f, 1f);

    }
}
