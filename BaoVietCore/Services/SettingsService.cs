﻿using BaoVietCore.Interfaces;
using Newtonsoft.Json;
using System;
using Windows.Storage;

namespace BaoVietCore.Services
{
    public class SettingsService : ServiceBase, ISettingsService
    {
        private ApplicationDataContainer roamingSettings;
        private ApplicationDataContainer localSetting;
        public SettingsService(Manager man) : base(man)
        {
            roamingSettings = ApplicationData.Current.RoamingSettings;
            localSetting = ApplicationData.Current.LocalSettings;
        }

        public T GetValueRoaming<T>(string key)
        {
            var value = roamingSettings.Values[key];
            var ret = default(T);
            try
            {
                ret = JsonConvert.DeserializeObject<T>(value as string);
            }
            catch (Exception e)
            {
                RemoveValueRoaming(key);
                return default(T);
            }
            return ret;
        }

        public void SetValueRoaming(string key, object value)
        {
            var jsonValue = JsonConvert.SerializeObject(value);
            roamingSettings.Values[key] = jsonValue;
        }

        public void RemoveValueRoaming(string key)
        {
            roamingSettings.Values.Remove(key);
        }


        public T GetValueLocal<T>(string key)
        {
            var value = localSetting.Values[key];
            var ret = default(T);
            try
            {
                ret = JsonConvert.DeserializeObject<T>(value as string);
            }
            catch (Exception e)
            {
                RemoveValueLocal(key);
                return default(T);
            }
            return ret;
        }

        public void SetValueLocal(string key, object value)
        {
            var jsonValue = JsonConvert.SerializeObject(value);
            localSetting.Values[key] = jsonValue;
        }

        public void RemoveValueLocal(string key)
        {
            localSetting.Values.Remove(key);
        }
    }
}
