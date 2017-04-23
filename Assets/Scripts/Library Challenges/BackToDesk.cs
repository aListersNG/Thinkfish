using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToDesk : MonoBehaviour {

    public BookOpen myBook;
    public GamePlayer myPlayer;

	void OnMouseDown()
    {
        ResetBook();
    }

    void ResetBook()
    {
        myBook.ResetCamera();
        myBook.active = false;
        myBook.gameObject.GetComponent<DragNonUI>().ifActive = false;
    }
}
