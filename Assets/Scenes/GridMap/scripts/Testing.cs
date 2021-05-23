using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    private Grid grid;
    private Pathfinding pathfinding;
    [SerializeField] private CustomTile defaultTile;
    [SerializeField] private CustomTile wallTile;
    [SerializeField] private CustomTile mudTile;
    [SerializeField] private CustomTile trapTile;
    [SerializeField] private CustomTile pathTile;
    [SerializeField] private CustomTile endTile;
    [SerializeField] private CustomTile startTile;
    List<CustomTile> path;


    private void Start()
    {
       grid = new Grid(20, 10, 10f, new Vector3(0, 0), defaultTile);
        pathfinding = new Pathfinding(grid);
        
      
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) /// left click= set mur
        {
            Debug.Log("grid added freeTile" + grid);
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), defaultTile);
        }

        if (Input.GetKeyDown("1")) /// 1 = set mur
        {
            Debug.Log("grid added wall" + grid );
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), wallTile);
        }

        if (Input.GetKeyDown("2")) /// 2 = set boue
        {
            Debug.Log("grid mud" + grid);
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), mudTile);
        }
        
        if (Input.GetKeyDown("3")) /// 3 = ITS A TRAP
        {
            Debug.Log("tile trap added" + grid);
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), trapTile);
        }

        if (Input.GetKeyDown("a")) /// set start A
        {
            Debug.Log("tile trap added" + grid);
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), startTile);
        }
        if (Input.GetKeyDown("z")) /// set end Z
        {
            Debug.Log("tile trap added" + grid);
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), endTile);
        }

        if (Input.GetKeyDown("space"))
        {
            //Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            //grid.GetValue(mouseWorldPosition);
            int[] start = grid.GetStart();
            int[] end = grid.GetEnd();
            List<CustomTile> path = pathfinding.FindPath(start[0], start[1], end[0], end[1]);
            Debug.Log("list path" + path);
            if (path!= null)
            {
                for(int i = 0; i<=path.Count -1; i++)
                {
                    Debug.Log(path[i]);
                    
                    grid.SetValue( new Vector3((path[i].GetPosX())*10f, (path[i].GetPosY())*10f), pathTile);
                    
                    

                    //Debug.DrawLine(new Vector3(path[i].GetPosX(), path[i].GetPosY()) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].GetPosX(), path[i + 1].GetPosY()) * 10f + Vector3.one * 5f, Color.green);
                }
            }
        }
        /*
        if (Input.GetKeyDown("r"))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }*/


    }

}
