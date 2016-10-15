using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Fightcard : MonoBehaviour {
    private List<GameObject> cardList = new List<GameObject>();
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
    public Vector3 calposition()
    {
        int index = cardList.Count;
        if (index %2 == 0)
        {
            float myoff = (index / 2) * xoffset;
            Vector3 pos = new Vector3(card1.position.x - myoff, card1.position.y, card1.position.z);
                return pos;

        }
        else
        {
            float myoff = (index / 2) * xoffset;
            Vector3 pos = new Vector3(card1.position.x + myoff, card1.position.y, card1.position.z);
            return pos;
        }
    }
}
