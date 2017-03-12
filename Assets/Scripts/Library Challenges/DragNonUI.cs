using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNonUI : MonoBehaviour {

    Vector2 offset, screenPoint;
    bool beingHeld;
    public GamePlayer gameManager;
    public bool ifActive;

    void OnMouseDown()
    {
        if (!gameManager.gamePaused && ifActive)
        {
            beingHeld = true;
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
    }

    void OnMouseDrag()
    {
        if (!gameManager.gamePaused && ifActive)
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
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (!beingHeld)
        {
            if (!(col.tag == "Book" || col.tag == "Cash" || col.tag == "LibraryCard"))
            {
                //Check in the game manager if this is correct
                gameManager.ItemDropped(this.tag, col.tag);
                //Then make object disappear
                this.gameObject.SetActive(false);
            }
        }
    }
}
