using MiniJSON;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using LitJson;
using System.IO;

public class MainMenu : MonoBehaviour {


	private string user_jsonString;
	string Matched = "localhost/BCG/Matched.php";
	string updateStatus = "localhost/BCG/updateStatus.php";
	bool match = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Awake() {

	}

	public void goChangeSetting() {
		OptionShow._instance.Show();
		//Application.LoadLevel(1);
	}

	public void goPracticeMode() {
		BlackMask._instance.Show ();
		ChooseNPC._instance.Show ();
	}
	public void goEditMode() {
		Application.LoadLevel (4);
	}

	public void goOnlineMode() {
		
		BlackMask._instance.Show ();
		showLoading._instance.Show();
			
		//StartCoroutine (wait());

		//Debug.Log ("wait done");


	
		user_jsonString = File.ReadAllText (Application.dataPath + "/Resources/User.json");
		Debug.Log (user_jsonString);
		string username = "";
		IList userInfo = (IList)Json.Deserialize (user_jsonString);
		foreach (IDictionary person in userInfo) {
			username = (string)person ["username"];
			Debug.Log ("username:" + username);
		}

		StartCoroutine(statusUpdate (username, 2));


		//StartCoroutine(DelayMethod(2.0f, () => {	
		//int count = 0;
		//do {
		StartCoroutine(matchedUpdate (username));
			// if user click the back button
		//while(showLoading.goback != true);
		//	while(showLoading.back != 1) {
				//StartCoroutine(DelayMethod(5.0f, () => {
					StartCoroutine(statusUpdate (username, 1));
				//	Debug.Log ("here");
				//}));

		//		}
		//}));
		Debug.Log ("here");

	}

	public void profile() {
		profileShow._instance.Show();
	}

	IEnumerator wait() {
		//print (Time.time);
		yield return new WaitForSeconds (5);
		//print (Time.time);
	}
	private IEnumerator DelayMethod(float waitTime, Action action)
	{
		yield return new WaitForSeconds(waitTime);
		action();
	}


	IEnumerator statusUpdate(string username, int status) {
		Debug.Log ("status: " + status);
		WWWForm form = new WWWForm ();
		form.AddField ("usernamePost", username);
		form.AddField ("statusPost", status);

		WWW www2 = new WWW(updateStatus, form);
		yield return www2;
		Debug.Log(www2.text);

	}

	IEnumerator matchedUpdate(string username) {

		WWWForm form = new WWWForm ();
		form.AddField ("usernamePost", username);

		WWW www = new WWW (Matched, form);
		yield return www;
		Debug.Log (www.text);

		if (string.IsNullOrEmpty (www.error)) {
			Debug.Log ("Success");
			//checkLogin = true;
			IList jsonList = (IList)Json.Deserialize (www.text);
			int[] arr = new int[30];
			int n = 0;
			string name;
			string avatar;
			foreach (IDictionary param in jsonList) {
				name = (string)param ["username"];
				avatar = (string)param ["avatar"];
				IList deck = (IList)param ["deck"];
				Debug.Log ("username:" + name);
				Debug.Log ("avatar:" + avatar);
				foreach (string card in deck) {
					Debug.Log ("card:" + card);
					arr [n++] = Int32.Parse (card);
				}
				User user = new User (name, avatar, arr);
				JsonData userJson = JsonMapper.ToJson (user);
				File.WriteAllText (Application.dataPath + "/Resources/opponent.json", "[" + userJson.ToString () + "]");
			} 
			Application.LoadLevel (3);
		} else {
			
		}

	}




	public class User {
		public string username;
		public string avatar;
		public int[] deck;

		public User(string username, string avatar, int[] deck) {
			this.username = username;
			this.avatar = avatar;
			this.deck = deck;
		}
	}

}
