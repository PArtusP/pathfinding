using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTile : MonoBehaviour
{
    public enum TileType
    {
        Free,
        Wall,
        Mud,
        Trap,
        Start,
        End,
        Path,
        
    }

    protected Sprite sprite;
    protected Color color = new Color();

    
    protected TileType type = TileType.Free;
    protected int x;
    protected int y;
    public bool walkable = true;
    protected int speedModifier = 1;
    protected bool gameEnder = false;
    public CustomTile cameFromTile;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Color GetColor()
    {
        return color;
    }

    public TileType GetTileType()
    {
        return type;
    }




    public void SetPosX(int x)
    {
        this.x = x;
    }
    public void SetPosY(int y)
    {
        this.y = y;
    }

    public int GetPosX()
    {
        return x;
    }

    public int GetPosY()
    {
        return y;
    }

    public int gCost;
    public int hCost;
    public int fCost;

    public CustomTile previousStep;

    public override string ToString()
    {
        return x + ", " + y;
    }
    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }
    public int GetGCost()
    {
        return gCost;
    }
    public void SetGCost(int gCost)
    {
        Debug.Log("this tile SetGCost : gCost = " + gCost);
        this.gCost = gCost;
    }
}
