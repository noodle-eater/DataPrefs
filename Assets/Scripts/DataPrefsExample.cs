using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataPreferences;

public class DataPrefsExample : MonoBehaviour {

	public InputField keyField;
	public InputField valueField;
	public Text data;

	// Use this for initialization
	void Start () {
		DataPrefs.Instance.SetInt ("Score", 100);
		DataPrefs.Instance.SetFloat ("Modifier", 5.5f);
		DataPrefs.Instance.SetBool ("Level One", true);
		DataPrefs.Instance.SetString ("Description", "A legendary sword");

		Debug.Log ("Score : " + DataPrefs.Instance.GetInt("Score"));
		Debug.Log ("Modifier : " + DataPrefs.Instance.GetFloat("Modifier"));
		Debug.Log ("Level One : " + DataPrefs.Instance.GetBool("Level One"));
		Debug.Log ("Description : " + DataPrefs.Instance.GetString("Description"));
		DataPrefs.Instance.SetString ("Description", "A legendary sword with stick");
		Debug.Log ("Description : " + DataPrefs.Instance.GetString("Description"));
	}

	public void SaveInt() {
		if (!string.IsNullOrEmpty (keyField.text) && !string.IsNullOrEmpty (valueField.text)) {
			DataPrefs.Instance.SetInt (keyField.text, int.Parse (valueField.text));
		} else if(!string.IsNullOrEmpty(keyField.text)) {
			data.text = "Key : " + keyField.text + ", Value : " + DataPrefs.Instance.GetInt (keyField.text);
		}
	}

	public void SaveFloat() {
		if (!string.IsNullOrEmpty (keyField.text) && !string.IsNullOrEmpty (valueField.text)) {
			DataPrefs.Instance.SetFloat (keyField.text, float.Parse (valueField.text));
		} else if(!string.IsNullOrEmpty(keyField.text)) {
			data.text = "Key : " + keyField.text + ", Value : " + DataPrefs.Instance.GetFloat (keyField.text);
		}
	}

	public void SaveBool() {
		if (!string.IsNullOrEmpty (keyField.text) && !string.IsNullOrEmpty (valueField.text)) {
			DataPrefs.Instance.SetBool (keyField.text, valueField.text == "false" ? false : true);
		} else if(!string.IsNullOrEmpty(keyField.text)) {
			data.text = "Key : " + keyField.text + ", Value : " + DataPrefs.Instance.GetBool (keyField.text);
		}
	}

	public void SaveString() {
		if (!string.IsNullOrEmpty (keyField.text) && !string.IsNullOrEmpty (valueField.text)) {
			DataPrefs.Instance.SetString (keyField.text, valueField.text);
		} else if(!string.IsNullOrEmpty(keyField.text)) {
			data.text = "Key : " + keyField.text + ", Value : " + DataPrefs.Instance.GetString (keyField.text);
		}
	}
}
