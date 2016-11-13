﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class hand : MonoBehaviour {

    // Use this for initialization
    public GameObject cardprefab;
    public Transform card1;
    public Transform card2;
    public List<GameObject> cards = new List<GameObject>();
    private float xoffset;
    public string[] cardname;
    private UISprite generate;
    private string playing;
	private int cardlimit = 6;
    private Container_Controller generator;
    System.Random random = new System.Random();
    void Start()
    {
    }
    void Awake()
    {

        xoffset = card2.position.x - card1.position.x;
        /*for (int i = 0; i < 4; i++)
            getcard();*/
    }
    public void Remove(GameObject go)
    {
        cards.Remove(go);
    }
	public void getcard()
	{
		if (cards.Count < 6) {
			GameObject go = GameObject.Find ("Deck").GetComponent<generate_deck> ().getcard ();
			cards.Add (go);
			/*Vector3 toPosition = card1.position + new Vector3(xoffset, 0, 0) * cards.Count;
        iTween.MoveTo(go, toPosition, 1f);*/
			go.GetComponent<carda> ().state = carda.Currentstate.hand;
			UpdateShow ();
		}

	}
    public void LoseCard()
    {
        int index = Random.Range(0, cards.Count);
        Destroy(cards[index]);
        cards.RemoveAt(index);
        for (int i = 0;i < cards.Count;i++)
        {
            Vector3 toPosition = card1.position + new Vector3(xoffset, 0, 0) * i;
            iTween.MoveTo(cards[i], toPosition, 0.5f);
        }
    }
    public void UpdateShow()
    {
        for (int i = 0;i < cards.Count;i++)
        {
            Vector3 toPosition = card1.position + new Vector3(xoffset, 0, 0) * i;
            iTween.MoveTo(cards[i], toPosition, 0.5f);
        }
    }
}
