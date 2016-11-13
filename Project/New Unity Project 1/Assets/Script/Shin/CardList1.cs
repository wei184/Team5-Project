using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using LitJson;
using System;
using MiniJSON;
using System.Collections;
using System.Text.RegularExpressions;

public class CardList1 : MonoBehaviour {
	private string jsonDeck;
	private JsonData deck;
	List<CardObject> cards = new List<CardObject>();
	List<CardObject> result_cards = new List<CardObject>();
	public Button[] panels;
	
	public GameObject sorttxt;
	public GameObject debugtxt;

	private int sortMode = 0;
	int page = 0;
	string searchKey = null;
	string tempSearchKey = null;
	bool refresh = true;
	JsonData deckJson;
	readonly int MAX_CARDS = 30;
	int[] exdeck;

	List<CardObject> edit = new List<CardObject>();
	public Button[] sidepanels;
	int total = 0;
	int offset = 0;

	private string jsonString;
	private string user_jsonString;
	private string card_jsonString;
	private JsonData userData;
	private JsonData cardData;
	string update = "localhost/BCG/update.php";

	private string username;
	private string avatar;

	// Use this for initialization
	void Start() {
		// read deck here
		
		user_jsonString = File.ReadAllText (Application.dataPath + "/Resources/User.json");
		if (user_jsonString != null) {
			int[] array = new int[30];
			IList userInfo = (IList)Json.Deserialize(user_jsonString);
			foreach (IDictionary person in userInfo) {
				username = (string)person["username"];
				avatar = (string)person["avatar"];
				IList deck = (IList)person["deck"];
				int i = 0;
				foreach (long card in deck) {
					array[i++] = unchecked((int)card);
				}
			}
			for (int i = 0; i < 30; i++) {
				InsertCard(new CardObject(array[i]), 1);
			}
		}
		for (int i = 1; i <= 3; i++) 
			for (int j = 0; j < 10; j++)
				cards.Add(new CardObject(i));
		StackCards();
		Sort();
	}
	JsonData GetDeck() {
		return deck;
	}
	// Update is called once per frame
	void Update () {
		if(refresh)
			UpdateResult();
		debugtxt.GetComponent<Text>().text = ToString();
		//debugtxt.GetComponent<Text>().text = searchKey;
	}
	void UpdateResult() {
		refresh = false;
		result_cards.Clear();
		if(searchKey == null)
			for(int i = 0; i < cards.Count; i++)
				result_cards.Add(cards[i]);
		else {
			for(int i = 0; i < cards.Count; i++)
				if(cards[i].card_name.Trim().ToLower().Contains(searchKey.Trim().ToLower()))
					result_cards.Add(cards[i]);
		}
		for (int i = 0; i < 10; i++)
			panels[i].GetComponent<CardPanel>().card = null;
		for (int i = 0; i < (result_cards.Count < 10 ? result_cards.Count : 10); i++) {
			if (cards[page * 10 + i] != null)
				panels[i].GetComponent<CardPanel>().card = result_cards[page * 10 + i];
		}
		for (int i = 0; i < 12; i++)
			sidepanels[i].GetComponent<CardPanelSide>().card = null;
		for (int i = 0; i < (result_cards.Count < 12 ? edit.Count : 12); i++) {
			if (cards[offset + i] != null)
				sidepanels[i].GetComponent<CardPanelSide>().card = edit[offset + i];
		}
	}
	public void Search(string searchKey) {
		this.searchKey = searchKey;
		refresh = true;
	}
	public void Search() {
		searchKey = tempSearchKey;
		refresh = true;
	}
	public void UpdateSearchKey(string searchKey) {
		this.tempSearchKey = searchKey;
	}

