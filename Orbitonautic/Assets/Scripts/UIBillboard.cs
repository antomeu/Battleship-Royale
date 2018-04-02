using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class UIBillboard : MonoBehaviour
    {
        public GameManager GameManager;

        public float VerticalViewportPercentage = 0.25f;

        public bool LockXRotation;
        public bool LockYRotation;
        public bool LockZRotation;


        void Update()
        {
            FaceCamera();
            ReSizeWithCameraDistance();
        }

        void FaceCamera()
        {
            //transform.LookAt(transform.position + GameManager.CameraController.Camera.transform.rotation * Vector3.forward, GameManager.CameraController.Camera.transform.rotation * Vector3.up);
            //transform.rotation = new Quaternion();
            var targetCameraRotation = GameManager.CameraController.transform.eulerAngles;
            targetCameraRotation = new Vector3(Convert.ToInt32(!LockXRotation) * targetCameraRotation.x, Convert.ToInt32(!LockYRotation) * targetCameraRotation.y, Convert.ToInt32(!LockZRotation) * targetCameraRotation.z);
            transform.eulerAngles = targetCameraRotation;
        }

        void ReSizeWithCameraDistance()
        {
            var distance = (transform.position - GameManager.CameraController.transform.position).magnitude;

            var frustumHeight = 2.0f * distance * Mathf.Tan(GameManager.CameraController.Camera.fieldOfView * 0.5f * Mathf.Deg2Rad); // from https://docs.unity3d.com/Manual/FrustumSizeAtDistance.html

            transform.localScale = VerticalViewportPercentage * frustumHeight / 800 * Vector3.one;
        }
    }
}
