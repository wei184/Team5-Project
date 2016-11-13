using UnityEngine;
using System.Collections;

public class NPCselect : MonoBehaviour {
	private UISprite selectProfile;
	public static int numOfNPC;
	public static int flag;
	public static int[] passDeck1 = { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1};
	public static int[] passDeck2 = { 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2};
	public static int[] passDeck3 = { 3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3};
	public static int npc;
	void Awake() {
		
	}

	void OnClick() {
		string str = this.gameObject.name;
		print (str);
		char[] name = str.ToCharArray();
		numOfNPC = name[3] - '0';
		flag = -1;
		Application.LoadLevel (3);
	}


}
