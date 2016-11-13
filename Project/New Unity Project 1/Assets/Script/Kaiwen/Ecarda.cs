using UnityEngine;
using System.Collections;

public class Ecarda : MonoBehaviour
{

    private UISprite sprite;
    public UILabel hpl;
    public UILabel atkl;
    public UILabel manal;
    public int atk;
    public int hp;
    public int mana;
    public bool canatk = false;
    public Transform grave;
    public Transform egrave;
    public GameObject green;
    enum Currentowner
    {
        player,
        enemy
    }
    public enum Currentstate
    {
        hand,
        grave,
        field
    }
    private Currentowner owner;
    public Currentstate state;
    private string CardName
    {
        get
        {
            return sprite.spriteName;
        }
    }
    public void setstate(string description)
    {
        if (string.Compare(description, "die") == 0)
        {
            state = Currentstate.grave;
        }
        if (string.Compare(description, "hand") == 0)
        {
            state = Currentstate.hand;
        }
        if (string.Compare(description, "field") == 0)
        {
            state = Currentstate.field;
        }

    }
    public void setowner(bool isplayer)
    {
        if (isplayer)
            owner = Currentowner.player;
        else
            owner = Currentowner.enemy;
    }
    public void atkreset()
    {
        if (canatk == true)
        {
            canatk = false;
            NGUITools.SetActive(green, false);
        }
        else
        {
            canatk = true;
            NGUITools.SetActive(green, true);
        }
    }
    public bool couldatk()
    {
        return canatk;
    }
    void Awake()
    {
        /*sprite = this.GetComponent<UISprite>();*/
        atk = int.Parse(atkl.text);
        hp = int.Parse(hpl.text);
        mana = int.Parse(manal.text);

    }
    public int getmana()
    {
        return mana;
    }
    public int getatk()
    {
        return atk;
    }
    public int gethp()
    {
        return hp;
    }

    public void reset()
    {
        atkl.text = atk + "";
        hpl.text = hp + "";
    }
    public void die()
    {
        if (owner == Currentowner.player)
            iTween.MoveTo(this.gameObject, grave.position, 0.5f);
        else
            iTween.MoveTo(this.gameObject, egrave.position, 0.5f);
    }
    public void takedamage(int n)
    {
        hp -= n;
        if (hp <= 0)
            die();
    }
}
