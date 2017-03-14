using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamp : MonoBehaviour {

    public bool ifActive, stampComplete;
    bool beingHeld, inTrigger;
    Vector2 screenPoint, offset, startPos;
    public GamePlayer gameManager;
    public BookOpen myBook;

    void Start()
    {
        startPos = transform.position;
    }

    void OnMouseDown()
    {
        if (ifActive)
        {
            beingHeld = true;
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
    }

    void OnMouseDrag()
    {
        if (ifActive)
        {
            Vector2 curScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 curPosition = new Vector2(Camera.main.ScreenToWorldPoint(curScreenPoint).x + offset.x,
                Camera.main.ScreenToWorldPoint(curScreenPoint).y + offset.y);
            transform.position = curPosition;
        }
    }

    void OnMouseUp()
    {
        beingHeld = false;

        if(!inTrigger)
        {
            transform.position = startPos;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        inTrigger = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (!beingHeld)
        {
            if (col.tag == "EarlyStamp")
            {
                gameManager.GetComponent<GamePlayer>().BookCheck(false);
                gameManager.GetComponent<GamePlayer>().HideBookDates();
                myBook.ResetCamera();
                transform.position = startPos;
            }
            else if (col.tag == "LateStamp")
            {
                gameManager.GetComponent<GamePlayer>().BookCheck(true);
                gameManager.GetComponent<GamePlayer>().HideBookDates();
                myBook.ResetCamera();
                transform.position = startPos;
            }
            else
            {
                inTrigger = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        inTrigger = false;
    }
}
