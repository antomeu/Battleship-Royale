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

        public float SpaceObjectMass = 1;

        public LineRenderer ProjectedTrajectoryLine;

        public GravityController GravityController;

        private float timeInterval = 0.05f;

        public Vector3 CalculateSpeedDelta(Vector3 sumOfForces, float timeInterval)
        {
            return  sumOfForces * (timeInterval / SpaceObjectMass); //Newton 2d law
        }

        public Vector3 CalculatePositionDelta(Vector3 currentSpeed, float timeInterval)
        {
            return currentSpeed * timeInterval;
        }



        private Vector3 CalculateSumOfForces(Vector3 objectPosition)
        {
            Vector3 sumOfForces = ThrustersForce;
            foreach (CellestialBody CellestialBody in GravityController.CellestialBody)
            {
                Vector3 objectToCellestialBodyVector = CellestialBody.transform.position - objectPosition; //Object to gravity body vector
                // Add each gravity body's gravitational force
                sumOfForces += objectToCellestialBodyVector.normalized 
                    *  CellestialBody.MassTimesGravityConstant * SpaceObjectMass / objectToCellestialBodyVector.sqrMagnitude ; 
            }
            return sumOfForces;
        }

        private void CalculateTrajectoryPoints(int numberOfPoints)
        {
            //Initialize first next point
            Vector3 NextSpeed = Speed; 
            Vector3 NextObjectPosition = transform.position;

            ProjectedTrajectoryLine.positionCount = numberOfPoints;

            //TODO: only calculate all points if thrusters are on, otherwise only calculate the missing furthest point and remove the one behind
            //TODO: check if a point is inside a planet and stop trajectory there, and sen
            for (int i = 0; i < numberOfPoints; i++)
            {
                NextObjectPosition += CalculatePositionDelta(NextSpeed, 20 * timeInterval);
                NextSpeed += CalculateSpeedDelta(CalculateSumOfForces(NextObjectPosition) - ThrustersForce  , 20 * timeInterval);
                    
                ProjectedTrajectoryLine.SetPosition(i, NextObjectPosition);
            }
            
        }

        void FixedUpdate()
        {
            transform.position += CalculatePositionDelta(Speed, timeInterval);
            Speed += CalculateSpeedDelta(CalculateSumOfForces(transform.position), timeInterval);
            

            CalculateTrajectoryPoints(1024);
        }

        void Start()
        {
            //TODO: get circular orbital speed
        }

    }
}
