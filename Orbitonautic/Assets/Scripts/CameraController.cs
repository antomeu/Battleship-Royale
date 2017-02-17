using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject Planet;
    public Camera Camera;

    public float scrollSpeed = 50f;
    private float cameraSpeed = 3f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        

        if (Input.GetMouseButton(1))
        {
            
            //Debug.Log("axis: " + Input.GetAxis("Mouse Y"));
            //Debug.Log("angle: " + transform.eulerAngles.x);
            if (Mathf.Abs(transform.eulerAngles.x) > 80f && Mathf.Abs(transform.eulerAngles.x) < 100f && Input.GetAxis("Mouse Y") > 0 
                || Mathf.Abs(transform.eulerAngles.x) < 280f && Mathf.Abs(transform.eulerAngles.x) > 260f && Input.GetAxis("Mouse Y") < 0)
            {
                transform.RotateAround(Planet.transform.position, -transform.right, Input.GetAxis("Mouse Y") * cameraSpeed);
            }
            else if ( Mathf.Abs(transform.eulerAngles.x) < 80f || Mathf.Abs(transform.eulerAngles.x) > 280f )
            {
                transform.RotateAround(Planet.transform.position, -transform.right, Input.GetAxis("Mouse Y") * cameraSpeed);
            }


            transform.RotateAround(Planet.transform.position, Vector3.up, Input.GetAxis("Mouse X") * cameraSpeed);
            
            

        }

	    if (Camera.fieldOfView >= 1)
	        Camera.fieldOfView -= scrollSpeed*Input.GetAxis("Mouse ScrollWheel");
	    else Camera.fieldOfView = 1;


	    if (Input.GetMouseButton(0))
	    {
	        transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")), Space.Self);
	    }
	    else
	    {
            transform.LookAt(Planet.transform);
        }
        
    }
}
