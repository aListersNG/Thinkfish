using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoomE : MonoBehaviour {

    public Camera myCamera;
    public Transform nextCameraSpot;
    public Transform myEntryPoint;
    bool canEnter;
    GameObject myPlayer;
	
	// Update is called once per frame
	void Update () {
		if(canEnter)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                MoveToArea();
            }
        }
	}

    void MoveToArea()
    {
        myCamera.transform.position = nextCameraSpot.position;
        myPlayer.transform.position = myEntryPoint.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        canEnter = true;
        myPlayer = col.gameObject;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        canEnter = false;
        myPlayer = null;
    }
}
