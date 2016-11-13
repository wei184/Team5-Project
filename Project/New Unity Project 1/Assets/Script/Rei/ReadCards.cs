using MiniJSON;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using LitJson;
using System.IO;

public class ReadCards : MonoBehaviour {

	private string jsonString;
	private string user_jsonString;
	private string card_jsonString;
	private JsonData userData;
	private JsonData cardData;
	string update = "localhost/BCG/update.php";

	// Use this for initialization
	void Start () {

		/*********************************************
		 * read data from UserInfo json
		 * *******************************************/
		user_jsonString = File.ReadAllText (Application.dataPath + "/Resources/User.json");
		Debug.Log (user_jsonString);
		int[] array = new int[30];
		string avatar;
		IList userInfo = (IList)Json.Deserialize (user_jsonString);
		foreach (IDictionary person in userInfo) {
			string username = (string)person ["username"];
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


		/************************************************
		 * Read data from CardsInfo by using UserInfo
		 * **********************************************/

		card_jsonString = File.ReadAllText (Application.dataPath + "/Resources/cards.json");
		Debug.Log (card_jsonString);
		string cardname;
		int cost;
		int hp;
		int atk;
		int effect;
		string sprite;

		IList cardInfo = (IList) Json.Deserialize (card_jsonString);

		foreach (IDictionary card in cardInfo) {
			long getID = (long)card ["id"];
			Debug.Log ("card: " + getID);
			int count = 1;
			for (int i = 0; i < 30; i++) {
				if (unchecked((int)getID) == array [i]) {
					cardname = (string)card ["name"];
					cost = unchecked((int)((long)card ["cost"]));
					hp = unchecked((int)((long)card ["hp"]));
					atk = unchecked((int)((long)card ["atk"]));
					effect = unchecked((int)((long)card ["effect"]));
					sprite = (string)card ["sprite"];
					Debug.Log (count + ": name: " + cardname + " cost: " + cost + " hp: " + hp + " atk: " + atk + " effect: " + effect + " sprite: " + sprite);
				}
				count++;
			}
		}
		/*************************************************************
		 * Update Json File and Database
		 * ***********************************************************/

		// Update Json
		IList jsonList = (IList)Json.Deserialize (user_jsonString);
		int[] arr = new int[30];
		arr = new int[30]{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
		int n = 0;
		string name;
		avatar = "hello";
		foreach (IDictionary param in jsonList) {
			name = (string)param ["username"];
			//avatar = (string)param["avatar"];
			IList deck = (IList)param ["deck"];
			Debug.Log ("username:" + name);
			//Debug.Log ("avatar:" + avatar);
			/*
			foreach(string card in deck){
				Debug.Log("card:"+card);
				arr [n++] = Int32.Parse(card);
			}
			*/
			User user = new User (name, avatar, arr);
			JsonData userJson = JsonMapper.ToJson (user);
			File.WriteAllText (Application.dataPath + "/Resources/User.json", "[" + userJson.ToString () + "]");
			string s_arr = "";
			for (int i = 0; i < 30; i++) {
				s_arr = s_arr + arr [i].ToString ();
				if(i != 29)
					s_arr = s_arr + ",";
			}
			Debug.Log ("s_arr: " + s_arr);
			StartCoroutine(LoginToDB (name, avatar, s_arr));
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

