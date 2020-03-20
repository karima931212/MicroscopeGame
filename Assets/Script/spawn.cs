using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField]
    public GameObject cube_one;
    [SerializeField]
    public GameObject cube_two;
    // Start is called before the first frame update

    private GameObject cube;
    public bool isSpwaned;
    private void Start()
    {
        cube = cube_one;
        isSpwaned = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isSpwaned == false) {
          //  Vector3 clickPosition = -Vector3.one;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.tag == "plane") {
                    float dot = Vector3.Dot(transform.up, hit.normal);
                    Vector3 position = hit.transform.position + hit.normal;
                    Quaternion rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                    GameObject Placement = Instantiate(cube, position, rotation) as GameObject;
                   // clickPosition = hit.point;
                   
                  //  var myObject = Instantiate(cube, clickPosition, Quaternion.identity);
                    isSpwaned = true;
                }
             
            }

           

        }
    }

    public void CubeOne() {
        isSpwaned = false;
        cube = cube_one;
    }
    public void Cubetwo()
    {
        isSpwaned = false;
        cube = cube_two;
    }
}
