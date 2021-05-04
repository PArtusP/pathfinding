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
    List<CustomTile> path;


    private void Start()
    {
       grid = new Grid(8, 4, 10f, new Vector3(0, 0), defaultTile);
        pathfinding = new Pathfinding(grid);
        path = pathfinding.FindPath(0, 0, 5, 2);
      
    }

    private void Update()
    {
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

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            grid.GetValue(mouseWorldPosition);
            List<CustomTile> path = pathfinding.FindPath(StartTile.GetPosX(), Star 0, )
        }
        /*
        if (Input.GetKeyDown("r"))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }*/


    }

}
