using UnityEngine;
using System.Collections;
using System;
public class Container_Controller : MonoBehaviour {

    public GameObject cardprefab;
    public Transform fromcard;
    public Transform tocard;
    public string [] cardname;
    private UISprite nowgenerate;
    private float timer = 0;
    public float transforma = 2f;
    public bool istransform = false;
    public int transformspeed = 5;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            generatecard();
            
    }
    public void generatecard()
    {
        GameObject go =  NGUITools.AddChild(this.gameObject, cardprefab);
        go.transform.position = fromcard.position;
        nowgenerate = go.GetComponent<UISprite>();
        iTween.MoveTo(go, tocard.position, 1f);
        System.Random random = new System.Random();
        int n = random.Next(0,cardname.Length);
        nowgenerate.spriteName = cardname[n];
    }
}
