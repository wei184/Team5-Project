using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class CardPanel : MonoBehaviour {
	CanvasRenderer render;
	public CardObject card;
	public Image image;
	public Image image_in;

	public Text card_name_t;
	public Text hp_t;
	public Text cost_t;
	public Text atk_t;
	public Text stack_t;

	void Start () {
		image = gameObject.GetComponentInChildren<Image>();
		render = gameObject.GetComponentInChildren<CanvasRenderer>();
	}

	// Update is called once per frame
	void Update () {
		// Displays content
		if (card == null) {
			image.sprite = (Sprite) Resources.Load<Sprite>("Sprite/blank");
			image_in.sprite = (Sprite)Resources.Load<Sprite>("Sprite/blank");
			card_name_t.text = null;
			hp_t.text = null;
			atk_t.text = null;
			stack_t.text = null;
			cost_t.text = null;

		} else {
			image.sprite = (Sprite)Resources.Load<Sprite>("Sprite/card");
			image_in.sprite = card.sprite;
			card_name_t.text = card.card_name;
			hp_t.text = card.hp.ToString();
			atk_t.text = card.atk.ToString();
			if(card.stack > 1)
				stack_t.text = "x" + card.stack;
			else
				stack_t.text = card.stack.ToString();
			cost_t.text = card.cost.ToString();
		}
	}
	public void Select() {
		if (card == null)
			return;
		if (card.stack <= 0)
			return;
		GetComponentInParent<CardList1>().InsertCard(card, 1);
	}
}
