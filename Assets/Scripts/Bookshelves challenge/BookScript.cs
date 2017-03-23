using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookScript : MonoBehaviour {

    public GameObject GameController;
    public int BookNum;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        if(GameController.GetComponent<BookSelection>().menuUp == false)
        {
            if(GameController.GetComponent<BookSelection>().bookReturned[BookNum] == false)
            {
                this.GetComponent<Renderer>().enabled = false;
            }
            
        }
        else
        {
            this.GetComponent<Renderer>().enabled = true;
        }

    }

    //Destroy(gameObject);
}
