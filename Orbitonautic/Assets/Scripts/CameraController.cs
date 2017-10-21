using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject Pivot;
    public GameObject Target;
    public Camera Camera;

    public float ScrollSpeed = 50f;
    public float CameraRotateSpeed = 3f;

    public float MinCameraFieldOfView = 1;
    public float MaxCameraFieldOfView = 70;

    public float MinCameraDistance = 1000;
    public float MaxCameraDistance = 30000;

    float zoomTarget;
    float cameraDistanceTarget;
    float scrollProgress = 0.5f;
    
    void Start () {

    }
	
	void Update () {
        
        ZoomCamera();

        RotateCamera();
        PanCamera();

        Pivot.transform.position = Target.transform.position;
    }

    void ZoomCamera()
    {
        float  velocity = 0f;
        scrollProgress = Mathf.Clamp(scrollProgress - (Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed) , 0f , 1f);
        zoomTarget = Mathf.Lerp(MinCameraFieldOfView, MaxCameraFieldOfView, scrollProgress);
        Camera.fieldOfView = Mathf.SmoothDamp(Camera.fieldOfView, zoomTarget, ref velocity, 0.1f);

        cameraDistanceTarget = Mathf.Lerp(MinCameraDistance, MaxCameraDistance, scrollProgress);
        transform.localPosition = new Vector3(0, 0, cameraDistanceTarget);//Mathf.SmoothDamp(transform.position.z, cameraDistanceTarget, ref velocity, 0.1f));
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 100), scrollProgress.ToString());
    }

    void RotateCamera()
    {
        if (Input.GetMouseButton(1))//Rotate camera
        {
            Pivot.transform.Rotate(Input.GetAxis("Mouse Y") * CameraRotateSpeed * Pivot.transform.right, Space.World); 
            //TODO: lock vertical rotation maybe with these: // Quaternion PivotRotation = Pivot.transform.rotation;//var cameraVerticalPitch = Mathf.Clamp();
            Pivot.transform.Rotate(Input.GetAxis("Mouse X") * CameraRotateSpeed * Vector3.up, Space.World); 
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
            //transform.LookAt(Pivot.transform);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Pivot.transform.position - transform.position), 5 * Time.deltaTime);
        }
    }
}
