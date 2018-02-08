﻿using System;
using System.Collections.Generic;
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
        
        #endregion

        #region Private Fields
        Vector3 UpVector;
        #endregion


        #region Unity Logic
        void Update()
        {
            if (IsFacingSpeedVector)
                transform.LookAt(transform.position + Speed, transform.up); //TODO: set up vector to depend on main gravitational body orientation
            Debug.Log(transform.localEulerAngles);


            ActivateThrusters();
            Animate();
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

            transform.Rotate(-RotatingSpeed * Input.GetAxis("RotateAroundMovementAxis")*Vector3.forward);
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
        #endregion

    }
}
