using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class OrbitingObjectController
    {
        public bool IsNewForceApplied;

        public void Update()
        {
            if (IsNewForceApplied)
            {
                CalculateTrajectory();
            }

            CalculateNextPosition();

        }

        public void CalculateNextPosition()
        {

        }

        public void CalculateTrajectory()
        {

        }
    }
}
