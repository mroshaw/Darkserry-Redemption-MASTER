using DaftAppleGames.Core.Buildings;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace DaftAppleGames.Editor.AutoEditor.Buildings
{
    public class LightAutotEditor : BaseAutoEditor
    {
        [Header("Light Settings")]
        public float range;
        public float intensity;
        public float radius;
        [MenuItem("Window/Buildings/Light Auto Editor")]
        public static void ShowWindow()
        {
            GetWindow(typeof(LightAutotEditor));
        }

        /// <summary>
        /// Override base class to load specific Editor settings
        /// </summary>        
        public override void LoadSettings()
        {
            base.LoadSettings();
            LightAutoEditorSettings lightAutoEditorSettings = autoEditorSettings as LightAutoEditorSettings;
            range = lightAutoEditorSettings.range;
            intensity = lightAutoEditorSettings.intensity;
            radius = lightAutoEditorSettings.radius;
        }

        /// <summary>
        /// Override base class to apply Editor specific Configuration
        /// </summary>
        /// <param name="gameObject"></param>
        public override void ConfigureGameObject(GameObject gameObject)
        {
            outputArea += $"Processing: {gameObject.name}";

            // Configure the Door component
            ConfigureLight(gameObject);

            outputArea += $"Done processing: {gameObject.name}";
        }

        /// <summary>
        /// Configure the CandleLight component
        /// </summary>
        /// <param name="gameObject"></param>
        private void ConfigureLight(GameObject gameObject)
        {
            CandleLight theCandleLight = gameObject.GetComponent<CandleLight>();
            if (!theCandleLight)
            {
                theCandleLight = gameObject.AddComponent<CandleLight>();
            }

            // Set the Interior light controller
            InteriorLightController interiorLightController = FindObjectOfType<InteriorLightController>();
            if(interiorLightController)
            {
                Debug.Log($"Found Interior Light Controller in scene. Adding to {gameObject.name}...\n");
                theCandleLight.interiorLightController = interiorLightController;
            }           

            // Add all child Lights
            theCandleLight.lights.Clear();
            Light[] allLights = gameObject.GetComponentsInChildren<Light>();
            foreach (Light light in allLights)
            {
                theCandleLight.lights.Add(light);
                HDAdditionalLightData hdLight = light.gameObject.GetComponent<HDAdditionalLightData>();
                if (!hdLight)
                {
                    hdLight = light.gameObject.AddComponent<HDAdditionalLightData>();
                }
            }

            // Add all child Particle FX / flames
            ParticleSystem[] allFlames = gameObject.GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem flame in allFlames)
            {
                theCandleLight.flames.Add(flame);
            }
        }
    }
}
