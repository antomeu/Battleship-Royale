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
        void Update()
        {
            transform.forward = Speed;
            ThrustersForce = ThrusterMultiplier * (Input.GetAxis("Horizontal") * transform.forward + Input.GetAxis("Sideway") * transform.right + Input.GetAxis("Vertical") * transform.up);
            
        }
    }
}
