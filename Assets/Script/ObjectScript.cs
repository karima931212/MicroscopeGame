using UnityEngine;
using System.Collections;

public class ObjectScript : MonoBehaviour 
{
	public int rotationDirection = -1; 	// -1 for clockwise
										//  1 for anti-clockwise
	
	public int rotationStep = 10;    	// should be less than 90
	
	// All the objects with which collision will be checked
	public GameObject[] objectsArray;

	private Vector3 currentRotation, targetRotation;


	private Vector3 positionDiff, prevPosition, changedPosition, initialPosition;
	private bool isRotating = false, swipping = false, moving = false, isCurrentObject = false;
	private float distanceForRotation = 0.1f;

	void Start () 
	{
		initialPosition = transform.position;
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0) && !isRotating)
		{
            
			positionDiff = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
			positionDiff.y = 0;

			prevPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			
			swipping = isRotating = false;
			isCurrentObject = moving = true;
		}
	}

	void Update()
	{
		if (Input.GetMouseButtonUp(0) && !isRotating && isCurrentObject)
		{
			if (!swipping)
				rotateObject(); 
			else
				placeObjectAtProperPosition();
			
			moving = swipping = isRotating = isCurrentObject = false;
		}
		else if (moving && GetTouchState()) 
		{
			if (!swipping && (Vector3.Distance (Camera.main.ScreenToWorldPoint (Input.mousePosition), prevPosition) > distanceForRotation))
				swipping = true;
			
			if (swipping)
			{
				changedPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition) - positionDiff;
				changedPosition.y = initialPosition.y;
				prevPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				transform.position = changedPosition;
			}
		}
	}

	private bool GetTouchState()
	{
		if(Input.touchCount>0 && Input.touchCount<2){
			Touch touch = Input.GetTouch(0);
			if(touch.phase == TouchPhase.Began)
				return true;
			else if(touch.phase == TouchPhase.Moved)
				return true;
			else if(touch.phase == TouchPhase.Stationary)
				return true;
			else if(touch.phase == TouchPhase.Canceled)
				return false;
			else if(touch.phase == TouchPhase.Ended)
				return false;
		}
		else
		{
			#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_METRO
			if (Input.GetMouseButtonDown(0))
				return true;
			if (Input.GetMouseButton(0))
				return true;
			else if (Input.GetMouseButtonUp(0))
				return false;
			
			#endif
		}
		return false;
	}


	private void placeObjectAtProperPosition()
	{
		if (isCurrentObjectCollidingWithOtherObject())
		{
			transform.position = initialPosition;
		}
	}	
    //function for rotate the object
	private void rotateObject()
	{
		currentRotation = gameObject.transform.eulerAngles;

        
		targetRotation.y = (currentRotation.y + (30 * rotationDirection));
		StartCoroutine (objectRotationAnimation());
	}

	IEnumerator objectRotationAnimation()
	{
	
		currentRotation.y += (rotationStep * rotationDirection);
		gameObject.transform.eulerAngles = currentRotation;
		
		yield return new WaitForSeconds (0);
		
		if (((int)currentRotation.y >
		     (int)targetRotation.y && rotationDirection < 0)  ||  // for clockwise
		    ((int)currentRotation.y <  (int)targetRotation.y && rotationDirection > 0)) // for anti-clockwise
		{
			StartCoroutine (objectRotationAnimation());
		}
		else
		{
			gameObject.transform.eulerAngles = targetRotation;
			if (isCurrentObjectCollidingWithOtherObject())
				StartCoroutine(rotateObjectAgain());
			else
				isRotating = isCurrentObject = false;
		}
	}

	IEnumerator rotateObjectAgain()
	{
		yield return new WaitForSeconds (0.2f);
		rotateObject();
	}
			
	public bool isCurrentObjectCollidingWithOtherObject ()
	{
		foreach (GameObject objectToCheck in objectsArray)
		{
			if (!objectToCheck.name.Equals (gameObject.name))
			{
				if (gameObject.GetComponent<Collider>().bounds.Intersects (objectToCheck.GetComponent<Collider>().bounds))
					return true;
			}
		}
		return false;
	}
}