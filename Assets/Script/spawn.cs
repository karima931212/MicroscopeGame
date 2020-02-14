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
    private void Start()
    {
        cube = cube_one;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            Vector3 clickPosition = -Vector3.one;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                clickPosition = hit.point;
            }

            var myObject = Instantiate(cube,clickPosition, Quaternion.identity);

        }
    }

    public void CubeOne() {

        cube = cube_one;
    }
    public void Cubetwo()
    {

        cube = cube_two;
    }
}
