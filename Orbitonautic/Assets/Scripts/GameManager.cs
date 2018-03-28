using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [Header("Game Object References")]
        public CameraMapController CameraController;
        public GravityController GravityController;
        public List<Trajectory> Trajectories;
    }
}