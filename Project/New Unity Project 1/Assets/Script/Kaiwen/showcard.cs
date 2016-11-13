using UnityEngine;
using System.Collections;

public class showcard : MonoBehaviour {

    public static showcard _instance;
    public float showtime = 2f;
    public float timer = 0;
    public bool isshow = false;
    public TweenAlpha alpha;
    public UILabel desl;
    public UILabel atkl;
    public UILabel hpl;
    public UILabel manal;
    void Awake()
    {
        _instance = this;
        this.gameObject.GetComponent<UIWidget>().alpha = 0;
    }
    void Update()
    {
        if (isshow)
        {
            timer += Time.deltaTime;
            if (timer >= showtime)
            {
                this.gameObject.GetComponent<UIWidget>().alpha = 0;
                timer = 0;
                isshow = false;
            }
            else
            {
                this.gameObject.GetComponent<UIWidget>().alpha = (showtime - timer) / showtime;
            }
        }



    }
    public void show(int atk,int hp,int mana,string description)
    {
            atkl.text = atk.ToString();
            hpl.text = hp.ToString();
            manal.text = mana.ToString();
            desl.text = description;
            this.gameObject.GetComponent<UIWidget>().alpha = 1;
            isshow = true;
            timer = 0;

    }
}
