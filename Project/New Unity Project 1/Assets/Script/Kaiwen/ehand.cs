using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ehand : MonoBehaviour
{

    // Use this for initialization
    public GameObject cardprefab;
    public Transform card1;
    public Transform card2;
    public List<GameObject> cards = new List<GameObject>();
    private float xoffset;
    public string[] cardname;
    private UISprite generate;
	private int cardlimit = 6;
    private string playing;
    private Container_Controller generator; System.Random random = new System.Random();
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
    void Update()
    {
    }
    public void getcard()
    {
		if (cards.Count < cardlimit) {
			GameObject go = GameObject.Find ("eDeck").GetComponent<edeck> ().getcard ();
			cards.Add (go);
			/*Vector3 toPosition = card1.position + new Vector3(xoffset, 0, 0) * cards.Count;
        iTween.MoveTo(go, toPosition, 1f);*/
			go.GetComponent<carda> ().state = carda.Currentstate.hand;
			UpdateShow ();
		}


    }
    public void playcard()
    {
        for (int i = 0;i < cards.Count;i++)
        {
            if (GameObject.Find("UI Root").GetComponent<crystal>().eusableNum >= cards[i].GetComponent<carda>().getmana() && GameObject.Find("efight").GetComponent<Efightcard>().cardList.Count < cardlimit)
            {
                GameObject.Find("efight").GetComponent<Efightcard>().AddCard(cards[i]);
                GameObject.Find("UI Root").GetComponent<crystal>().econsume(cards[i].GetComponent<carda>().getmana());
                cards[i].GetComponent<carda>().state = carda.Currentstate.field;
                cards.Remove(cards[i]);
                i  --;
            }
        }
        GameObject.Find("efight").GetComponent<Efightcard>().attack();
        UpdateShow();
    }

    public void LoseCard()
    {
        int index = Random.Range(0, cards.Count);
        Destroy(cards[index]);
        cards.RemoveAt(index);
        for (int i = 0; i < cards.Count; i++)
        {
            Vector3 toPosition = card1.position + new Vector3(xoffset, 0, 0) * i;
            iTween.MoveTo(cards[i], toPosition, 0.5f);
        }
    }
    public void UpdateShow()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Vector3 toPosition = card1.position - new Vector3(xoffset, 0, 0) * i;
            iTween.MoveTo(cards[i], toPosition, 0.5f);
        }
    }
}

