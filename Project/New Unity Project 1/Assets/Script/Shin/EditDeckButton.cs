using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class EditDeckButton : MonoBehaviour {
    public GameObject add;
    public GameObject edit;
    public List<GameObject> editScreen;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        SceneManager.LoadScene("editdeck");
        /*
        add.SetActive(false);
        edit.SetActive(false);
        for (int i = 0; i < editScreen.Count; i++)
        {
            editScreen[i].SetActive(true);
        }*/
    }
}
