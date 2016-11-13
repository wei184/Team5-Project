using UnityEngine;
using System.Collections;

public class OptionShow : MonoBehaviour {

	public static OptionShow _instance;

	public void Awake() {
		_instance = this;
		this.gameObject.SetActive (false);
	}

	// Use this for initialization
	public void Show() {
		BlackMask._instance.Show ();
		this.gameObject.SetActive (true);
	}

	public void LogOut() {
		Application.LoadLevel (0);
	}

	public void goSetting() {
		Application.LoadLevel(1);
	}

	public void goBack() {
		BlackMask._instance.Hide ();
		this.gameObject.SetActive (false);
	}
}
