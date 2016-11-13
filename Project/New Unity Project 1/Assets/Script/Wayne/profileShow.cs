using UnityEngine;
using System.Collections;

public class profileShow : MonoBehaviour {

	// Use this for initialization
	public static profileShow _instance;
	private UISprite selectSprite;

	public void Awake() {
		_instance = this;
		selectSprite = this.transform.Find ("playerProfile").GetComponent<UISprite> ();
		this.gameObject.SetActive (false);
	}

	// Use this for initialization
	public void Show() {
		BlackMask._instance.Show ();
		this.gameObject.SetActive (true);
	}


	public void goBack() {
		Profile1._instance.changeProfile (selectSprite.spriteName);
		BlackMask._instance.Hide ();
		this.gameObject.SetActive (false);
	}



}
