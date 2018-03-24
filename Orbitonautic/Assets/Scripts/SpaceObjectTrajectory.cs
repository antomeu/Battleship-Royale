using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts 
{
    class SpaceObjectTrajectory
    {
        Vector3[] Positions;

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

        void SetPosition(int i, Vector3 position)
        {
            
        }
    }
}
