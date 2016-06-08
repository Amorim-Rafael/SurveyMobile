using System;
using Android.Content;
using Android.Preferences;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SurveyMobile.Droid.Domain
{
    public class AppPreferences : ISharedPreferences, ISharedPreferencesEditor
    {
        private ISharedPreferences mSharedPrefs;
        private ISharedPreferencesEditor mPrefsEditor;
        private Context mContext;

        #region ISharedPreferences impl
        public IDictionary<string, object> All
        {
            get
            {
                return mSharedPrefs.All;
            }
        }

        public IntPtr Handle
        {
            get
            {
                return mSharedPrefs.Handle;
            }
        }

        public AppPreferences(Context context)
        {
            this.mContext = context;
            mSharedPrefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            mPrefsEditor = mSharedPrefs.Edit();
        }

        public bool Contains(string key)
        {
            throw new NotImplementedException();
        }

        public ISharedPreferencesEditor Edit()
        {
            throw new NotImplementedException();
        }

        public string GetString(string key, string defValue)
        {
            return mSharedPrefs.GetString(key, defValue);
        }

        public bool GetBoolean(string key, bool defValue)
        {
            return mSharedPrefs.GetBoolean(key, defValue);
        }

        public float GetFloat(string key, float defValue)
        {
            return mSharedPrefs.GetFloat(key, defValue);
        }

        public int GetInt(string key, int defValue)
        {
            return mSharedPrefs.GetInt(key, defValue);
        }

        public long GetLong(string key, long defValue)
        {
            return mSharedPrefs.GetLong(key, defValue);
        }

        public ICollection<string> GetStringSet(string key, ICollection<string> defValues)
        {
            return mSharedPrefs.GetStringSet(key, defValues);
        }

        public string GetListStringSet<TEntity>(string key, List<TEntity> values)
        {
            string json = JsonConvert.SerializeObject(values);

            return mSharedPrefs.GetString(key, json);
            //string json = JsonConvert.SerializeObject(values);

            //mPrefsEditor.PutString(key, json);
        }

        public void RegisterOnSharedPreferenceChangeListener(ISharedPreferencesOnSharedPreferenceChangeListener listener)
        {
            mSharedPrefs.RegisterOnSharedPreferenceChangeListener(listener);
        }

        public void UnregisterOnSharedPreferenceChangeListener(ISharedPreferencesOnSharedPreferenceChangeListener listener)
        {
            mSharedPrefs.UnregisterOnSharedPreferenceChangeListener(listener);
        }

        public void Dispose()
        {
            mSharedPrefs.Dispose();
        }
        #endregion

        #region ISharedPreferencesEditor impl
        public void Apply()
        {
            mPrefsEditor.Apply();
        }

        public ISharedPreferencesEditor Clear()
        {
            return mPrefsEditor.Clear();
        }

        public bool Commit()
        {
            return mPrefsEditor.Commit();
        }

        public ISharedPreferencesEditor PutBoolean(string key, bool value)
        {
            return mPrefsEditor.PutBoolean(key, value);
        }

        public ISharedPreferencesEditor PutFloat(string key, float value)
        {
            return mPrefsEditor.PutFloat(key, value);
        }

        public ISharedPreferencesEditor PutInt(string key, int value)
        {
            return mPrefsEditor.PutInt(key, value);
        }

        public ISharedPreferencesEditor PutLong(string key, long value)
        {
            return mPrefsEditor.PutLong(key, value);
        }

        public ISharedPreferencesEditor PutString(string key, string value)
        {
            return mPrefsEditor.PutString(key, value);
        }

        public ISharedPreferencesEditor PutStringSet(string key, ICollection<string> values)
        {
            return mPrefsEditor.PutStringSet(key, values);
        }

        public void PutListStringSet<TEntity>(string key, List<TEntity> values)
        {
            string json = JsonConvert.SerializeObject(values);

            mPrefsEditor.PutString(key, json);
        }

        public ISharedPreferencesEditor Remove(string key)
        {
            return mPrefsEditor.Remove(key);
        }
        #endregion
    }
}