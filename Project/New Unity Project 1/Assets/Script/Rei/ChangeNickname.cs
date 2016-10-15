using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using System.IO;
using LitJson;


public class ChangeNickname : MonoBehaviour {
	public GameObject nickname;
	private string Nickname;
	private string Username;

	private string jsonString;
	private JsonData userData;

	string ChangeNN = "localhost/BCG/ChangeNN.php";

	void Start () {
		jsonString = File.ReadAllText (Application.dataPath + "/Resources/User.json");
		//Debug.Log (jsonString);
		userData = JsonMapper.ToObject(jsonString);

		//Debug.Log (playerData["name"]);
		Debug.Log(userData["username"]);
		Username = userData ["username"].ToString();
	}

	public void ChangeNicknameButton() {
		bool NN = false;

		if (Nickname != "") {
			NN = true;
		} else {
			Debug.LogWarning ("Current Password Field Empty");
		}
		if (NN == true) {
			StartCoroutine(LoginToDB (Nickname));
			//Application.LoadLevel ("Start Menu");
		}
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.L)) {
			if (Nickname != "") {
				ChangeNicknameButton ();
			}
		}
		Nickname = nickname.GetComponent<InputField> ().text;
	}

	IEnumerator LoginToDB(string nn) {
		WWWForm form = new WWWForm();
		form.AddField ("usernamePost", Username);
		form.AddField ("nicknamePost", nn);

		WWW www = new WWW (ChangeNN, form);
		yield return www;
		Debug.Log (www.text);
	}

	public void OnClick() {
		Application.LoadLevel (2);
	}

}
