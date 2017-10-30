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
        public SpaceShipController OwnSpaceShip;
        public GameManager Game;
        public Slider TimeSlider;
        public Text TimeText;

        public Text SpeedText;

        private float maxTimeScale = 29;

        void Update()
        {
            Time.timeScale = 1 + maxTimeScale * TimeSlider.value;
            TimeText.text = "TIME DILATION: " + string.Format("{0,2:N0}", Time.timeScale) + "x";

            SpeedText.text = string.Format("{0,2:N0}", OwnSpaceShip.Speed.magnitude) + "km/s";
        }
    }
}
