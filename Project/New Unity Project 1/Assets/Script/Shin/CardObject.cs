using UnityEngine;
using System.Collections;

public class CardObject {
    public string card_name;
    public int stack;
    public CardList cardlist;
    public Card card;
    public CardObject(string card_name){
        this.card_name = card_name;
        stack = 1;
    }
    public CardObject(Card card, int stack){
		this.card = card;
        card_name = card.card_name;
        this.stack = stack;
    }
    public void AddStack(int stack){
        this.stack+= stack;
    }
    public override string ToString(){
        return card_name;
    }
    public static bool operator < (CardObject A, CardObject B){
        return 0 < string.Compare(A.ToString(), B.ToString());
    }
    public static bool operator > (CardObject A, CardObject B){
        return 0 > string.Compare(A.ToString(), B.ToString());
    }
}
