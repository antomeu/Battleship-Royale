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

        public LineRenderer ProjectedTrajectoryLine;

        public GravityController GravityController;

        public Vector3 CalculateSpeedDelta(Vector3 sumOfForces)
        {
            sumOfForces = CalculateSumOfForces(transform.position);
            return  sumOfForces * (Time.fixedDeltaTime / SpaceObjectMass);
        }

        public Vector3 CalculatePositionDelta(Vector3 currentSpeed)
        {
            return currentSpeed / Time.fixedDeltaTime;
        }



        private Vector3 CalculateSumOfForces(Vector3 objectPosition)
        {
            Vector3 sumOfForces = ThrustersForce;
            foreach (CellestialBody CellestialBody in GravityController.CellestialBody)
            {
                Vector3 objectToCellestialBodyVector = CellestialBody.transform.position - objectPosition; //Object to gravity body vector
                sumOfForces += objectToCellestialBodyVector.normalized 
                    *  CellestialBody.MassTimesGravityConstant * SpaceObjectMass / objectToCellestialBodyVector.sqrMagnitude ;
            }
            return sumOfForces;
        }

        private void CalculateTrajectoryPoints(int numberOfPoints)
        {
            //Initialize first next point
            Vector3 NextSpeed = Speed; //+ CalculateSpeedDelta(CalculateSumOfForces(transform.position)); 
            Vector3 NextObjectPosition = transform.position;//+ CalculatePositionDelta(NextSpeed);

            ProjectedTrajectoryLine.positionCount = numberOfPoints;

            for (int i = 0; i< numberOfPoints; i++)
            {
                ProjectedTrajectoryLine.SetPosition(i, NextObjectPosition);

                NextSpeed += CalculateSpeedDelta(CalculateSumOfForces(NextObjectPosition));
                NextObjectPosition += CalculatePositionDelta(NextSpeed);
            }
        }

        void FixedUpdate()
        {
            Speed += CalculateSpeedDelta(CalculateSumOfForces(transform.position));
            transform.position += CalculatePositionDelta(Speed);

            CalculateTrajectoryPoints(1024);
        }

    }
}
