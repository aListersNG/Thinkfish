using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

    static GameObject instance;

	// Use this for initialization
	void Awake () {

        //Lets make sure we have one and only ONE instance going
        if(instance != null)
        {
            Destroy(this.gameObject);
        }

        instance = this.gameObject;
        DontDestroyOnLoad(transform.gameObject);
	}
	
}
