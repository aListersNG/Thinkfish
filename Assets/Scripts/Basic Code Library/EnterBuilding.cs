using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBuilding : MonoBehaviour {

    public Transform moveTo;
    public Camera myOutsideCamera;
    public Camera myInsideCamera;
    GameObject myPlayer;
    bool canEnter;
    public bool locked;

    void Awake()
    {
        myInsideCamera.enabled = false;
    }

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
        myInsideCamera.enabled = true;
        myOutsideCamera.enabled = false;
        
        myPlayer.transform.position = moveTo.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if (locked == false)
            {
                col.GetComponent<Player_Movement_Script>().atDoor = true;
                canEnter = true;
                myPlayer = col.gameObject;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            col.GetComponent<Player_Movement_Script>().atDoor = false;
            canEnter = false;
            myPlayer = null;
        }
    }

}
