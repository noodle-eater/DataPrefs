using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace DataPreferences {
     
    public class DataPrefsWindow : EditorWindow {

        private string[] _dataType;
        private string[] _boolData;
        private int[] _index;
        private int _boolIdx;
        private int _dataLength;
        private List<string> _keys;

        [MenuItem("Preferences Editor/DataPrefsWindow")]
        private static void ShowWindow() {
            var window = GetWindow<DataPrefsWindow>();
            window.titleContent = new GUIContent("DataPrefsWindow");
            window.Show();
        }
        
        private void OnEnable() {
            _dataType = new string[] { "int", "float", "bool", "string" };
            _boolData = new string[] { "true", "false" };
            _dataLength = DataPrefs.Instance.GetAllKeys().Count;
            _index = new int[_dataLength];
            _keys = DataPrefs.Instance.GetAllKeys();
        }
        private void OnGUI() {
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("DataPrefs Editor", new GUIStyle(GUI.skin.label) {
                alignment = TextAnchor.MiddleCenter,
            });
            DrawAllData(position);
            DrawSaveButton();
            EditorGUILayout.EndVertical();
        }

        private void DrawAllData(Rect position) {
            for(int i = 0; i < _dataLength; i++) {
                EditorGUILayout.BeginHorizontal("box");
                DrawDataPrefsField(position, i, _keys[i]);
                EditorGUILayout.EndHorizontal();
            }
        }

        private void DrawDataPrefsField(Rect position, int idx, string key)
        {
            EditorGUILayout.LabelField(key, GUILayout.Width(100));
            _index[idx] = EditorGUILayout.Popup(_index[idx], _dataType);
            DrawField(position, idx, key);
        }

        private void DrawField(Rect position, int idx, string key) {
            var value = string.Empty;
            
            if(_dataType[idx] == "bool") {
                _boolIdx = EditorGUILayout.Popup(_boolIdx, _boolData, GUILayout.Width(position.width - 200));
                value = _boolData[_boolIdx];
            } else {
                value = EditorGUILayout.TextField(DataPrefs.Instance.GetString(key), GUILayout.Width(position.width - 200));
            }

            DataPrefs.Instance.SetString(key, value);
        }

        private void DrawSaveButton() {
            if(GUILayout.Button("Save")) {
                DataPrefs.Instance.Save();
            }
        }
    }
}