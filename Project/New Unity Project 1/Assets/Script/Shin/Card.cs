using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Card : MonoBehaviour {
    public string card_name;
    public string description;
	GameObject prefab;
	Sprite sprite;
	Image image;

	public int hp;
    public int cost;
    public int atk;

    //public GameRuleOverrider[] effect;

    public int stack;
    int num_selected = 0;
    public CardList selectlist;

	public Card(string card_name, string description, Sprite sprite, int cost, int hp, int atk, int stack) {
		image = gameObject.GetComponentInChildren<Image>();
		this.card_name = card_name;
		this.description = description;
		this.cost = cost;
		this.hp = hp;
		this.atk = atk;
		this.stack = stack;
		this.image.sprite = sprite;
	}

    // Use this for initialization
    void Start() {
		
    }

    // Update is called once per frame
    void Update() {

    }
    public void Select(){
        if (num_selected < stack){
            num_selected++;
            selectlist.InsertCard(this, 1);
        }
    }
    public int compare(string x, string y){
        return x.CompareTo(y);
    }
	public void flush() {
		num_selected = 0;
	}
}
