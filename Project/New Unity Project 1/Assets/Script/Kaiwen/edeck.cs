using MiniJSON;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using LitJson;
using System.IO;


public class edeck : MonoBehaviour
{

    private string jsonString;
    private string user_jsonString;
    private string card_jsonString;
    private JsonData userData;
    private JsonData cardData;
    public List<GameObject> cards = new List<GameObject>();
    public GameObject cardprefab;
    System.Random random = new System.Random();
    public Transform deck;
    //string update = "localhost/BCG/update.php";

    // Use this for initialization
    void Awake()
    {
		int[] array = new int[30];
        /*********************************************
		 * read data from UserInfo json
		 * *******************************************/
		if (NPCselect.flag == -1) {
			
			if (NPCselect.numOfNPC == 1) {
				array = NPCselect.passDeck1;
			} else if (NPCselect.numOfNPC == 2) {
				array = NPCselect.passDeck2;
			} else {
				array = NPCselect.passDeck3;
			}
		} else {


			user_jsonString = File.ReadAllText (Application.dataPath + "/Resources/User.json");
			Debug.Log (user_jsonString);

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

		}
        /************************************************
		 * Read data from CardsInfo by using UserInfo
		 * **********************************************/

        card_jsonString = File.ReadAllText(Application.dataPath + "/Resources/cards.json");
        Debug.Log(card_jsonString);
        string cardname;
        int cost;
        int hp;
        int atk;
        int effect;
        string sprite;
        string description;

        IList cardInfo = (IList)Json.Deserialize(card_jsonString);

        foreach (IDictionary card in cardInfo)
        {
            long getID = (long)card["id"];
            Debug.Log("card: " + getID);
            int count = 1;
            for (int i = 0; i < 30; i++)
            {
                if (unchecked((int)getID) == array[i])
                {
                    cardname = (string)card["name"];
                    cost = unchecked((int)((long)card["cost"]));
                    hp = unchecked((int)((long)card["hp"]));
                    atk = unchecked((int)((long)card["atk"]));
                    effect = unchecked((int)((long)card["effect"]));
                    description = (string)card["description"];
                    sprite = (string)card["sprite"];
                    // call structure
                    GameObject go = NGUITools.AddChild(this.gameObject, cardprefab);
                    go.GetComponent<carda>().setowner(true);
                    /*generate.spriteName = cardname[n]*/
                    ;
                    cards.Add(go);
                    go.GetComponent<carda>().state = carda.Currentstate.deck;
                    go.GetComponent<carda>().setstatus(atk, hp, cost, description);
                    go.GetComponent<carda>().setowner(false);
                    iTween.MoveTo(go, deck.position, 0.5f);
                    Debug.Log(count + ": name: " + cardname + " cost: " + cost + " hp: " + hp + " atk: " + atk + " effect: " + effect + " sprite: " + sprite);
                }
                count++;
            }

        }
        for (int i = 0; i < 4; i++)
            GameObject.Find("ehand").GetComponent<ehand>().getcard();


    }
    public GameObject getcard()
    {
        int n = 0;
        if (cards.Count > 1)
        n = random.Next(cards.Count);
        GameObject go = cards[n];
        cards.Remove(go);
        return go;
    }
    public void addcard(GameObject go)
    {
        cards.Add(go);
    }
}