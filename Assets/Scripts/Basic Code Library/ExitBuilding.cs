using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBuilding : MonoBehaviour {

    public Camera myInsideCamera;
    public Camera myOutsideCamera;
    public Transform moveTo;
    GameObject myPlayer;
    bool canExit;

    // Update is called once per frame
    void Update()
    {
        if (canExit)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                MoveToArea();
            }
        }
    }

    void MoveToArea()
    {
        myOutsideCamera.enabled = true;
        myInsideCamera.enabled = false;
        
        myPlayer.transform.position = moveTo.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            canExit= true;
            myPlayer = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            canExit = false;
            myPlayer = null;
        }
    }
}
