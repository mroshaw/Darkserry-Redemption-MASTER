using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace DaftAppleGames.Core.Buildings
{
    public class InteriorLight : MonoBehaviour
    {

        [Header("Light Configuration")]
        public List<Light> lights;
        public float radius = 0.025f;
        public float range = 1.0f;
        public float intensity = 30.0f;

        public InteriorLightController interiorLightController;

        /// <summary>
        /// Configure the Light based on settings
        /// </summary>
        public virtual void Start()
        {
            ConfigureLights();

            if(interiorLightController)
            {
                interiorLightController.RegisterLight(this);
            }
        }

        /// <summary>
        /// Turn on the Light
        /// </summary>
        public virtual void TurnOnLight()
        {
            foreach(Light light in lights)
            {
                light.enabled = true;
            }
        }

        /// <summary>
        /// Turn off the Light
        /// </summary>
        public virtual void TurnOffLight()
        {
            foreach (Light light in lights)
            {
                light.enabled = false;
            }
        }

        /// <summary>
        /// Configure all Lights in the GameObject
        /// </summary>
        private void ConfigureLights()
        {
            foreach(Light light in lights)
            {
                ConfigureLight(light);
            }
        }

        /// <summary>
        /// Configure individual Light
        /// </summary>
        /// <param name="light"></param>
        private void ConfigureLight(Light light)
        {
            HDAdditionalLightData hdLight = light.GetComponent<HDAdditionalLightData>();
            hdLight.intensity = intensity;
            hdLight.range = range;
            hdLight.shapeRadius = radius;
        }
    }
}