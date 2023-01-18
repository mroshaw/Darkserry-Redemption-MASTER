using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
#if ASMDEF
#if ENVIRO_3
using Enviro;
#endif
#endif

#if ASMDEF
#if HDRPTIMEOFDAY

#endif
#endif
namespace DaftAppleGames.Common.Environment
{
    [ExecuteInEditMode]
    public class WeatherSyncManager : MonoBehaviour
    {
        [Header("Main Configuration")]
        public bool manageSnow = false;
        public bool manageWetness = false;
        public bool overrideAuto = false;

        [Header("Auto-Snow Config")]
        public float minSnow = 0.0f;
        public float maxSnow = 1.0f;
        public float snowTransitionDuration = 5.0f;

        [Header("Auto-Wet Config")]
        public float minWet = 0.0f;
        public float maxWet = 1.0f;
        public float wetTransitionDuration = 5.0f;

        [Header("Overrides")]
        [Range(0.0f, 1.0f)]
        public float snowLevelOverride = 0.0f;
        [Range(0.0f, 1.0f)]
        public float wetLevelOverride = 0.0f;

        [Header("Vegetation")]
        public Material[] vegetationMaterials;

#if ASMDEF
#if HDRPTIMEOFDAY
        private HDRPTimeOfDayHelper _hdrpTodHelper;
#endif
#endif
        private void Start()
        {

            SetSnow(minSnow);
            SetWet(minWet);
#if ASMDEF
#if HDRPTIMEOFDAY
            _hdrpTodHelper = FindObjectOfType<HDRPTimeOfDayHelper>();
            if (_hdrpTodHelper)
            {
                if(manageSnow)
                {
                    _hdrpTodHelper.OnStartSnowing.AddListener(StartSnow);
                    _hdrpTodHelper.OnStopSnowing.AddListener(StopSnow);

                }

                if(manageWetness)
                {
                    _hdrpTodHelper.OnStartRaining.AddListener(StartRain);
                    _hdrpTodHelper.OnStopRaining.AddListener(StopRain);

                }
            }
#endif
#endif
        }

        /// <summary>
        /// Sync the Enviro Snow and Wetness with Global and local shaders
        /// </summary>
        void Update()
        {
            // Manage Overrides
            if(overrideAuto)
            {
                if(manageSnow)
                {
                    SetSnow(snowLevelOverride);
                }
                if(manageWetness)
                {
                    SetWet(wetLevelOverride);
                }
                return;
            }

            // Enviro
#if ASMDEF
#if ENVIRO_3
            if (EnviroManager.instance == null || EnviroManager.instance.Environment == null)
            {
                return;
            }

            if (manageSnow)
            {
                Shader.SetGlobalFloat("_Global_SnowLevel", EnviroManager.instance.Environment.Settings.snow);
                Shader.SetGlobalFloat("_Snow_Amount", EnviroManager.instance.Environment.Settings.snow);

                foreach (Material mat in vegetationMaterials)
                {
                    if (mat != null)
                    {
                        mat.SetFloat("_Snow_Amount", snowLevelOverride);
                    }
                }

            }

            if(manageWetness)
            {
                float currWetness = Mathf.Clamp(EnviroManager.instance.Environment.Settings.wetness, _minWetness, _maxWetness);
                Shader.SetGlobalVector("_Global_WetnessParams", new Vector2(_minWetness, currWetness));
            }
#endif
#endif
// HDRP Time of Day
#if ASMDEF
#if HDRPTIMEOFDAY

#endif
#endif
        }

        /// <summary>
        /// Sets the Snow level on the shaders
        /// </summary>
        /// <param name="snowLevel"></param>
        private void SetSnow(float snowLevel)
        {
            Shader.SetGlobalFloat("_Global_SnowLevel", snowLevel);
            Shader.SetGlobalFloat("_Snow_Amount", snowLevel);

            foreach (Material mat in vegetationMaterials)
            {
                if (mat != null)
                {
                    mat.SetFloat("_Snow_Amount", snowLevel);
                }
            }
        }

        /// <summary>
        /// Set the Wetness shared values
        /// </summary>
        /// <param name="wetLevel"></param>
        private void SetWet(float wetLevel)
        {
            Shader.SetGlobalVector("_Global_WetnessParams", new Vector2(minWet, wetLevel));
        }

        /// <summary>
        /// Start snow transition
        /// </summary>
        public void StartSnow()
        {
            SetSnowOverTime(minSnow, maxSnow, snowTransitionDuration);
        }

        /// <summary>
        /// End snow transition
        /// </summary>
        public void StopSnow()
        {
            SetSnowOverTime(maxSnow, minSnow, snowTransitionDuration);
        }

        /// <summary>
        /// Sync wrapper to set Snow over time
        /// </summary>
        /// <param name="startSnow"></param>
        /// <param name="endSnow"></param>
        /// <param name="duration"></param>
        private void SetSnowOverTime(float startSnow, float endSnow, float duration)
        {
            StartCoroutine(SetSnowOverTimeAsync(startSnow, endSnow, duration));
        }

        /// <summary>
        /// Sets the Snow level over time
        /// </summary>
        /// <param name="startSnow"></param>
        /// <param name="endSnow"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        private IEnumerator SetSnowOverTimeAsync(float startSnow, float endSnow, float duration)
        {
            float time = 0;
            float currentSnow = startSnow;
            while (time < duration)
            {
                currentSnow = Mathf.Lerp(startSnow, endSnow, time / duration);
                SetSnow(currentSnow);
                time += Time.deltaTime;
                yield return null;
            }
            SetSnow(endSnow);
        }


        /// <summary>
        /// Start snow transition
        /// </summary>
        public void StartRain()
        {
            SetWetOverTime(minWet, maxWet, snowTransitionDuration);
        }

        /// <summary>
        /// End snow transition
        /// </summary>
        public void StopRain()
        {
            SetWetOverTime(maxSnow, minSnow, snowTransitionDuration);
        }

        /// <summary>
        /// Sync wrapper to set Wet over time
        /// </summary>
        /// <param name="startWet"></param>
        /// <param name="endWet"></param>
        /// <param name="duration"></param>
        private void SetWetOverTime(float startWet, float endWet, float duration)
        {
            StartCoroutine(SetWetOverTimeAsync(startWet, endWet, duration));
        }


        /// <summary>
        /// Sets the Wet level over time
        /// </summary>
        /// <param name="startWet"></param>
        /// <param name="endWet"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        private IEnumerator SetWetOverTimeAsync(float startWet, float endWet, float duration)
        {
            float time = 0;
            float currentWet = startWet;
            while (time < duration)
            {
                currentWet = Mathf.Lerp(startWet, endWet, time / duration);
                SetWet(currentWet);
                time += Time.deltaTime;
                yield return null;
            }
            SetSnow(endWet);
        }
    }
}
