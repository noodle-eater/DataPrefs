using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataPreferences;

public class DataPrefsExample : MonoBehaviour {

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
	}

}
