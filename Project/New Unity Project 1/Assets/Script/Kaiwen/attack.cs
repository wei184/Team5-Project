using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {

	// Use this for initialization
    public void attackplayer()
    {
        GameObject.Find("UI Root").GetComponent<crystal>().damage(1,true);
    }
}
