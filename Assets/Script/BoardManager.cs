using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    //set the size of each slot
    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = 0.5f;

    //locate the place where user click
    private int selectionX = -1;
    private int selectionY = -1;

    
    public List<GameObject> cubePrefabs;


    private GameObject Selectedcube;
    public bool isSpwaned;
    private int scale;

    public int col = 8;
    public int row = 8;


    private void Start() {
        //Selectedcube = cubePrefabs[0];
        isSpwaned = true;
        scale = 1;
        //by default put 8 cubes on the board
       // SpawnCube(0, GetTileCenter(6, 2));
       // //SpawnCube(1, GetTileCenter(5, 2));
       // SpawnCube(0, GetTileCenter(4, 2));
       // SpawnCube(0, GetTileCenter(3, 2));
       // //SpawnCube(1, GetTileCenter(3, 3));
       //// SpawnCube(1, GetTileCenter(4, 3));
       // SpawnCube(0, GetTileCenter(2, 3));
       // SpawnCube(0, GetTileCenter(5, 3));
        //SpawnCube(3, GetTileCenter(4, 1));
    }

    private void Update()
    {
        UpdateSelection();
        DrawChessBoard();

     
        if (Input.GetMouseButtonDown(0)&& isSpwaned == false)
        {
            Debug.Log(selectionX + " " + selectionY);

          
            if (selectionY >= 0 && selectionX >= 0 && scale == 1)
            {
             
                var myObject = Instantiate(Selectedcube, GetTileCenter(selectionX, selectionY), Quaternion.identity) as GameObject;
                myObject.transform.SetParent(transform);
                isSpwaned = true;
            }

            if (selectionY >= 0 && selectionX >= 1 && scale == 2)
            {
               
                var myObject = Instantiate(Selectedcube, GetTile(selectionX, selectionY), Quaternion.identity) as GameObject;
                myObject.transform.SetParent(transform);
                isSpwaned = true;
            }
            if (selectionY >= 1 && selectionX >= 1 && scale == 3)
            {
             
                var myObject = Instantiate(Selectedcube, GetCenter(selectionX, selectionY), Quaternion.identity) as GameObject;
                myObject.transform.SetParent(transform);
                isSpwaned = true;
            }

        }
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;



            if (Physics.Raycast(ray, out hit, 25f)) {

                if (hit.transform.tag == "laserblock" || hit.transform.tag == "camerablock" || hit.transform.tag == "reflectblock") {

                

                    Destroy(hit.transform.parent.gameObject);


                }
                if (hit.transform.tag == "stillcube" || hit.transform.tag == "movecube") {

                    Destroy(hit.transform.gameObject);

                }
            }
                

        }



    }

    private void UpdateSelection() {

        if (!Camera.main)
            return;


        RaycastHit hit;

        //if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("ChessPlane")))
        //{

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000.0f))
        { 
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.z;
            
          
        }
        else {
            selectionX = -1;
            selectionY = -1;
        }
    }


    private void DrawChessBoard() {

        Vector3 widthLine = Vector3.right * row;
        Vector3 heightLine = Vector3.forward * col;

        for (int i = 0; i <= col; i++) {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + widthLine);
            for (int j = 0; j <= row; j++) {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + heightLine);

            }
        }

 
        if (selectionX >= 0 && selectionY >= 0) {

            Debug.DrawLine(
                Vector3.forward * selectionY + Vector3.right * selectionX,
                Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1)
                );

            Debug.DrawLine(
               Vector3.forward * (selectionY+1) + Vector3.right * selectionX,
               Vector3.forward * selectionY + Vector3.right * (selectionX + 1)
               );
        }

    }

    //function for putting cube in the place
    private void SpawnCube(int index, Vector3 position) {
        GameObject myobj = Instantiate(cubePrefabs[index], position, Quaternion.identity) as GameObject;
        myobj.transform.SetParent(transform);
    }

    //function for get the center of each slot 1*1
    private Vector3 GetTileCenter(int x, int y) {

        Vector3 origin = Vector3.zero;

        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.z += (TILE_SIZE * y) + TILE_OFFSET;
        //origin.x += TILE_SIZE * x;
        //origin.z += TILE_SIZE * y;
        return origin;

    }
    //function for get the center of each slot 2*1
    private Vector3 GetTile(int x, int y)
    {

        Vector3 origin = Vector3.zero;

        //origin.x += TILE_SIZE * x;
        //origin.z += (TILE_SIZE * y) + TILE_OFFSET;
        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.z += TILE_SIZE * y;


        return origin;

    }
    //function for get the center of each slot 2*2
    private Vector3 GetCenter(int x, int y)
    {

        Vector3 origin = Vector3.zero;

        origin.x += TILE_SIZE * x;
        origin.z += TILE_SIZE * y;

        return origin;

    }

    //switch models
    public void LenseCube()
    {
        isSpwaned = false;
        scale = 1;
        Selectedcube = cubePrefabs[0];
    }

    public void ConvexCube()
    {
        isSpwaned = false;
        scale = 1;
        Selectedcube = cubePrefabs[1];
    }

    public void ConcaveCube()
    {
        isSpwaned = false;
        scale = 1;
        Selectedcube = cubePrefabs[2];
    }
    public void FilterCube()
    {
        isSpwaned = false;
        scale = 1;
        Selectedcube = cubePrefabs[3];
    }
    public void MirrorCube()
    {
        isSpwaned = false;
        scale = 1;
        Selectedcube = cubePrefabs[4];
    }
    public void ObjectiveCube()
    {
        isSpwaned = false;
        scale = 1;
        Selectedcube = cubePrefabs[5];
    }
    public void TwoByOneCube()
    {
        isSpwaned = false;
        scale = 2;
        Selectedcube = cubePrefabs[6];
    }
    public void TwoByTwoCube()
    {
        isSpwaned = false;
        scale = 3;
        Selectedcube = cubePrefabs[7];
    }
    public void DefaultCube()
    {
        isSpwaned = false;
        scale = 1;
        Selectedcube = cubePrefabs[8];
    }

    public void CameraCube()
    {
        isSpwaned = false;
        scale = 1;
        Selectedcube = cubePrefabs[9];
    }
    public void LaserCube()
    {
        isSpwaned = false;
        scale = 1;
        Selectedcube = cubePrefabs[10];
    }
}
