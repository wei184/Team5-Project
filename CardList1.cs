using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using LitJson;


public class CardList1 : MonoBehaviour {
	private string jsonDeck;
	//private string jsonCards;
	private JsonData deck;
	List<CardObject> cards = new List<CardObject>();
	public Button[] panels;
	public CardList edit;
	public Text debugtxt;

	private int sortMode = 0;
	JsonData deckJson;
	readonly int MAX_CARDS = 30;
	int[] exdeck;

	// Use this for initialization
	void Start () {
		//read Json if deck exists on local data
		//otherwise, make new
		/*jsonDeck = File.ReadAllText(Application.dataPath + "/Resources/Deck.json");
		if (jsonDeck != null)
			deck = JsonMapper.ToObject(jsonDeck);
		else
			deck = new JsonData();*/
		//jsonCards = File.ReadAllText(Application.dataPath + "/Resources/Deck.json");
		//cards = JsonMapper.ToObject(jsonDeck);
		//for (int i = 0; i < 6; i++)
		cards.Add(new CardObject(1));
		cards.Add(new CardObject(2));
		cards.Add(new CardObject(3));
		/*
		int[] import = new int [30];
		for(int i = 0; i < 30; i++)
			cards.Add(new CardObject(import[i]));*/
		StackCards();
		Sort();
		debugtxt = GetComponent<Text>();
	}
	JsonData GetDeck() {
		return deck;
	}
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < 10; i++) {
			panels[i].GetComponent<CardPanel>().card = cards[i];
		}
		debugtxt.text = this.ToString();
	}
	void StackCards() {
		List<CardObject> temp = new List<CardObject>();
		while(cards.Count > 0) {
			temp.Add(cards[0]);
			cards.RemoveAt(0);
			CardObject stacking = temp[temp.Count - 1];
			while (cards.Exists(x => x.card_name == stacking.card_name)) {
				cards.Remove(cards.Find(x => x.card_name == stacking.card_name));
				stacking.stack++;
			}
		}
		cards = temp;
	}
	public void Sort() {
		sortMode = (sortMode + 1) % 4;
		switch (sortMode) {
			case 0:		// Alphabetation

				break;
			case 1:		// Cost
				break;
			case 2:		// Health
				break;
			case 3:		// Attack
				break;
		}
		/*
		for (int i = 0; i < cards.Length; i++)
			for (int j = 0; j < cards.Length; j++) {
				if (0 > cards[i].card_name.CompareTo(cards[j].card_name)) {
					Card temp = cards[i];
					cards[i] = cards[j];
					cards[j] = temp;
				}
			}*/
	}
	public override string ToString() {
		
		string rev = "\n";
		for (int i = 0; i < cards.Count; i++) {
			if(cards[i] != null && cards[i].ToString() != null)
				rev = rev + cards[i].ToString() + "   " + cards[i].stack + "\n";
		}
		//return rev;
		//return "" + cards.Count;
		return rev + "\n" + cards.Count;
	}
	public void Done() {
		exdeck = new int[30];
		if (edit.GetCards().Count != 30)
			return;
		for (int i = 0; i < edit.GetCards().Count; i++) {
			exdeck[i] = edit.GetCards()[i].GetCard().id;
		}

		deckJson = JsonMapper.ToJson(exdeck);
		File.WriteAllText(Application.dataPath + "/Deck.json", deckJson.ToString());
	}
}
