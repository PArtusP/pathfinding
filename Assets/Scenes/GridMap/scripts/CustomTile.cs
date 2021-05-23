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
    private CustomTile customTile;
    public bool walkable = true;
    protected int speedModifier = 1;
    protected bool gameEnder = false;
    public CustomTile cameFromTile;

    // Start is called before the first frame update
    
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

    public bool GetGameEnder()
    {
        return gameEnder;
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

    public int GetSpeedModifier()
    {
        return speedModifier;
    }

    /*public void Save()
    {
        for (int x=0; x < grid.GetWidth(); x++)
        {
            for (int y=0; y< grid.GetHeight(); y++)
            {
                CustomTile customTileObject = grid.GetGridObject(x, y);
                customTileObject.Save();
            }
        }
    }

    public class SaveObject
    {
        public CustomTile customTile;
        public int x;
        public int y;
    }

    public SaveObject Save()
    {
        return new SaveObject
        {
            customTile = customTile,
            x = x,
            y = y,
        };
    }*/
}
