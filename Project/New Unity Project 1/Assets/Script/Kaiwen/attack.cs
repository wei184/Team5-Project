using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {

	// Use this for initialization
    public void attackplayer()
    {
        if (this.GetComponentInParent<carda>().couldatk())
        {
            GameObject.Find("UI Root").GetComponent<crystal>().damage(this.gameObject.GetComponentInParent<carda>().getatk(), true);
            this.GetComponentInParent<carda>().atkreset();
        }
    }
}
