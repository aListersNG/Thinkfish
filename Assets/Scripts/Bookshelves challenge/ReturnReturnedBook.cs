using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnReturnedBook : MonoBehaviour
{
    public GameObject GameController;
    public int shelfnum;
    public bool returned;


    // Use this for initialization
    void Start()
    {
        this.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.GetComponent<BookSelection>().bookInUse == shelfnum)
        {
            this.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            this.GetComponent<Renderer>().enabled = false;
        }
        if(returned == true)
        {
            this.GetComponent<Renderer>().enabled = false;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            returned = true;
        }
    }
}
