using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class UIManager : MonoBehaviour
    {
        #region Unity Fields
        [Header("External References")]

        public SpaceShipController OwnSpaceShip;
        public GameManager Game;
        [Header("Own References")]

        public Slider TimeSlider;
        public Text TimeText;

        public Text SpeedText;
        #endregion

        #region Private Fields
        private float maxTimeScale = 29;
        #endregion

        #region Unity Logic
        void Update()
        {
            Time.timeScale = 1 + maxTimeScale * TimeSlider.value;
            TimeText.text = "TIME DILATION: " + string.Format("{0,2:N0}", Time.timeScale) + "x";

            SpeedText.text = string.Format("{0,2:N0}", OwnSpaceShip.Speed.magnitude) + "km/s";
        }
        #endregion
    }
}
