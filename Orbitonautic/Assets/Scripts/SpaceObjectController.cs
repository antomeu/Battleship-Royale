using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class SpaceObjectController : MonoBehaviour
    {
        #region Unity Fields
        [Header("External References")]
        public GameManager GameManager;

        [Header("Own References")]
        public LineRenderer ProjectedTrajectoryLine;

        [Header("Physics related settings")]
        public Vector3 Speed;
        public Vector3 ThrustersForce;
        public float SpaceObjectMass = 1;
        public bool IsOnCrashCourse = false;

        [Header("Trajectory Settings")]
        public int NumberOfTrajectoryPoints = 1024;
        public int SkippedTrajectoryPoints = 2;
        private float timeInterval = 0.05f;
        #endregion

        #region Unity Logic
        void FixedUpdate()
        {
            transform.position += CalculatePositionDelta(Speed, timeInterval);
            Speed += CalculateSpeedDelta(CalculateSumOfForces(transform.position), timeInterval);


            CalculateTrajectoryPoints(NumberOfTrajectoryPoints, SkippedTrajectoryPoints);
        }

        void Start()
        {
            //TODO: get circular orbital speed - 3 months later: why?
        }
        #endregion

        #region Private  Logic
        private Vector3 CalculateSpeedDelta(Vector3 sumOfForces, float timeInterval)
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
            foreach (CellestialBody CellestialBody in GameManager.GravityController.CellestialBody)
            {
                Vector3 objectToCellestialBodyVector = CellestialBody.transform.position - objectPosition; //Object to gravity body vector
                if (objectToCellestialBodyVector.magnitude <= CellestialBody.Radius)
                {
                    IsOnCrashCourse = true;
                    break;
                }
                else
                    IsOnCrashCourse = false;
                // Add each gravity body's gravitational force
                sumOfForces += objectToCellestialBodyVector.normalized 
                    *  CellestialBody.MassTimesGravityConstant * SpaceObjectMass / objectToCellestialBodyVector.sqrMagnitude ; 
            }
            return sumOfForces;
        }

        //TODO: Create a class for trajectory calculation?
        private void CalculateTrajectoryPoints(int numberOfPoints, int skippedPoints) //Approximation multiplier is the number of predicted points that are skipped for projection
        {
            //Initialize first next point
            Vector3 NextSpeed = Speed; 
            Vector3 NextObjectPosition = transform.position;

            ProjectedTrajectoryLine.positionCount = numberOfPoints;
            //TODO: only update points every 30 updates or so and fade in the result
            //TODO: have a "recalculating" UI warning while calculating a limited number of points everyframe
            //TODO: stop calculating points when the trajectory loops back on itself
            //TODO: only calculate all points if thrusters are on, otherwise only calculate the missing furthest point and remove the one behind
            for (int i = 0; i < numberOfPoints; i++)
            {
                NextObjectPosition += CalculatePositionDelta(NextSpeed, skippedPoints * timeInterval);
                NextSpeed += CalculateSpeedDelta(CalculateSumOfForces(NextObjectPosition) - ThrustersForce  , skippedPoints * timeInterval);
                if (IsOnCrashCourse)
                {
                    ProjectedTrajectoryLine.positionCount = i;
                    break; //TODO: ALso display some crash icon on that location
                }
                ProjectedTrajectoryLine.SetPosition(i, NextObjectPosition);


            }
            
        }
        #endregion


    }
}
