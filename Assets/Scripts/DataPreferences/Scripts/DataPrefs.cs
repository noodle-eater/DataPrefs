using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataPreferences {

	public sealed class DataPrefs {

		#region Field
		private static DataPrefs _instance = null;
		private static readonly object padlock = new object();
		private DataPrefsManager _manager = new DataPrefsManager();

		public static DataPrefs Instance {
			get {
				lock (padlock) {
					if(_instance == null) {
						_instance = new DataPrefs();
					}
					return _instance;
				}
			}
		}
		#endregion

		#region Public Method
		public void SetInt(string key, int value) {
			_manager.SetData(key, value.ToString());
		}

		public int GetInt(string key) {
			string value = _manager.GetData(key);
			
			if(string.IsNullOrEmpty(value))
				return 0;
			return int.Parse(value);
		}

		public void SetFloat(string key, float value) {
			_manager.SetData(key, value.ToString());
		}

		public float GetFloat(string key) {
			string value = _manager.GetData(key);
			
			if(string.IsNullOrEmpty(value))
				return 0f;
			return float.Parse(value);
		}

		public void SetString(string key, string value) {
			_manager.SetData(key, value.ToString());
		}

		public string GetString(string key) {
			return _manager.GetData(key);
		}

		public void SetBool(string key, bool value) {
			_manager.SetData(key, value.ToString());
		}

		public bool GetBool(string key) {
			string value = _manager.GetData(key);
			
			if(value == "false")
				return false;
			return true;
		}

		public void Save() {
			_manager.Save();
		}

		public bool HasKey(string key) {
			return _manager.HasKey(key);
		}
		#endregion

		public List<string> GetAllKeys() {
			return _manager.GetAllKeys();
		}
		
	}
}
