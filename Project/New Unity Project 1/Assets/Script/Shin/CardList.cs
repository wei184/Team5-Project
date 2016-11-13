using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using LitJson;
using System;
using MiniJSON;
using System.Collections;

public class CardList : MonoBehaviour {
    List<CardObject> cards = new List<CardObject>();
    Text txt;
    int total = 0;
    public string prefix;
    readonly int MAX_CARDS = 30;


	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        //txt.text = this.ToString();
    }
    public List<CardObject> GetCards() {
        return cards;
    }
    public void InsertCard(CardObject card , int stack) {
        if (total >= MAX_CARDS)
            return;
        if (total + stack > MAX_CARDS)
            stack = MAX_CARDS - total;
        CardObject c = Find(card.card_name);
        if (c == null){
            cards.Add(new CardObject(card, stack));
        }
        else{
            c.AddStack(stack);
        }
        total += stack;
    }
    public void RemoveAll(){
        cards.Clear();
		total = 0;
    }
    public CardObject Find(string card){
        for (int i = 0; i < cards.Count; i++){
            if(cards[i].ToString() == card){
                return cards[i];
            }
        }
        return null;
    }
    public override string ToString(){
        string rev = prefix+"\n";
        for(int i = 0; i < cards.Count; i++){
            rev = rev + cards[i].ToString() + "   " + cards[i].stack +"\n";
        }
        return rev;
    }
}
