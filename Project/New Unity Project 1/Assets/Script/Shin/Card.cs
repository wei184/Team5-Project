using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Card {
    public string card_name;
    public string description;
	public Sprite sprite;

	public int id;
	public int hp;
    public int cost;
    public int atk;

	//public GameRuleOverrider[] effects;
	//public GameRuleInterrupt conditions;

	public int stack;
    int num_selected = 0;
    public CardList selectlist;

	public Card() {
	}

	public Card(string card_name, string description, string sprite, int cost, int hp, int atk) {
		this.card_name = card_name;
		this.description = description;
		this.cost = cost;
		this.hp = hp;
		this.atk = atk;
		this.sprite = Resources.Load<Sprite> (sprite);
	}

    public int compare(string x, string y){
        return x.CompareTo(y);
    }
	public void flush(){
	}
}
