using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryNPC : MonoBehaviour {

    //Used for deciding the movement
    bool walkingIn, walkingOut, idle;

    public bool gamePlaying;

    Rigidbody2D mybody;

	// Use this for initialization
	void Start () {
        walkingIn = true;
        mybody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if(walkingIn)
        {
            WalkingIn();
        }
        else if(walkingOut)
        {
            WalkingOut();
        }
        else if(idle)
        {
            GamePlay();
        }

	}

    void WalkingIn()
    {
        if(transform.position.x <= 0.0f)
        {
            //stop the character from moving
            walkingIn = false;
            idle = true;
            mybody.velocity = new Vector2(0.0f, 0.0f);
        }
        else
        {
            //npc moves into center
            mybody.velocity = new Vector2(-2.0f, 0.0f);
        }
    }

    void WalkingOut()
    {
        if(transform.position.x <= -12.0f)
        {
            ResetNPC();
        }
        else
        {
            mybody.velocity = new Vector2(-2.0f, 0.0f);
        }
    }

    void ResetNPC()
    {
        transform.position = new Vector3(10.0f, 0.0f, transform.position.z);
    }

    void GamePlay()
    {

    }
}
