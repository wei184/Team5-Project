using UnityEngine;
using System.Collections;

public class CardPanel : MonoBehaviour {
	Vector3[] pos = { new Vector3(-160, 125), new Vector3(0, 125), new Vector3(160, 125), new Vector3(-160, -125), new Vector3(0, -125), new Vector3(160, -125) };
	Card[] cards = {
		new Card("Sample Card","Hello World!", Resources.Load<Sprite>("Sprite\\samplecard"),3,10,5,10),
		new Card("Temple Card","A Lame Pun", Resources.Load<Sprite>("Sprite\\templecard"),4,7,3,10),
		new Card("Gamble Card","GOOD!", Resources.Load<Sprite>("Sprite\\gamblecard"),4,7,3,10)/*,
		new Card("Pimple Card","Explodable", Resources.Load<Sprite>("Sprite\\templecard"),4,7,3,10),
		new Card("Tarot Card","ZA WARUDO", Resources.Load<Sprite>("Sprite\\templecard"),4,7,3,10),
		new Card("Credit Card","Buy Now: $9.99", Resources.Load<Sprite>("Sprite\\templecard"),4,7,3,10),
		new Card("Yet Another Christmas Card","Merry Christmas!", Resources.Load<Sprite>("Sprite\\templecard"),4,7,3,10),
		new Card("???","What?", Resources.Load<Sprite>("Sprite\\templecard"),4,7,3,10)*/ };
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
