using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Dragable : UIDragDropItem {
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        if(surface != null && surface.tag == "Fight")
        {
            this.transform.parent.GetComponent<hand>().Remove(this.gameObject);
            surface.GetComponent<Fightcard>().AddCard(this.gameObject);
        }
        else
        {
            transform.parent.GetComponent<hand>().UpdateShow();
        }
    }

}
