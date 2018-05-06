using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts 
{
    public class TrajectoryController : MonoBehaviour
    {
        public Vector3[] Positions;

        public int PositionCount
        {
            get
            {
                return Positions.Length;
            }
            set
            {
                Array.Resize(ref Positions, value);
            }
        }

        public void SetPosition(int index, Vector3 position)
        {
            Positions[index] = position;
        }
    }
}
