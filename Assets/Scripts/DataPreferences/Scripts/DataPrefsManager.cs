using System.Collections.Generic;

namespace DataPreferences {
    
    internal sealed class DataPrefsManager {
        
        private IDataIO<PairWrapper> _dataIO;
        private PairWrapper _pairWrapper = new PairWrapper();

        internal DataPrefsManager() {
            _dataIO = new TextDataIO("DataPrefs_savefile.json");

			Load();
        }

        internal void SetData(string key, string value) {
			if(HasKey(key)) {
				OverwriteData(key, value);
			} else {
                AddData(key, value);
            }
        }

		internal string GetData(string key) {
			string value = string.Empty;
			foreach(var pair in _pairWrapper.pairs) {
				if(pair.key == key) {
					value = pair.value;
					break;
				}
			}

			return value;
		}

        internal void AddData(string key, string value) {
            _pairWrapper.pairs.Add(new Pair() { key = key, value = value });
        }

        internal void OverwriteData(string key, string value) {
			foreach(var pair in _pairWrapper.pairs) {
				if(pair.key == key) {
					pair.value = value;
				}
			}
		}

        internal bool HasKey(string key) {
			foreach(var pair in _pairWrapper.pairs) {
				if(pair.key == key) {
					return true;
				}
			}
			return false;
		}

		internal List<string> GetAllKeys() {
			var keys = new List<string>();
			
			foreach (var pair in _pairWrapper.pairs) {
				keys.Add(pair.key);
			}

			return keys;
		}

        internal void Save() {
            _dataIO.Write(_pairWrapper);
        }

		internal void Load() {
			_pairWrapper = _dataIO.Read();
		}
    }
}