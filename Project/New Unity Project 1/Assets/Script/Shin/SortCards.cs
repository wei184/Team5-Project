using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class SortCards : MonoBehaviour {
	Text txt;
    public Card[] cards;
    private Vector3[] pos;
    private int mode;
	// Use this for initialization
	void Start () {
		txt = GetComponentInChildren<Text>();
		txt.text = "Sorted by Cost";
		pos = new Vector3[cards.Length];
        for (int i = 0; i < pos.Length; i++)
            pos[i] = cards[i].transform.position;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    public void Sort()
    {
        switch (mode)
        {
            case 0:
                SortAlphabetic();
                break;
            case 1:
                SortCost();
                break;
            case 2:
                SortHealth();
                break;
            case 3:
                SortAttack();
                break;
            default:
                break;
        }
        if (mode == 3)
            mode = 0;
        else
            mode++;
    }
    public void SortAlphabetic()
    {
        for(int i = 0; i < cards.Length; i++)
            for(int j = 0; j < cards.Length; j++)
            {
                if(0 > cards[i].card_name.CompareTo(cards[j].card_name))
                {
                    Card temp = cards[i];
                    cards[i] = cards[j];
                    cards[j] = temp;
                }
            }
        for (int i = 0; i < pos.Length; i++)
             cards[i].transform.position = pos[i];
		txt.text = "Sorted by Alphabetation";
    }
    public void SortCost()
    {
        for (int i = 0; i < cards.Length; i++)
            for (int j = 0; j < cards.Length; j++)
            {
                if (0 > cards[i].cost.CompareTo(cards[j].cost))
                {
                    Card temp = cards[i];
                    cards[i] = cards[j];
                    cards[j] = temp;
                }
            }
        for (int i = 0; i < pos.Length; i++)
            cards[i].transform.position = pos[i];
		txt.text = "Sorted by Cost";
	}
    public void SortHealth()
    {
        for (int i = 0; i < cards.Length; i++)
            for (int j = 0; j < cards.Length; j++)
            {
                if (0 > cards[i].hp.CompareTo(cards[j].hp))
                {
                    Card temp = cards[i];
                    cards[i] = cards[j];
                    cards[j] = temp;
                }
            }
        for (int i = 0; i < pos.Length; i++)
            cards[i].transform.position = pos[i];
		txt.text = "Sorted by Health";
	}
    public void SortAttack()
    {
        for (int i = 0; i < cards.Length; i++)
            for (int j = 0; j < cards.Length; j++)
            {
                if (0 > cards[i].atk.CompareTo(cards[j].atk))
                {
                    Card temp = cards[i];
                    cards[i] = cards[j];
                    cards[j] = temp;
                }
            }
        for (int i = 0; i < pos.Length; i++)
            cards[i].transform.position = pos[i];
		txt.text = "Sorted by Attack";
	}
}
