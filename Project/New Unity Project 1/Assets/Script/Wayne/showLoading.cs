using MiniJSON;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using LitJson;
using System.IO;

public class showLoading : MonoBehaviour {

	// Use this for initialization
	public static showLoading _instance;
	public static bool goback; 
	public static int back = 0;




	void Awake() {
		_instance = this;
		this.gameObject.SetActive(false);
	}

	public void Show() {
		this.gameObject.SetActive (true);

	

	}

	public void Hide() {
		//back = 1;
		this.gameObject.SetActive (false);

	}

	public void goBack() {
		back = 1;
		goback = true;
		BlackMask._instance.Hide ();
		this.gameObject.SetActive (false);
	}
}
