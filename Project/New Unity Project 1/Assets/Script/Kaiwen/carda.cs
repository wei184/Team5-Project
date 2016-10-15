using UnityEngine;
using System.Collections;

public class carda : MonoBehaviour {

    private UISprite sprite;
    private UILabel hpl;
    private UILabel atkl;
    public int atk;
    public int hp;
    private string CardName
    {
        get
        {
            return sprite.spriteName;
        }
    }
    void Awake()
    {
        sprite = this.GetComponent<UISprite>();
    }
    public void reset()
    {
        atkl.text = atk + "";
        hpl.text = hp + "";
    }
    private void getstat()
    {

    }
}
