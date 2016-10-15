using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class dragging : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {

	// Use this for initialization
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        this.transform.position = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventDrag)
    {
        Debug.Log("OnEndDrag");
    }
}
