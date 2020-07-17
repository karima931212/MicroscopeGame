using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {


    private float mouseRotateSpeed = 15f;
	private float speed = 2.0f;
	private float zoomSpeed = 1.0f;

	public float minX = -360.0f;
	public float maxX = 360.0f;
	
	public float minY = -45.0f;
	public float maxY = 45.0f;

	public float sensX = 100.0f;
	public float sensY = 100.0f;
	
	float rotationY = 0.0f;
	float rotationX = 0.0f;

	void Update () {

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		transform.Translate(0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);

		if (Input.GetKey(KeyCode.D)){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A)){
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.W)){
			transform.position += Vector3.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S)){
			transform.position += Vector3.back * speed * Time.deltaTime;
		}

		if (Input.GetMouseButton (1) && Input.GetKey(KeyCode.LeftControl)) {
			rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
			rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
			rotationY = Mathf.Clamp (rotationY, minY, maxY);
			transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
		}
	}

    void OnMouseDrag()
    {
        transform.rotation = Quaternion.AngleAxis(-Input.GetAxis("Mouse X") * mouseRotateSpeed, Camera.main.transform.up) *
                             Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * mouseRotateSpeed, Camera.main.transform.right) *
                             transform.rotation;
    }
}
