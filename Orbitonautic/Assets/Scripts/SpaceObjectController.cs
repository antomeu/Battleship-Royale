using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class SpaceObjectController : MonoBehaviour
    {
        public Vector3 Speed;
        public Vector3 ThrustersForce;
        public float SpaceObjectMass;

        public GravityController GravityController;

        public Vector3 CalculateSpeedDelta(Vector3 sumOfForces)
        {
            sumOfForces = CalculateSumOfForces();
            return  sumOfForces * (Time.fixedDeltaTime / SpaceObjectMass);
        }

        public Vector3 CalculatePositionDelta(Vector3 currentSpeed)
        {
            return currentSpeed / Time.fixedDeltaTime;
        }



        private Vector3 CalculateSumOfForces()
        {
            Vector3 sumOfForces = ThrustersForce;
            foreach (CellestialBody CellestialBody in GravityController.CellestialBody)
            {
                Vector3 spaceShipToCellestialBodyVector = CellestialBody.transform.position - transform.position;
                sumOfForces += spaceShipToCellestialBodyVector.normalized *  CellestialBody.MassTimesGravityConstant * SpaceObjectMass / spaceShipToCellestialBodyVector.sqrMagnitude ;
            }
            Debug.Log(sumOfForces.magnitude);
            return sumOfForces;
        }

        void FixedUpdate()
        {
            Speed += CalculateSpeedDelta(CalculateSumOfForces());
            transform.position += CalculatePositionDelta(Speed);
            //TODO: calculate actual new position and speed
            //TODO: calculate and render the next 64 positions
        }

    }
}
