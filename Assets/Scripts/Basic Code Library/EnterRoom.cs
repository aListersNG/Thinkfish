using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoom : MonoBehaviour {

    public Transform moveTo;
    public Transform myNextCameraSpot;
    public Camera myInsideCamera;

    void Awake()
    {
        myInsideCamera.enabled = false;
    }

    void MoveToArea(GameObject myPlayer)
    {
        //Move the camera and player to the correct positions
        myInsideCamera.transform.position = myNextCameraSpot.position;
        myPlayer.transform.position = moveTo.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        MoveToArea(col.gameObject);
    }
}
