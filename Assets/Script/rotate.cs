using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 20f;
    [SerializeField] bool RotateY = true;

    [SerializeField] bool RotateX = true;

    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
        float rotY= Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;

        if (RotateY) {
            transform.RotateAround(Vector3.up, -rotX);
        }
        if (RotateX)
        {
            transform.RotateAround(Vector3.right, rotY);
        }
        // 
    }
    // Update is called once per frame

}
