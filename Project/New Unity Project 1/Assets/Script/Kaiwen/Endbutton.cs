using UnityEngine;
using System.Collections;

public class Endbutton : MonoBehaviour {
    private UILabel label;
        void Awake()
    {
        label = transform.Find("Label").GetComponent<UILabel>();
    }
    public void onEndbuttonClick()
    {
        GameObject.Find("UI Root").GetComponent<crystal>().refresh();
    }

	// Use this for initialization
}
