using UnityEngine;
using System.Collections;

public class crystal : MonoBehaviour {
    public int usableNum = 1;
    public int maxNum = 1;
    public UILabel crystalnum;
    public UILabel health;
    public int healthn = 30;
    public int eusableNum = 1;
    public int emaxNum = 1;
    public UILabel ecrystalnum;
    public UILabel ehealth;
    public int ehealthn = 30;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        string format = "{0}/{1}";
        string text = string.Format(format, usableNum, maxNum);
        crystalnum.text = text;
        format = "{0}";
        string healthtxt = healthn.ToString();
        health.text = healthtxt;

        string eformat = "{0}/{1}";
        string etext = string.Format(eformat, usableNum, maxNum);
        ecrystalnum.text = etext;
        eformat = "{0}";
        string ehealthtxt = ehealthn.ToString();
        ehealth.text = ehealthtxt;

    }
    public void refresh()
    {
        if (maxNum < 10)
            maxNum++;
        usableNum = maxNum;
    }
    public void consume(int n)
    {
        usableNum -= n;
    }
    public void damage(int n,bool enemy)
    {
        if (enemy == true)
        {
            ehealthn = ehealthn -  n;
            if (ehealthn < 0)
                ehealthn = 0;
        }
        else
        {
            healthn =healthn -  n;
            if (healthn < 0)
                healthn = 0;
        }
        Update();
    }
    public void heal(int n, bool enemy)
    {
        if (enemy)
        {
            ehealthn += n;
        }
        else
            healthn += n;
    }
}
