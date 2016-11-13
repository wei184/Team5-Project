using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class egravecontainer : MonoBehaviour {

    private List<GameObject> cards = new List<GameObject>();
    public void Addcard(GameObject go)
    {
        cards.Add(go);
    }
    public void Removecard(GameObject go)
    {
        cards.Remove(go);
    }
}
