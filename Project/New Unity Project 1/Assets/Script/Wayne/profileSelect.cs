using UnityEngine;
using System.Collections;

public class profileSelect : MonoBehaviour {
	private UISprite selectProfile;

	void Awake() {
		selectProfile = this.transform.parent.Find ("playerProfile").GetComponent<UISprite> ();
	}

	void OnClick() {
		string name = this.gameObject.name;
		selectProfile.spriteName = name;
	}


}
