using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class showgrave : MonoBehaviour {

    private List<GameObject> cardList = new List<GameObject>();
    public Transform cardposition;
    public UISprite cardsize;
    public Transform grave;
    public void Addcard(GameObject go)
    {
        cardList.Add(go);
    }
    public void UpdateShow()
    {
        Vector3 pos;
        int y = 0;
        for (int i = 0;i < cardList.Count;i++)
        {
            if (i % 7 == 0)
                y++;
            pos = new Vector3(cardposition.position.x /*+ (i%7) * cardsize.width*/, cardposition.position.y /*+ y * cardsize.height*/, cardposition.position.z);
            cardList[i].GetComponent<UIWidget>().depth = GameObject.Find("showgrave").GetComponent<UIWidget>().depth + 1;
            iTween.MoveTo(cardList[i], pos, 0.5f);
        }
    }
    public void backtograve()
    {
        for (int i = 0; i < cardList.Count; i++)
            iTween.MoveTo(cardList[i], grave.position, 0.5f);
    }
}
