using UnityEngine;
using UnityEngine.UI;

public class CardPanelSide : MonoBehaviour {
	public CardObject card;
	public Image image;
	public Image image_in;
	Text txt;
	// Use this for initialization
	void Start () {
		image = gameObject.GetComponentInChildren<Image>();
		txt = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (card == null) {
			image.sprite = (Sprite)Resources.Load<Sprite>("Sprite/blank");
			image_in.sprite = (Sprite)Resources.Load<Sprite>("Sprite/blank");
			txt.text = "";
		} else {
			image.sprite = (Sprite)Resources.Load<Sprite>("Sprite/panelside");
			image_in.sprite = card.sprite;
			if (card.stack > 1)
				txt.text = card.card_name + " x " + card.stack;
			else
				txt.text = card.card_name;
		}
	}
	public void Select() {
		Debug.Log ("Why Not?");
		if (card == null)
			return;
		if (card.stack == 0) 
			return;
		GetComponentInParent<CardList1>().RemoveCard(card, 1);
	}
}
