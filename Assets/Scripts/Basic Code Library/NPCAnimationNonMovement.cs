using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationNonMovement : MonoBehaviour {

    public Sprite[] myAnimation;
    int counter = 0;
    float animationTime;
    float currentAnimTime = 0.0f;

	// Use this for initialization
	void Start () {
        animationTime = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
        //Update the timer
        currentAnimTime += Time.deltaTime;
        
        //check if the next animation should be played
        if(currentAnimTime >= animationTime)
        {
            //Get the next animation
            if(counter != myAnimation.Length - 1)
            {
                counter++;
            }
            else
            {
                counter = 0;
            }

            //Reset timer
            currentAnimTime = 0.0f;

            //Set the next animation
            GetComponent<SpriteRenderer>().sprite = myAnimation[counter];
        }
	}
}
