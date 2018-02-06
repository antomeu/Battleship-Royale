using UnityEngine;
using System.Collections;

public class CameraMapController : MonoBehaviour
{
    #region Unity Fields
    public GameObject Pivot;
    public GameObject Target;
    public Camera Camera;
    [Header("Movement")]
    public float ScrollSpeed = 50f;
    public float CameraRotateSpeed = 3f;
    [Header("FoV")]
    public float MinCameraFieldOfView = 1;
    public float MaxCameraFieldOfView = 70;
    [Header("Z axis range")]
    public float MinCameraDistance = 1000;
    public float MaxCameraDistance = 30000;
    [Header("Misc")]
    float zoomTarget;
    float cameraDistanceTarget;
    float scrollProgress = 0.5f;
    #endregion

    #region Unity Logic
    void Start () {

    }
    

    void Update () {
        
        ZoomCamera();

        RotateCamera();
        PanCamera();

        Pivot.transform.position = Target.transform.position;

        //TODO: syncrhronize UI camera to main one
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 100), scrollProgress.ToString());
    }
    #endregion

    #region Private Logic
    void ZoomCamera()
    {
        float  velocity = 0f;
        scrollProgress =  Mathf.Clamp(scrollProgress - (Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed * Mathf.Pow(scrollProgress + 0.1f , 2f) ), 0f , 1f) ;
        zoomTarget = Mathf.SmoothStep(MinCameraFieldOfView, MaxCameraFieldOfView, scrollProgress);
        Camera.fieldOfView = zoomTarget; // Mathf.SmoothDamp(Camera.fieldOfView, zoomTarget, ref velocity, 0.1f);

        cameraDistanceTarget = Mathf.SmoothStep(MinCameraDistance, MaxCameraDistance, scrollProgress);
        transform.localPosition = new Vector3(0, 0, - cameraDistanceTarget); //Mathf.SmoothDamp(transform.position.z, cameraDistanceTarget, ref velocity, 0.1f));
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
    #endregion
}
