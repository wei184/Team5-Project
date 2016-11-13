using UnityEngine;
using System.Collections;

public class ePlayerProfile : MonoBehaviour {
	void Awake() {
		string name;
		if(NPCselect.numOfNPC == 1)
			name = "NPC1";
		else if (NPCselect.numOfNPC == 2)
			name = "NPC2";
		else
			name = "NPC3";
		print (name);
		this.GetComponent<UISprite> ().spriteName = name;
	}
}
