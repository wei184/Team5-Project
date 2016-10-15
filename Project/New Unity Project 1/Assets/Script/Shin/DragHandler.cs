using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public static GameObject dragged;
    Vector3 startpos;
    Transform startparent;
    

    public void OnBeginDrag (PointerEventData eventData)
    {
        //dragged = gameObject;
        dragged = Instantiate(gameObject);
        startpos = transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent != startparent) {
        transform.position = startpos;
        }
    }
}
