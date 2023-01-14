#if ENVIRO_3
using Enviro;
#endif
using DaftAppleGames.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DaftAppleGames.Core.Buildings
{
    public class InteriorLightController : MonoBehaviour
    {
        [Header("Time Control")]
        public int[] onHours;
        public int[] offHours;

        [Header("Interior Lights")]
        public List<InteriorLight> interiorLights = new();
#if HDRPTIMEOFDAY_
        private HDRPTimeOfDayHelper _hdrpTodHelper;
#endif
        /// <summary>
        /// Set up the Controller
        /// </summary>
        private void Start()
        {
#if ENVIRO_3
            // Subscribe to the Enviro OnHOurPassed event
            EnviroManager.instance.Events.Settings.onHourPassedActions.AddListener(HourPassedLightUpdate);
#endif

#if HDRPTIMEOFDAY_
            _hdrpTodHelper = FindObjectOfType<HDRPTimeOfDayHelper>();
            if(_hdrpTodHelper)
            {
                _hdrpTodHelper.OnHourPassed.AddListener(HourPassedLightUpdate);
            }
#endif
        }


        /// <summary>
        /// Public method to register a new Interior Light to the controller
        /// </summary>
        /// <param name="interiorLight"></param>
        public void RegisterLight(InteriorLight interiorLight)
        {
            interiorLights.Add(interiorLight);
        }

        /// <summary>
        /// Method to hook into Hours Passed enviro events
        /// </summary>
        private void HourPassedLightUpdate()
        {
#if ENVIRO_3
            if(onHours.Contains(EnviroManager.instance.Time.hours))
            {
                TurnOnAllLights();
            }
            else if (offHours.Contains(EnviroManager.instance.Time.hours))
            {
                TurnOnAllLights();
            }
#endif

#if HDRPTIMEOFDAY_
            if (onHours.Contains(_hdrpTodHelper.currentHour))
            {
                TurnOnAllLights();
            }
            else if (offHours.Contains(_hdrpTodHelper.currentHour))
            {
                TurnOnAllLights();
            }
#endif
        }

        /// <summary>
        /// Public method to turn on all lights within the controller
        /// </summary>
        public void TurnOnAllLights()
        {
            foreach (InteriorLight interiorLight in interiorLights)
            {
                interiorLight.TurnOnLight();
            }
        }

        public void TurnOffAllLights()
        {
            foreach(InteriorLight interiorLight in interiorLights)
            {
                interiorLight.TurnOffLight();
            }
        }


        public void ToggleAllLights()
        {

        }
    }
}