using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataPreferences {

	public sealed class DataPrefs {

		#region Field
		private static DataPrefs _instance = null;
		private static readonly object padlock = new object();
		private PairWrapper _pairWrapper = new PairWrapper();

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
			SetData(key, value.ToString());
		}

		public int GetInt(string key) {
			string value = GetData(key);
			
			if(string.IsNullOrEmpty(value))
				return 0;
			return int.Parse(value);
		}

		public void SetFloat(string key, float value) {
			SetData(key, value.ToString());
		}

		public float GetFloat(string key) {
			string value = GetData(key);
			
			if(string.IsNullOrEmpty(value))
				return 0f;
			return float.Parse(value);
		}

		public void SetString(string key, string value) {
			SetData(key, value.ToString());
		}

		public string GetString(string key) {
			return GetData(key);
		}

		public void SetBool(string key, bool value) {
			SetData(key, value.ToString());
		}

		public bool GetBool(string key) {
			string value = GetData(key);
			
			if(value == "false")
				return false;
			return true;
		}

		public void Save() {
			string json = JsonUtility.ToJson(_pairWrapper, true);
			Debug.Log(json);
		}

		public bool HasKey(string key) {
			foreach(var pair in _pairWrapper.pairs) {
				if(pair.key == key) {
					return true;
				}
			}
			return false;
		}
		#endregion

		#region Private Method
		private void SetData(string key, string value) {
			if(HasKey(key)) {
				OverwriteData(key, value);
			} else {
                AddData(key, value);
            }
        }

        private void AddData(string key, string value) {
            _pairWrapper.pairs.Add(new Pair() { key = key, value = value });
        }

        private void OverwriteData(string key, string value) {
			foreach(var pair in _pairWrapper.pairs) {
				if(pair.key == key) {
					pair.value = value;
				}
			}
		}

		// TODO:
		// Check if data exist & Overwrite it

		private string GetData(string key) {
			string value = string.Empty;
			foreach(var pair in _pairWrapper.pairs) {
				if(pair.key == key) {
					value = pair.value;
					break;
				}
			}

			return value;
		}
		#endregion

	}
}
