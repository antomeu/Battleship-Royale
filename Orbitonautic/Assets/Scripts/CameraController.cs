using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject Planet;
    public Camera Camera;

    public float ScrollSpeed = 50f;
    public float CameraSpeed = 3f;

    public float MinCameraFieldOfView = 1;
    public float MaxCameraFieldOfView = 70;

    public float MinCameraDistance;

	// Use this for initialization
	void Start () {
        MinCameraDistance = (transform.position - Planet.transform.position).magnitude;
    }
	
	// Update is called once per frame
	void Update () {
        
        ZoomCamera();

        RotateCamera();
        PanCamera();
    }

    void ZoomCamera()
    {

        if (Camera.fieldOfView >= MinCameraFieldOfView && Camera.fieldOfView <= MaxCameraFieldOfView )
        {
            Camera.fieldOfView -= ScrollSpeed * Input.GetAxis("Mouse ScrollWheel");
            if (Camera.fieldOfView <= MinCameraFieldOfView)  Camera.fieldOfView =  MinCameraFieldOfView ;
        }
        else if (Camera.fieldOfView >= MaxCameraFieldOfView)
        {
            Camera.fieldOfView = MaxCameraFieldOfView;

        }
        
    }

    void RotateCamera()
    {
        if (Input.GetMouseButton(1))//Rotate camera
        {

            //Debug.Log("axis: " + Input.GetAxis("Mouse Y"));
            //Debug.Log("angle: " + transform.eulerAngles.x);
            if (Mathf.Abs(transform.eulerAngles.x) > 80f && Mathf.Abs(transform.eulerAngles.x) < 100f && Input.GetAxis("Mouse Y") > 0
                || Mathf.Abs(transform.eulerAngles.x) < 280f && Mathf.Abs(transform.eulerAngles.x) > 260f && Input.GetAxis("Mouse Y") < 0)
            {
                transform.RotateAround(Planet.transform.position, -transform.right, Input.GetAxis("Mouse Y") * CameraSpeed);
            }
            else if (Mathf.Abs(transform.eulerAngles.x) < 80f || Mathf.Abs(transform.eulerAngles.x) > 280f)
            {
                transform.RotateAround(Planet.transform.position, -transform.right, Input.GetAxis("Mouse Y") * CameraSpeed);
            }


            transform.RotateAround(Planet.transform.position, Vector3.up, Input.GetAxis("Mouse X") * CameraSpeed);

        }

    }
    void PanCamera()
    {

        if (Input.GetMouseButton(2))//Pan camera
        {
            transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")), Space.Self);
        }
        else
        {
            transform.LookAt(Planet.transform);
        }
    }
}
