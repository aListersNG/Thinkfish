using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISlider : MonoBehaviour {

    float startX, EndX;

	// Use this for initialization
	void Start () {
        startX = transform.position.x;
        EndX = startX + 510.0f;
	}
	
	// Update is called once per frame
	void Update () {
        float timeKeeper = Time.deltaTime;

        if (EndX >= transform.position.x + timeKeeper)
        {
            transform.position = new Vector3(transform.position.x + timeKeeper, transform.position.y, transform.position.z);
        }
	}
}
