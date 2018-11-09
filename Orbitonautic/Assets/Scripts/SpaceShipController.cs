using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class SpaceShipController : SpaceObjectController
    {
        #region Unity Fields
        [Header("Ship Properties")]
        public float ThrusterMultiplier = 20;
        public bool IsFacingSpeedVector;
        public float RotatingSpeed = 5;
        [Header("Own References")]
        public Animator SpaceShipAnimator;

        public Transform CameraShaker;
        public CameraShipController ShipCamera;

        #endregion

        #region Private Fields
        Vector3 UpVector;
        private float shakeTime;
        #endregion


        #region Unity Logic
        void Update()
        {
            if (IsFacingSpeedVector)
                transform.LookAt(transform.position + Speed, transform.up); //TODO: set up vector to depend on main gravitational body orientation

            ActivateThrusters();
            Animate();

            ShakeCamera();
        }
        #endregion

        #region Private Logic

        void ActivateThrusters()
        {
            ThrustersForce = ThrusterMultiplier *
                (
                Input.GetAxis("Horizontal") * transform.forward
                + Input.GetAxis("Sideway") * transform.right
                + Input.GetAxis("Vertical") * transform.up
                );

            transform.Rotate(-RotatingSpeed * Input.GetAxis("RotateAroundMovementAxis") * Vector3.forward);
            //UpVector.
        }

        void Animate()
        {
            SpaceShipAnimator.SetFloat("forward", Input.GetAxis("Horizontal"));
            SpaceShipAnimator.SetFloat("backward", -Input.GetAxis("Horizontal"));

            SpaceShipAnimator.SetFloat("up", Input.GetAxis("Vertical"));
            SpaceShipAnimator.SetFloat("down", -Input.GetAxis("Vertical"));

            SpaceShipAnimator.SetFloat("left", -Input.GetAxis("Sideway"));
            SpaceShipAnimator.SetFloat("right", Input.GetAxis("Sideway"));

        }

        private void ShakeCamera()
        {
            if (ThrustersForce.magnitude > 1)
            { shakeTime = 1; }

            if (shakeTime > 0) shakeTime -= Time.deltaTime;
            CameraShaker.transform.localPosition = Vector3.Lerp(Vector3.zero, Random.insideUnitSphere * 0.02f, shakeTime);
            CameraShaker.transform.localEulerAngles = new Vector3(
                Mathf.Lerp(0, Random.value * 0.1f, shakeTime),
            Mathf.Lerp(0, Random.value * 0.1f, shakeTime),
            Mathf.Lerp(0, Random.value * 0.8f, shakeTime));
        }
        #endregion

    }
}
