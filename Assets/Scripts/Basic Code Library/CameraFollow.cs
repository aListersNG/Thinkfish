﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform playerPos;
    Vector2 distance;

	// Use this for initialization
	void Start () {
        //Set the starting distance to the player
		distance = new Vector2(playerPos.position.x - this.transform.position.x, playerPos.position.y - this.transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
        //Update the camera position
        this.transform.position = new Vector3(playerPos.position.x - distance.x, 
            playerPos.position.y - distance.y, this.transform.position.z);
	}
}