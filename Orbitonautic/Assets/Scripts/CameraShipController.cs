using UnityEngine;
using System.Collections;

public class CameraShipController : MonoBehaviour
{
    #region Unity Fields
    [HeaderAttribute("References")]
    public Camera Camera;
    public Transform SpaceShipTransform;
    [Header("Movement")]
    public float ScrollSpeed = 50f;
    public float CameraPanSpeedZoomedOut = 3f;
    public float CameraPanSpeedZoomedIn = 0.03f;

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
    void Start()
    {

    }


    void Update()
    {

        ZoomCamera();

        PanCamera();

        //TODO: syncrhronize UI camera to main one
    }

    //void OnGUI()
    //{
    //    GUI.Label(new Rect(0, 0, 100, 100), scrollProgress.ToString());
    //}
    #endregion

    #region Private Logic
    void ZoomCamera()
    {
        float velocity = 10f;
        scrollProgress = Mathf.Clamp(scrollProgress - (Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed * Mathf.Pow(scrollProgress + 0.1f, 2f)), 0f, 1f);
        zoomTarget = Mathf.SmoothStep(MinCameraFieldOfView, MaxCameraFieldOfView, scrollProgress);
        Camera.fieldOfView = Mathf.SmoothDamp(Camera.fieldOfView, zoomTarget, ref velocity, 0.1f);

        cameraDistanceTarget = Mathf.SmoothStep(MinCameraDistance, MaxCameraDistance, scrollProgress);
        //transform.localPosition = new Vector3(0, 0, - cameraDistanceTarget); //Mathf.SmoothDamp(transform.position.z, cameraDistanceTarget, ref velocity, 0.1f));
    }

    void PanCamera()
    {

        if (Input.GetMouseButton(0))//Pan camera
        {
            var PanSpeed = Mathf.Lerp(CameraPanSpeedZoomedIn, CameraPanSpeedZoomedOut, Mathf.InverseLerp(MinCameraFieldOfView, MaxCameraFieldOfView, Camera.fieldOfView));
            transform.Rotate(PanSpeed * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")), Space.Self);
            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, 0);
        }


    }

    void ShakeCamera(float strength){

    }
    #endregion
}
