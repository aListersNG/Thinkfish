using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowWhenTouching : MonoBehaviour
{
   // Use this for initialization
   void Awake()
   {
       //hide object
       gameObject.GetComponent<Renderer>().enabled = false;
   }

    void OnTriggerEnter2D(Collider2D col)
    {
        //show object when it collides with player
        if (col.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
   //when player is no longer colliding then hide object again.
   void OnTriggerExit2D(Collider2D col)
       {
           gameObject.GetComponent<Renderer>().enabled = false;
       }
    }
