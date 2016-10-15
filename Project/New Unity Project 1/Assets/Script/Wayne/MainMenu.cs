using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void goChangeSetting() {
		Application.LoadLevel(1);
	}

	public void goPracticeMode() {
		Application.LoadLevel (3);
	}
	public void goEditMode() {
		Application.LoadLevel (4);
	}

	public void LogOut() {
		Application.LoadLevel (0);
	}

}
