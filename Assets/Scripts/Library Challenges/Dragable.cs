using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler  {

    public static GameObject ItemBeingDragged;
    Vector3 startPos;

	// Use this for initialization
	void Start ()
    {
        startPos = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ItemBeingDragged = null;
        transform.position = Input.mousePosition;
        if (transform.position.y > Screen.height || transform.position.x > Screen.width || transform.position.y < 0 || transform.position.x < 0)
        {
            transform.position = startPos;
        }
    }
}
