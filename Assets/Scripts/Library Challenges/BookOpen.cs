using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOpen : MonoBehaviour {
    //Only try to update when the book is open
    public bool active;

    public Camera deskCamera, bookCamera;

    // Use this for initialization
	void Start () {
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
}
