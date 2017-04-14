using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISlider : MonoBehaviour {

    float startX, EndX;
    bool gameOneComplete, gameTwoComplete;
    public Camera myCamera;
    public bool active;

	// Use this for initialization
	void Start () {
        startX = transform.position.x;
        EndX = startX + 510.0f;
        active = false;

        Feedback feed = GameObject.FindGameObjectWithTag("FeedbackSystem").GetComponent<Feedback>();
        if (feed)
        {
            if(feed.GetTasksCompleted() == 1)
            {
                active = true;
                transform.position = new Vector3((510 / 3) + startX, transform.position.y, transform.position.z);
                gameOneComplete = true;
            }
            else if(feed.GetTasksCompleted() == 2)
            {
                active = true;
                transform.position = new Vector3((510 / 3)*2 + startX, transform.position.y, transform.position.z);
                gameOneComplete = true;
                gameTwoComplete = true;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            float timeKeeper = Time.deltaTime * 5;

            if (EndX >= transform.position.x + timeKeeper)
            {
                transform.position = new Vector3(transform.position.x + timeKeeper, transform.position.y, transform.position.z);

                if (!gameOneComplete)
                {
                    if (transform.position.x >= startX + (510 / 3))
                    {
                        Application.LoadLevel("Library_Challenge_1");
                    }
                }
                else if (!gameTwoComplete)
                {
                    if (transform.position.x >= startX + (510 / 3) * 2)
                    {
                        Application.LoadLevel("Bookshelf_Challenge");
                    }
                }
            }
            else
            {
                GameObject.FindGameObjectWithTag("FeedbackSystem").GetComponent<Feedback>().dayFinished = true;
            }
        }
        else
        {
            if(myCamera.enabled)
            {
                active = true;
            }
        }

	}
}
