using UnityEngine;
using System.Collections;

public class ChooseNPC : MonoBehaviour {

	// Use this for initialization
	public static ChooseNPC _instance;
	private UISprite selectProfile;

	void Awake() {
		_instance = this;
		this.gameObject.SetActive(false);
	}

	public void Show() {
		this.gameObject.SetActive (true);
	}

	public void Hide() {
		this.gameObject.SetActive (false);
	}


}
