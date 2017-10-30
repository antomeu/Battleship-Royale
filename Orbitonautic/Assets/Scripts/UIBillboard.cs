using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillboard : MonoBehaviour
{
    public GameManager GameManager;

	
	void Update ()
	{
        FaceCamera();
	    ReSizeWithCameraDistance();
	}

    void FaceCamera()
    {
        transform.LookAt(transform.position + GameManager.CameraController.Camera.transform.rotation * Vector3.forward, GameManager.CameraController.Camera.transform.rotation * Vector3.up);
    }

    void ReSizeWithCameraDistance()
    {
        var distance = (transform.position - GameManager.CameraController.transform.position).magnitude;

        var frustumHeight = 2.0f * distance * Mathf.Tan(GameManager.CameraController.Camera.fieldOfView * 0.5f * Mathf.Deg2Rad);

        transform.localScale = 0.5f * frustumHeight / 800 * Vector3.one;
    }
}
