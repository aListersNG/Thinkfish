using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOpen : MonoBehaviour {
    //Only try to update when the book is open
    public bool active;

    public Camera deskCamera, bookCamera;

    public Stamp myStamp;

    // Use this for initialization
	void Start () {
        bookCamera.enabled = false;
	}

    public void ResetCamera()
    {
        //Switch the cameras back
        deskCamera.enabled = true;
        bookCamera.enabled = false;
    }

    void OnMouseDown()
    {
        if (!active)
        {
            active = true;

            //Switch the cameras
            bookCamera.enabled = true;
            deskCamera.enabled = false;
        }
    }

    void OnMouseUp()
    {
        if(active)
        {
            GetComponent<DragNonUI>().ifActive = true;
        }
    }
}
