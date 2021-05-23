using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    private const int STRAIGHT_COST = 10;
    private const int DIAGONAL_COST = 14;

    private Grid grid;
    private List<CustomTile> openList;
    private List<CustomTile> closedList;
    
   public Pathfinding(Grid grid)
    {
        this.grid = grid;
    }

    


    public List<CustomTile> FindPath(int startX, int StartY, int endX, int endY) {

        CustomTile startNode = grid.GetValue(startX, StartY);
        CustomTile endNode = grid.GetValue(endX, endY);
        Debug.Log("in pathfinding.cs at FindPath fct startNode :" + startNode);
        Debug.Log("in pathfinding.cs at FindPath fct endNode :" + endNode);

       

        openList = new List<CustomTile> { startNode };
        closedList = new List<CustomTile>();

        for(int x = 0; x < grid.GetWidth(); x++)
        {
            for(int y = 0; y < grid.GetHeight(); y++)
            {
                CustomTile customTile = grid.GetValue(x, y);
                customTile.gCost = int.MaxValue;
                customTile.CalculateFCost();
                customTile.cameFromTile = null;
            }
        }

        startNode.gCost = 0;
        startNode.hCost = CalculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();

        while (openList.Count > 0)
        {
            CustomTile currentTile = GetLowestFCostTile(openList);

            
            if (currentTile == endNode)
            {
                return CalculatePath(endNode);
            }
            openList.Remove(currentTile);
            closedList.Add(currentTile);
            

            foreach (CustomTile neighbourTile in GetNeighbourList(currentTile))
            {
                bool IaKiller = false;
                if (closedList.Contains(neighbourTile)) continue;
                if (!neighbourTile.walkable)
                {
                    closedList.Add(neighbourTile);
                    continue;
               

                }

                

                int tentativeGCost = currentTile.gCost + CalculateDistanceCost(currentTile, neighbourTile)*neighbourTile.GetSpeedModifier();
                if (currentTile.GetGameEnder()) {
                    IaKiller = true;
                    Debug.Log("IaKiller:" +IaKiller+"Ia died on trap at" + currentTile.GetPosX() + ":" + currentTile.GetPosY()) ;
                    }
                    if (tentativeGCost < neighbourTile.gCost)
                    {
                    neighbourTile.cameFromTile = currentTile;
                    neighbourTile.gCost = tentativeGCost;
                    neighbourTile.hCost = CalculateDistanceCost(neighbourTile, endNode);
                    neighbourTile.CalculateFCost();

                    if (!openList.Contains(neighbourTile))
                    {
                        openList.Add(neighbourTile);
                        

                    }
                    //if (neighbourTile.GetGameEnder()) return openList;


                }
           
                

               //if (currentTile.GetGameEnder()) return openList;
                     
            }
            //if (currentTile.GetGameEnder()) break;

            
        }
        return null;
        
    }
    private List<CustomTile> GetNeighbourList(CustomTile currentTile)
    {
        List<CustomTile> neighbourList = new List<CustomTile>();

        if(currentTile.GetPosX() -1 >= 0)
        {
            //Left si existe
            neighbourList.Add(GetTile(currentTile.GetPosX() - 1, currentTile.GetPosY()));
            if (currentTile.GetPosY() - 1 >= 0)//DownLeft
            { neighbourList.Add(GetTile(currentTile.GetPosX() - 1, currentTile.GetPosY() - 1)); }
            if (currentTile.GetPosY() +1 >=0)//UpLeft
            { neighbourList.Add(GetTile(currentTile.GetPosX() - 1, currentTile.GetPosY() + 1)); }
        }
        if(currentTile.GetPosX() +1 >=0)
        {
            //Right
            neighbourList.Add(GetTile(currentTile.GetPosX() + 1, currentTile.GetPosY()));
            if (currentTile.GetPosY() - 1>=0)//DownRight
            { neighbourList.Add(GetTile(currentTile.GetPosX() + 1, currentTile.GetPosY() - 1)); }
            if (currentTile.GetPosY() + 1>=0)//UpRight
            { neighbourList.Add(GetTile(currentTile.GetPosX() + 1, currentTile.GetPosY() + 1)); }
        }
        if (currentTile.GetPosY() -1 >=0)//Down
        { neighbourList.Add(GetTile(currentTile.GetPosX(), currentTile.GetPosY() - 1)); }
        if (currentTile.GetPosY() +1 >=0)//Up
        { neighbourList.Add(GetTile(currentTile.GetPosX(), currentTile.GetPosY() + 1)); }

        return neighbourList;

    }
    private CustomTile GetTile(int x, int y)
    {
        return grid.GetValue(x, y);
    }
    private List<CustomTile> CalculatePath(CustomTile endNode)
    {
        List<CustomTile> path = new List<CustomTile>();
        path.Add(endNode);
        CustomTile currentTile = endNode;
        
        while (currentTile.cameFromTile != null)
        {
            //if (currentTile.GetGameEnder())return path;
            
            path.Add(currentTile.cameFromTile);
            currentTile = currentTile.cameFromTile;
        }
        path.Reverse();
        return path;
    }
    private int CalculateDistanceCost(CustomTile a, CustomTile b)
    {
        int xDistance = Mathf.Abs(a.GetPosX() - b.GetPosX());
        int yDistance = Mathf.Abs(a.GetPosY() - b.GetPosY());
        int remaining = Mathf.Abs(xDistance - yDistance);
        return DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + STRAIGHT_COST * remaining;
    }

    private CustomTile GetLowestFCostTile(List<CustomTile> pathTileList)
    {
        CustomTile lowestFCostTile = pathTileList[0];
        for (int i =1; i < pathTileList.Count; i++)
        {
            if(pathTileList[i].fCost < lowestFCostTile.fCost)
            {
                lowestFCostTile = pathTileList[i];
            }
        }
        return lowestFCostTile;
    }
}
