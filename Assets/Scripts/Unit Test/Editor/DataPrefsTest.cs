using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using DataPreferences;

public class DataPrefsTest {

	[Test]
	public void SaveIntTest() {
		DataPrefs.Instance.SetInt("One", 1);
		var value = DataPrefs.Instance.GetInt("One");

		Assert.AreEqual(1, value);
	}

	[Test]
	public void SaveFloatTest() {
		DataPrefs.Instance.SetFloat("Half", .5f);
		var value = DataPrefs.Instance.GetFloat("Half");

		Assert.AreSame(.5f, value);
	}

	[Test]
	public void SaveStringTest() {
		DataPrefs.Instance.SetString("Name", "Hamdani");
		var value = DataPrefs.Instance.GetString("Name");

		Assert.AreSame("Hamdani", value);
	}

	[Test]
	public void SaveBoolTest() {
		DataPrefs.Instance.SetBool("Active", true);
		var value = DataPrefs.Instance.GetBool("Active");

		Assert.AreSame(true, value);
	}

	[Test]
	public void HasKeyTest() {
		DataPrefs.Instance.SetBool("Active", true);

		Assert.AreSame(true, DataPrefs.Instance.HasKey("Active"));
	}
}