	public void PrevPage() {
		if (page > 0)
			page--;
		refresh = true;
	}
	public void NextPage() {
		if((page+1) * 10 < cards.Count)
			page++;
		refresh = true;
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
	public void InsertCard(CardObject card, int stack) {
		refresh = true;
		if (total >= MAX_CARDS)
			return;
		if (total + stack > MAX_CARDS)
			stack = MAX_CARDS - total;
		CardObject c = Find(edit,card.card_name);
		CardObject d = Find(cards, card.card_name);
		if (c == null) {
			edit.Add(new CardObject(card, stack));
			edit.Sort(SortCost);
		} else 
			c.AddStack(stack);
		if(d != null) {
			if (d.stack >= stack)
				d.DecStack(stack);
		}
		total += stack;
	}
	public void RemoveCard(CardObject card, int stack) {
		refresh = true;
		if (total <= 0)
			return;
		CardObject c = Find(edit,card.card_name);
		CardObject d = Find(cards, card.card_name);
		if (c == null) {
			//edit.Remove(new CardObject(card, stack));
			return;
		} else {
			if (c.stack > stack)
				c.DecStack(stack);
			else
			edit.Remove(c);
		}
		if (d != null) {
			d.AddStack(stack);
		}
		total -= stack;
	}
	public void Sort() {
		sortMode = (sortMode + 1) % 4;
		refresh = true;
		switch (sortMode) {
			case 0:     // Alphabetation
				cards.Sort(SortAlpha);
				sorttxt.GetComponent<Text>().text = "Sort by Alphabetation";
				break;
			case 1:     // Cost
				sorttxt.GetComponent<Text>().text = "Sort by Cost";
				cards.Sort(SortCost);
				break;
			case 2:     // Health
				sorttxt.GetComponent<Text>().text = "Sort by Health";
				cards.Sort(SortHealth);
				break;
			case 3:     // Attack
				sorttxt.GetComponent<Text>().text = "Sort by Attack";
				cards.Sort(SortAttack);
				break;
		}
	}
	private static int SortAlpha(CardObject a, CardObject b) {
		if (a == null && b == null)
			return 0;
		if (a == null && b != null)
			return -1;
		if (a != null && b == null)
			return 1;
		return a.card_name.CompareTo(b.card_name);
	}
	private static int SortCost(CardObject a, CardObject b) {
		if (a == null && b == null)
			return 0;
		if (a == null && b != null)
			return -1;
		if (a != null && b == null)
			return 1;
		if (a.cost < b.cost)
			return -1;
		if (a.cost > b.cost)
			return 1;
		return a.card_name.CompareTo(b.card_name);
	}
	private static int SortHealth(CardObject a, CardObject b) {
		if (a == null && b == null)
			return 0;
		if (a == null && b != null)
			return -1;
		if (a != null && b == null)
			return 1;
		if (a.hp < b.hp)
			return -1;
		if (a.hp > b.hp)
			return 1;
		return a.card_name.CompareTo(b.card_name);
	}
	private static int SortAttack(CardObject a, CardObject b) {
		if (a == null && b == null)
			return 0;
		if (a == null && b != null)
			return -1;
		if (a != null && b == null)
			return 1;
		if (a.atk < b.atk)
			return -1;
		if (a.atk > b.atk)
			return 1;
		return a.card_name.CompareTo(b.card_name);
	}
	public override string ToString() {
		string rev = "\n";
		for (int i = 0; i < cards.Count; i++) {
			if (cards[i] != null && cards[i].ToString() != null)
				rev = rev + cards[i].ToString() + "   " + cards[i].stack + "\n";
		}
		return rev;
	}
	public CardObject Find(List<CardObject> list, string card) {
		for (int i = 0; i < list.Count; i++) {
			if (list[i].ToString() == card) {
				return list[i];
			}
		}
		return null;
	}
	public void Flush() {
		refresh = true;
		while (edit.Count > 0) {
			RemoveCard(edit[0], edit[0].stack);
		}
		total = 0;
		offset = 0;
	}
	public void incOffset() {
		refresh = true;
		if (total - offset > 12)
			offset++;
	}
	public void decOffset() {
		refresh = true;
		if (offset > 0)
			offset--;
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
	public void Done() {
		exdeck = new int[30];
		if (total != 30)
			return;
		int count = 0;
		for (int i = 0; i < edit.Count; i++) {
			for(int j = 0; j < edit[i].stack; j++)
				exdeck[count++] = edit[i].id;
		}

		//NEED HELP, IT SHOULDNT WORK LIKE THIS
		User user = new User(username, avatar, exdeck);
		JsonData userJson = JsonMapper.ToJson(user);
		File.WriteAllText(Application.dataPath + "/Resources/User.json", "[" + userJson.ToString() + "]");

			string s_arr = "";
			for (int i = 0; i < 30; i++) {
				s_arr = s_arr + exdeck[i].ToString();
				if (i != 29)
					s_arr = s_arr + ",";
			}
			StartCoroutine(LoginToDB(username, avatar, s_arr));

	}

	IEnumerator LoginToDB(string username, string avatar, string deck) {
		WWWForm form = new WWWForm();
		form.AddField("usernamePost", username);
		form.AddField("avatarPost", avatar);
		form.AddField("deckPost", deck);

		WWW www = new WWW(update, form);
		yield return www;
	}

	public void Exit() {
		Application.LoadLevel(2);
	}
}
