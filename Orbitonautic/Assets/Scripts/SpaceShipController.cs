using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class SpaceShipController : SpaceObjectController
    {
        public float ThrusterMultiplier = 20;
        public Animator SpaceShipAnimator;
        void Update()
        {
            transform.forward = Speed; //TODO: set up vector to depend on main gravitational body orientation

            ThrustersForce = ThrusterMultiplier * (
                Input.GetAxis("Horizontal") * transform.forward 
                + Input.GetAxis("Sideway") * transform.right 
                + Input.GetAxis("Vertical") * transform.up);
            
            SpaceShipAnimator.SetFloat("forward", Input.GetAxis("Horizontal"));
            SpaceShipAnimator.SetFloat("backward", - Input.GetAxis("Horizontal"));

            SpaceShipAnimator.SetFloat("up", Input.GetAxis("Vertical"));
            SpaceShipAnimator.SetFloat("down", - Input.GetAxis("Vertical"));

            SpaceShipAnimator.SetFloat("left", -Input.GetAxis("Sideway"));
            SpaceShipAnimator.SetFloat("right", Input.GetAxis("Sideway"));
        }
    }
}
