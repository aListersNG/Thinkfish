using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnReturnedBook : MonoBehaviour
{
    public GameObject GameController;
    public int shelfnum;


    // Use this for initialization
    void Start()
    {
        this.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {
        
    }
}
