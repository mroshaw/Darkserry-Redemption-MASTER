using System;
using UnityEngine;

namespace DaftAppleGames.Settings
{
    /// <summary>
    /// Static class of methods to help with player settings
    /// </summary>
    public static class SettingsUtils
    {
        /// <summary>
        /// Load a "float" type Player Setting
        /// </summary>
        /// <param name="settingKey"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static float LoadFloatSetting(string settingKey, float defaultValue)
        {
            float settingValue;

            // Check if key already exists and return it, otherwise return the default
            if (PlayerPrefs.HasKey(settingKey))
            {
                settingValue = PlayerPrefs.GetFloat(settingKey);
            }
            else
            {
                settingValue = defaultValue;
            }
            return settingValue;
        }

        public static bool LoadBoolSetting(string settingKey, bool defaultValue)
        {
            bool settingValue;

            // Check if key already exists and return it, otherwise return the default
            if (PlayerPrefs.HasKey(settingKey))
            {
                settingValue = Convert.ToBoolean(PlayerPrefs.GetInt(settingKey));
            }
            else
            {
                settingValue = defaultValue;
            }
            return settingValue;
        }

    }
}