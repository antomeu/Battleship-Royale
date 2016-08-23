using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject Planet;
    public Camera Camera;
    private float speed = 3f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        

        if (Input.GetMouseButton(1))
        {
            
            //Debug.Log(Mathf.Abs(transform.eulerAngles.x));
            if (Mathf.Abs(transform.eulerAngles.x) < 90f || Mathf.Abs(transform.eulerAngles.x) > 270f)
                transform.RotateAround(Planet.transform.position, Vector3.left, Input.GetAxis("Mouse Y") * speed);
            else
            {
                //transform.RotateAround(Planet.transform.position, Vector3.left, Input.GetAxis("Mouse Y") * speed);
            }
            


            transform.RotateAround(Planet.transform.position, Vector3.up, Input.GetAxis("Mouse X") * speed);
            Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
            

        }

        Camera.fieldOfView += Input.GetAxis("Mouse ScrollWheel");

        transform.LookAt(Planet.transform);
    }
}
