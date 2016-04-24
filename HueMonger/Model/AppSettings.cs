using System;
using System.Diagnostics;
using Windows.Storage;
using Windows.UI.Xaml.Controls.Maps;

namespace HueMonger.Model
{
    public class AppSettings
    {
        private ApplicationDataContainer localSettings;
        private static AppSettings appSettingsInstance = null;
        
        public AppSettings()
        {
            try
            {
                localSettings = ApplicationData.Current.LocalSettings;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception while using IsolatedStorageSettings: " + e.ToString());
            }
        }

        public static string UserKeySetting
        {
            get
            {
                return "UserKey";
            }
        }

        public static string DeviceIPAddressSetting
        {
            get
            {
                return "DeviceIPAddress";
            }
        }


        public string UserKey
        {
            get
            {
                return GetValueOrDefault<string>(UserKeySetting, string.Empty);
            }
            set
            {
                AddOrUpdateValue(UserKeySetting, value);
            }
        }

        public string DeviceIPAddress
        {
            get
            {
                return GetValueOrDefault<string>(DeviceIPAddressSetting, string.Empty);
            }
            set
            {
                AddOrUpdateValue(DeviceIPAddressSetting, value);
            }
        }

        static public AppSettings Instance
        {
            get
            {
                if (appSettingsInstance == null)
                {
                    appSettingsInstance = new AppSettings();
                }

                return appSettingsInstance;
            }
        }

        private valueType GetValueOrDefault<valueType>(string Key, valueType defaultValue)
        {
            valueType value;

            // If the key exists, retrieve the value.
            if (localSettings.Values.Keys.Contains(Key))
            {
                value = (valueType)localSettings.Values[Key];
            }
            // Otherwise, use the default value.
            else
            {
                value = defaultValue;
            }

            return value;
        }

        /// <summary>
        /// Update a setting value for our application. If the setting does not
        /// exist, then add the setting.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool AddOrUpdateValue(string key, Object value)
        {
            bool valueChanged = false;

            // If the key exists
            if (localSettings.Values.Keys.Contains(key))
            {
                // If the value has changed
                if (localSettings.Values[key] != value)
                {
                    // Store the new value
                    localSettings.Values[key] = value;
                    valueChanged = true;
                }
            }
            // Otherwise create the key.
            else
            {
                localSettings.Values.Add(key, value);
                valueChanged = true;
            }

            return valueChanged;
        }
    }
}
