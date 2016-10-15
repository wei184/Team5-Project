using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using System.IO;
using LitJson;


public class ChangePassword : MonoBehaviour {
	public GameObject currentPassword;
	public GameObject newPassword;
	public GameObject newConfPassword;
	private string CurrentPassword;
	private string NewPassword;
	private string NewConfPassword;
	private string Username;

	private string jsonString;
	private JsonData userData;

	string ChangePW = "localhost/BCG/ChangePW.php";

	void Start () {
		jsonString = File.ReadAllText (Application.dataPath + "/Resources/User.json");
		//Debug.Log (jsonString);
		userData = JsonMapper.ToObject(jsonString);

		//Debug.Log (playerData["name"]);
		Debug.Log(userData["username"]);
		Username = userData ["username"].ToString();
	}

	public void ChangePasswordButton() {
		bool CP = false;
		bool NP = false;
		bool NCP = false;

		if (CurrentPassword != "") {
			CP = true;
		} else {
			Debug.LogWarning ("Current Password Field Empty");
		}
		if (NewPassword != "") {
			NP = true;
		} else {
			Debug.LogWarning ("New Password Field Empty");
		}
		if (NewConfPassword != "") {
			NCP = true;
		} else {
			Debug.LogWarning ("New ConfPassword Field Empty");
		}
		if (CP == true && NP == true && NCP == true) {
			StartCoroutine(LoginToDB (CurrentPassword, NewPassword));
			//Application.LoadLevel ("Start Menu");
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (currentPassword.GetComponent<InputField> ().isFocused) {
				newPassword.GetComponent<InputField> ().Select ();
			}
			if (newPassword.GetComponent<InputField> ().isFocused) {
				newConfPassword.GetComponent<InputField> ().Select ();
			}
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			if (CurrentPassword != "" && NewPassword != "" && NewConfPassword != "") {
				ChangePasswordButton ();
			}
		}
		CurrentPassword = currentPassword.GetComponent<InputField> ().text;
		NewPassword = newPassword.GetComponent<InputField> ().text;
		NewConfPassword = newConfPassword.GetComponent<InputField> ().text;
	}

	IEnumerator LoginToDB(string curPW, string newPW) {
		WWWForm form = new WWWForm();
		form.AddField ("usernamePost", Username);
		form.AddField ("currentPasswordPost", curPW);
		form.AddField ("newPasswordPost", newPW);

		WWW www = new WWW (ChangePW, form);
		yield return www;
		Debug.Log (www.text);
	}
}
