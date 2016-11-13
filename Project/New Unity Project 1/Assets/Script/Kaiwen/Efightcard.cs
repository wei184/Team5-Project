using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Efightcard : MonoBehaviour {

    public List<GameObject> cardList = new List<GameObject>();
    public Transform card1;
    public Transform card2;
    private float xoffset = 0;
    public void Start()
    {
        xoffset = card2.position.x - card1.position.x;
    }
    public void AddCard(GameObject go)
    {
        go.transform.parent = this.transform;
        cardList.Add(go);
        Vector3 pos = calposition();
        iTween.MoveTo(go, pos, 0.5f);
    }
    public void attack()
    {
        for (int i = 0;i < cardList.Count;i++)
        {
            if (cardList[i].GetComponent<carda>().couldatk())
            {
                GameObject.Find("UI Root").GetComponent<crystal>().damage(cardList[i].GetComponent<carda>().getatk(), false);
            }
        }
    }
    public void setatk()
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            cardList[i].GetComponent<carda>().atkreset();
        }
    }
    public Vector3 calposition(int index)
    {
        if (index % 2 == 0)
        {
            float myoff = (index / 2) * xoffset;
            Vector3 pos = new Vector3((float)1.2 * (card1.position.x - myoff), card1.position.y, card1.position.z);
            return pos;

        }
        else
        {
            float myoff = (index / 2) * xoffset;
            Vector3 pos = new Vector3((float)1.2 * (card1.position.x + myoff), card1.position.y, card1.position.z);
            return pos;
        }
    }
    public Vector3 calposition()
    {
        int index = cardList.Count;
        if (index % 2 == 0)
        {
            float myoff = (index / 2) * xoffset;
            Vector3 pos = new Vector3((float)1.2 * (card1.position.x - myoff), card1.position.y, card1.position.z);
            return pos;

        }
        else
        {
            float myoff = (index / 2) * xoffset;
            Vector3 pos = new Vector3((float)1.2 * (card1.position.x + myoff), card1.position.y, card1.position.z);
            return pos;
        }
    }
    public void RemoveCard(GameObject go)
    {
        go.transform.parent = this.transform;
        cardList.Remove(go);
        UpdateShow();

    }
    public void UpdateShow()
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            Vector3 toPosition = calposition(i + 1);
            iTween.MoveTo(cardList[i], toPosition, 0.5f);
        }
        for (int i = 0; i < cardList.Count; i++)
            cardList[i].GetComponent<carda>().state = carda.Currentstate.field;
    }
}
