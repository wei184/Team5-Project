using MiniJSON;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using LitJson;
using System.IO;

public class Profile1 : MonoBehaviour {

	public static Profile1 _instance;
	private string username;
	private int[] array = new int[30];
	private string avatar;
	string user_jsonString;
	string update = "localhost/BCG/update.php";

	// Use this for initialization
	void Start () {
	
	}

	void Awake() {

		user_jsonString = File.ReadAllText (Application.dataPath + "/Resources/User.json");
		Debug.Log (user_jsonString);
		IList userInfo = (IList)Json.Deserialize (user_jsonString);
		foreach (IDictionary person in userInfo) {
			username = (string)person ["username"];
			Debug.Log ("username:" + username);
			avatar = (string)person ["avatar"];
			Debug.Log ("avatar:" + avatar);
			IList deck = (IList)person ["deck"];
			int i = 0;
			foreach (long card in deck) {
				Debug.Log ("card:" + card);
				array [i++] = unchecked((int)card);
			}
		}



		_instance = this;
		this.GetComponent<UISprite> ().spriteName = avatar;
		//print (this.GetComponent<UISprite> ().spriteName);
	}

	// Update is called once per frame
	public void changeProfile(string name) {
		_instance.GetComponent<UISprite> ().spriteName = name;
		Debug.Log ("usename: " + username);
		IList jsonList = (IList)Json.Deserialize (user_jsonString);
		int n = 0;
		avatar = name;
		foreach (IDictionary param in jsonList) {
			User user = new User (username, avatar, array);
			JsonData userJson = JsonMapper.ToJson (user);
			File.WriteAllText (Application.dataPath + "/Resources/User.json", "[" + userJson.ToString () + "]");
			string s_arr = "";
			for (int i = 0; i < 30; i++) {
				s_arr = s_arr + array [i].ToString ();
				if(i != 29)
					s_arr = s_arr + ",";
			}
			Debug.Log ("s_arr: " + s_arr);
			StartCoroutine(LoginToDB (username, avatar, s_arr));
		}


	}

	IEnumerator LoginToDB(string username, string avatar, string deck) {
		WWWForm form = new WWWForm();
		form.AddField ("usernamePost", username);
		form.AddField ("avatarPost", avatar);
		form.AddField ("deckPost", deck);

		WWW www = new WWW (update, form);
		yield return www;
		Debug.Log (www.text);
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
