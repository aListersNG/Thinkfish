using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Dragable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler  {

    public static GameObject ItemBeingDragged;
    Vector3 startPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
    }
}
