using MiniJSON;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using LitJson;
using System.IO;


public class Login : MonoBehaviour {
	public GameObject username;
	public GameObject password;
	private string Username;
	private string Password;
	bool checkLogin = false;
	//private String[] Lines;
	//private string DecrytedPass;

	string LoginURL = "localhost/BCG/Login.php";

	public void LoginButton() {
		bool UN = false;
		bool PW = false;
		if (Username != "") {
			UN = true;
			/*
			if (System.IO.File.Exists (@"/Users/REI/Desktop/BCG/TestFolder/" + Username + ".txt")) {
				UN = true;
				Lines = System.IO.File.ReadAllLines (@"/Users/REI/Desktop/BCG/TestFolder/" + Username + ".txt");
			} else {
				Debug.LogWarning ("Username Invaild");
			}
			*/
		} else {
			Debug.LogWarning ("Username Field Empty");
		}
		if (Password != "") {
			PW = true;
			/*
			if (System.IO.File.Exists (@"/Users/REI/Desktop/BCG/TestFolder/" + Username + ".txt")) {
				int i = 1;
				foreach (char c in Lines[2]) {
					i++;
					char Decrypted = (char)(c / i);
					DecrytedPass += Decrypted.ToString ();
				}
				if (Password == DecrytedPass) {
					PW = true;
				}else {
					Debug.LogWarning ("Password Is Invalid");
				}
			
			}else {
				Debug.LogWarning ("Password Is Invalid");
			}
			*/
		} else {
			Debug.LogWarning ("Password Field Empty");
		}
		if (UN == true && PW == true) {
			StartCoroutine(LoginToDB (Username, Password));
			/*
			username.GetComponent<InputField> ().text = "";
			password.GetComponent<InputField> ().text = "";
			print ("Login Successful");
			*/

			StartCoroutine(DelayMethod(1.0f, () =>
			{
					Debug.Log("Delay call");
				
				print (checkLogin);
				if (checkLogin == true) {
					//User user = new User (Username);
					//JsonData userJson = JsonMapper.ToJson (user);
					//File.WriteAllText (Application.dataPath + "/Resources/User.json", userJson.ToString ());
					Application.LoadLevel (2);
				}
			}));
			
			
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (username.GetComponent<InputField> ().isFocused) {
				password.GetComponent<InputField> ().Select ();
			}
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			if (Password != "" && Username != "") {
				LoginButton ();
			}
		}
		Username = username.GetComponent<InputField> ().text;
		Password = password.GetComponent<InputField> ().text;
	}

	IEnumerator LoginToDB(string username, string password) {
		WWWForm form = new WWWForm();
		form.AddField ("usernamePost", username);
		form.AddField ("passwordPost", password);

		WWW www = new WWW (LoginURL, form);
		yield return www;
		Debug.Log (www.text);
		if (!string.IsNullOrEmpty(www.error)) {
			Debug.Log ("Error!");
		} else {
			Debug.Log ("Success");
			//checkLogin = true;
			IList jsonList = (IList)Json.Deserialize (www.text);
			int[] arr = new int[30];
			int n = 0;
			string name;
			string avatar;
			foreach (IDictionary param in jsonList) {
				name = (string)param ["username"];
				avatar = (string)param["avatar"];
				IList deck = (IList)param ["deck"];
				Debug.Log ("username:" + name);
				Debug.Log ("avatar:" + avatar);
				foreach(string card in deck){
					Debug.Log("card:"+card);
					arr [n++] = Int32.Parse(card);
				}
				User user = new User (name, avatar, arr);
				JsonData userJson = JsonMapper.ToJson (user);
				File.WriteAllText (Application.dataPath + "/Resources/User.json", "[" + userJson.ToString () + "]");
			}
			checkLogin = true;
		}
	}

	private IEnumerator DelayMethod(float waitTime, Action action)
	{
		yield return new WaitForSeconds(waitTime);
		action();
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
