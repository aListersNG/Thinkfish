using UnityEngine;
using System.Collections;

public class Load_Newsagents_inside : MonoBehaviour
{
    
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        if (col.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E)) // Developed by Andrew McGonigal
        {

            Application.LoadLevel("Alpha_Newsagents_inside");// modified by David Law

        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }
}
