using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Dragable : UIDragDropItem {
    public GameObject card;
    public GameObject myparent;
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        if(surface != null && this.GetComponentInParent<carda>().state == carda.Currentstate.hand && surface.tag == "Fight" && GameObject.Find("UI Root").GetComponent<crystal>().usableNum >= card.GetComponent<carda>().getmana())
        {

            GameObject.Find("UI Root").GetComponent<crystal>().consume(card.GetComponent<carda>().getmana());
            this.transform.parent.GetComponent<hand>().Remove(this.gameObject);
            surface.GetComponent<Fightcard>().AddCard(this.gameObject);
            GameObject.Find("hand").GetComponent<hand>().UpdateShow();
            this.GetComponentInParent<carda>().state = carda.Currentstate.field;
        }
        else if (surface != null && this.GetComponentInParent<carda>().state == carda.Currentstate.field && surface.tag == "Card" && this.GetComponentInParent<carda>().couldatk() == true)
        {
            surface.GetComponentInParent<carda>().takedamage(this.GetComponentInParent<carda>().getatk());
            this.GetComponentInParent<carda>().takedamage(surface.GetComponentInParent<carda>().getatk());
            GameObject.Find("Fight").GetComponent<Fightcard>().UpdateShow();
        }
        else if (this.GetComponentInParent<carda>().state == carda.Currentstate.field)
        {
            GameObject.Find("Fight").GetComponent<Fightcard>().UpdateShow();
        }
        else
        {
            transform.parent.GetComponent<hand>().UpdateShow();
        }
    }

}
