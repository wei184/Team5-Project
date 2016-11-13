using UnityEngine;
using System.Collections;

public class crystal : MonoBehaviour {
    public GameObject endscene;
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
    public UILabel Result;
    bool turncheck;
    enum CurrentTurn
    {
        player,
        enemy
    }
    CurrentTurn turn;
    // Use this for initialization
    void Awake () {

        turn = CurrentTurn.player;
        turncheck = false;
        for (int i = 0;i < 4;i++)
            GameObject.Find("hand").GetComponent<hand>().getcard();
        /*for (int i = 0; i < 4; i++)
            GameObject.Find("ehand").GetComponent<ehand>().getcard();*/
    }
	
	// Update is called once per frame
	void Update () {

        if (turn == CurrentTurn.player && !turncheck)
        {
            refresh();
            GameObject.Find("Fight").GetComponent<Fightcard>().setatk();
            GameObject.Find("hand").GetComponent<hand>().getcard();
            turncheck = true;
        }
        if (turn == CurrentTurn.enemy && !turncheck)
        {
            GameObject.Find("efight").GetComponent<Efightcard>().setatk();
            GameObject.Find("ehand").GetComponent<ehand>().getcard();
            erefresh();
            GameObject.Find("ehand").GetComponent<ehand>().playcard();
            turnchange();
        }


    }
    public void Updateshow()
    {
        string format = "{0}/{1}";
        string text = string.Format(format, usableNum, maxNum);
        crystalnum.text = text;
        format = "{0}";
        string healthtxt = healthn.ToString();
        health.text = healthtxt;

        string eformat = "{0}/{1}";
        string etext = string.Format(eformat, eusableNum, emaxNum);
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
        Updateshow();
    }
    public void erefresh()
    {
        if (emaxNum < 10)
            emaxNum++;
        eusableNum = emaxNum;
        Updateshow();
    }
    public void turnchange()
    {
        if (turn == CurrentTurn.player)
            turn = CurrentTurn.enemy;
        else
            turn = CurrentTurn.player;
        turncheck = false;
    }

    public void consume(int n)
    {
        usableNum -= n;
        Updateshow();
    }
    public void econsume(int n)
    {
        eusableNum -= n;
        Updateshow();
    }
    public void damage(int n,bool enemy)
    {
        if (enemy == true)
        {
            ehealthn = ehealthn - n;
            if (ehealthn < 0)
            {
                ehealthn = 0;
                endscene.SetActive(true);
                Result.text = "You win!";
            }
        }
        else
        {
            healthn = healthn - n;
            if (healthn < 0)
            {
                healthn = 0;
                endscene.SetActive(true);
                Result.text = "You lose!";
            }
        }
        Updateshow();
    }
    public void heal(int n, bool enemy)
    {
        if (enemy)
        {
            ehealthn += n;
        }
        else
            healthn += n;
        Updateshow();
    }
}
