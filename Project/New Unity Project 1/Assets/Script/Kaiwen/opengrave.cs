using UnityEngine;
using System.Collections;
public class opengrave : MonoBehaviour {

    bool isopen;
    public GameObject grave;

    void Awake()
    {
        isopen = false;
    }
    public void openg()
    {
        if (!isopen)
        {
            NGUITools.SetActive(grave, true);
            GameObject.Find("gravecontainer").GetComponent<showgrave>().UpdateShow();
            isopen = true;
        }
        else
        {
            NGUITools.SetActive(grave, false);
            isopen = false;
            GameObject.Find("gravecontainer").GetComponent<showgrave>().backtograve();
        }

    }
}
